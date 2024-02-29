using System.Text;
using System.Text.RegularExpressions;
using Dom;
using MongoWebApiStarter.Notifications;

namespace MyProject.Notifications;

sealed partial class Notification
{
    static readonly Regex _rx = MergeFieldRx();
    static readonly Dictionary<string, NotificationTemplate> _templates = new();

    public static async Task Initialize()
    {
        foreach (var t in await DB.Find<NotificationTemplate>().Match(_ => true).ExecuteAsync())
            _templates.Add(t.ID, t);
    }

    public string ToName { get; init; } = null!;
    public string ToEmail { get; init; } = null!;
    public string ToMobile { get; init; } = null!;
    public bool SendEmail { get; init; }
    public bool SendSms { get; init; }
    public string Type { get; init; } = null!;

    readonly HashSet<(string Name, string Value)> _mergeFields = [];
    readonly List<string> _missingTags = [];

    public Notification Merge(string fieldName, string fieldValue)
    {
        _mergeFields.Add((fieldName, fieldValue));

        return this;
    }

    public async Task AddToSendingQueueAsync()
    {
        if (ToName.HasNoValue() ||
            (SendEmail && ToEmail.HasNoValue()) ||
            (SendSms && ToMobile.HasNoValue()) ||
            Type.HasNoValue())
            throw new ArgumentNullException(null, "Unable to send notification without all required parameters!");

        if (!_templates.TryGetValue(Type, out var template))
            throw new ApplicationException($"Unable to find a message template for [{Type}]");

        string? emailBody = null,
                emailSubject = null,
                smsBody = null;

        if (SendEmail)
        {
            emailBody = MergeFields(template.EmailBody, nameof(NotificationTemplate.EmailBody));
            emailSubject = MergeFields(template.EmailSubject, nameof(NotificationTemplate.EmailSubject));
        }

        if (SendSms)
            smsBody = MergeFields(template.SmsBody, nameof(NotificationTemplate.SmsBody));

        if (_missingTags.Count > 0)
            throw new ApplicationException($"Replacements are missing for: [{string.Join(",", _missingTags.Distinct())}]");

        if (SendEmail)
        {
            await new SendEmailMessage
            {
                ToEmail = ToEmail,
                ToName = ToName,
                Subject = emailSubject!,
                Body = emailBody!
            }.QueueJobAsync();
        }

        if (SendSms)
        {
            await new SendSmsMessage
            {
                Mobile = ToMobile,
                Body = smsBody!
            }.QueueJobAsync();
        }
    }

    string MergeFields(string input, string fieldName)
    {
        if (input.HasNoValue())
            throw new InvalidOperationException($"The template [{Type}] has no {fieldName} value!");

        var sb = new StringBuilder(input);

        foreach (var (name, value) in _mergeFields)
            sb.Replace(name, value);

        var body = sb.ToString();

        _missingTags.AddRange(_rx.Matches(body).Select(m => m.Value).Distinct());

        return body;
    }

    [GeneratedRegex("{.*}")]
    private static partial Regex MergeFieldRx();
}