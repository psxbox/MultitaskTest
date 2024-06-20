Console.WriteLine("Runnnig threads");

for (int i = 0; i < 500; i++)
{
    int t = i + 1;

    var th = new Thread(TestThread);
    th.Start(t);
}

Console.WriteLine("Threads start complete");

static void TestThread(object? obj)
{
    Thread.Sleep(10000);
    Console.WriteLine($"Thread {obj} completed!");
}