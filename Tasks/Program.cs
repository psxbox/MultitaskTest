Console.WriteLine("Runnnig tasks");
List<Task> tasks = new List<Task>();

for (int i = 0; i < 1000; i++)
{
    int t = i + 1;
    var cts = new CancellationTokenSource();
    var task = Task.Run(() => TestTask(t, cts.Token));
    tasks.Add(task);
}

Console.WriteLine("Task start complete");
Task.WaitAll(tasks.ToArray());

static async Task TestTask(object? obj, CancellationToken cancellationToken)
{
    await Task.Delay(Random.Shared.Next(1000, 25000), cancellationToken);
    Console.WriteLine($"Thread {obj} completed!");
}