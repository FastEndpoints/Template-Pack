using MessagePack;

namespace Dom;

sealed class JobRecord : Entity, IJobStorageRecord
{
    public string QueueID { get; set; }
    public DateTime ExecuteAfter { get; set; }
    public DateTime ExpireOn { get; set; }
    public bool IsComplete { get; set; }
    public int FailureCount { get; set; }

    [IgnoreDefault]
    public string? FailureReason { get; set; }

    [IgnoreDefault]
    public bool? IsCancelled { get; set; }

    [IgnoreDefault]
    public DateTime? CancelledOn { get; set; }

    static JobRecord()
    {
        MessagePackSerializer.DefaultOptions = MessagePack.Resolvers.ContractlessStandardResolver.Options;
        _ = DB.Index<JobRecord>()
              .Key(r => r.QueueID, KeyType.Ascending)
              .Key(r => r.IsComplete, KeyType.Ascending)
              .Key(r => r.ExecuteAfter, KeyType.Ascending)
              .Key(r => r.ExpireOn, KeyType.Ascending)
              .CreateAsync(); //covers job storage provider's GetNextBatchAsync query
    }

    public byte[] CommandMsgPack { get; set; }

    TCommand IJobStorageRecord.GetCommand<TCommand>()
        => MessagePackSerializer.Deserialize<TCommand>(CommandMsgPack);

    void IJobStorageRecord.SetCommand<TCommand>(TCommand command)
        => CommandMsgPack = MessagePackSerializer.Serialize(command);

    [Ignore]
    public object Command { get; set; }
}