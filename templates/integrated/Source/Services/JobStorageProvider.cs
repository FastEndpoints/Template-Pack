using Dom;
using Order = MongoDB.Entities.Order;

namespace MyProject;

sealed class JobStorageProvider(DB db) : IJobStorageProvider<JobRecord>
{
    public bool DistributedJobProcessingEnabled => false;

    public async Task<ICollection<JobRecord>> GetNextBatchAsync(PendingJobSearchParams<JobRecord> p)
    {
        return await db.Find<JobRecord>()
                       .Match(p.Match)
                       .Sort(r => r.ID, Order.Ascending)
                       .Limit(p.Limit)
                       .ExecuteAsync(p.CancellationToken);
    }

    public Task MarkJobAsCompleteAsync(JobRecord r, CancellationToken ct)
    {
        return db.Update<JobRecord>()
                 .MatchID(r.ID)
                 .Modify(jr => jr.IsComplete, true)
                 .ExecuteAsync(ct);
    }

    public Task CancelJobAsync(Guid trackingId, CancellationToken ct)
    {
        return db.Update<JobRecord>()
                 .Match(r => r.TrackingID == trackingId)
                 .Modify(jr => jr.IsComplete, true)
                 .ExecuteAsync(ct);
    }

    public Task OnHandlerExecutionFailureAsync(JobRecord r, Exception exception, CancellationToken ct)
    {
        if (r.FailureCount > 100)
        {
            r.IsComplete = true;
            r.IsCancelled = true;
            r.CancelledOn = DateTime.UtcNow;
            r.FailureReason = exception.Message;

            return db.SaveAsync(r, cancellation: ct);
        }

        var retryOn = DateTime.UtcNow.AddMinutes(1);
        var expireOn = retryOn.AddHours(4);

        return db.Update<JobRecord>()
                 .MatchID(r.ID)
                 .Modify(jr => jr.FailureReason, exception.Message) //save exception msg
                 .Modify(b => b.Inc(jr => jr.FailureCount, 1))      //increment the failure count.
                 .Modify(jr => jr.ExecuteAfter, retryOn)            //slide the execute after to 1 min in the future.
                 .Modify(jr => jr.ExpireOn, expireOn)               //slide the expiry on to 4 hours from execute after time.
                 .ExecuteAsync(ct);
    }

    public Task PurgeStaleJobsAsync(StaleJobSearchParams<JobRecord> p)
        => db.DeleteAsync(p.Match, cancellation: p.CancellationToken);

    public Task StoreJobAsync(JobRecord r, CancellationToken ct)
        => db.SaveAsync(r, cancellation: ct);
}