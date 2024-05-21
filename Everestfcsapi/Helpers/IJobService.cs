namespace Everestfcsapi.Helpers
{
    public interface IJobService
    {
        void FireAndForgetJob();
        void ReccuringJob();
        void DelayedJob();
        void ContinuationJob();
    }
}
