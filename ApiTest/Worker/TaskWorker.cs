
namespace ApiTest.Worker
{
    public class TaskWorker(ILogger<TaskWorker> logger) : IHostedService
    {
        SemaphoreSlim semaphoreSlim = new SemaphoreSlim(500, 500);

        public int Count => semaphoreSlim.CurrentCount;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Factory.StartNew(async () =>
            {
                int id = 1;

                while (!cancellationToken.IsCancellationRequested)
                {
                    await semaphoreSlim.WaitAsync(cancellationToken);
                    try
                    {
                        _ = Task.Run(() => TestTask(id++, cancellationToken), cancellationToken);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private async Task TestTask(object? obj, CancellationToken cancellationToken)
        {
            try
            {
                await Task.Delay(Random.Shared.Next(1000, 25000), cancellationToken);
                logger.LogInformation("Thread {obj} completed!", obj);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }
    }
}
