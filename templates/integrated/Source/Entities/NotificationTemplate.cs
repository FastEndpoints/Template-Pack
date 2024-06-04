using MongoDB.Bson.Serialization.Attributes;

namespace Dom;

sealed class NotificationTemplate : IEntity
{
    [BsonId]
    public string ID { get; init; } //set the template name as id

    public string SmsBody { get; init; }
    public string EmailSubject { get; init; }
    public string EmailBody { get; init; }

    public object GenerateNewID()
        => ID; //because we're setting the ID manually

    public bool HasDefaultID()
        => !string.IsNullOrEmpty(ID);
}