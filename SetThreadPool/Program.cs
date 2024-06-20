// Set the minimum number of worker threads and I/O completion threads
ThreadPool.SetMinThreads(workerThreads: 100, completionPortThreads: 100);

// Set the maximum number of worker threads and I/O completion threads
ThreadPool.SetMaxThreads(workerThreads: 1000, completionPortThreads: 1000);

// Display the current thread pool settings
ThreadPool.GetMinThreads(out int minWorkerThreads, out int minCompletionPortThreads);
ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int maxCompletionPortThreads);

Console.WriteLine($"Min Worker Threads: {minWorkerThreads}");
Console.WriteLine($"Min Completion Port Threads: {minCompletionPortThreads}");
Console.WriteLine($"Max Worker Threads: {maxWorkerThreads}");
Console.WriteLine($"Max Completion Port Threads: {maxCompletionPortThreads}");
