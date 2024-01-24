namespace GameEngine.Core
{
    internal static class GameLoop
    {
        private static Thread? executionThread;

        internal static void Run()
        {
            executionThread = new Thread(Execute);
            executionThread.Start();
        }

        private static void Execute()
        {
            while (true)
            {
                Console.WriteLine("Game loop thread is executing!");
            }
        }
    }
}
