using Dom;
using Order = MongoDB.Entities.Order;

namespace MyProject;

sealed class JobStorageProvider : IJobStorageProvider<JobRecord>
{
    public async Task<IEnumerable<JobRecord>> GetNextBatchAsync(PendingJobSearchParams<JobRecord> p)
    {
        return await DB.Find<JobRecord>()
                       .Match(p.Match)
                       .Sort(r => r.ID, Order.Ascending)
                       .Limit(p.Limit)
                       .ExecuteAsync(p.CancellationToken);
    }

    public Task MarkJobAsCompleteAsync(JobRecord r, CancellationToken ct)
    {
        return DB.Update<JobRecord>()
                 .MatchID(r.ID)
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

            return r.SaveAsync(cancellation: ct);
        }

        var retryOn = DateTime.UtcNow.AddMinutes(1);
        var expireOn = retryOn.AddHours(4);

        return DB.Update<JobRecord>()
                 .MatchID(r.ID)
                 .Modify(jr => jr.FailureReason, exception.Message) //save exception msg
                 .Modify(b => b.Inc(jr => jr.FailureCount, 1))      //increment the failure count.
                 .Modify(jr => jr.ExecuteAfter, retryOn)            //slide the execute after to 1 min in future.
                 .Modify(jr => jr.ExpireOn, expireOn)               //slide the expire on to 4 hours from execute after time.
                 .ExecuteAsync(ct);
    }

    public Task PurgeStaleJobsAsync(StaleJobSearchParams<JobRecord> p)
        => DB.DeleteAsync(p.Match, cancellation: p.CancellationToken);

    public Task StoreJobAsync(JobRecord r, CancellationToken ct)
        => r.SaveAsync(cancellation: ct);
}