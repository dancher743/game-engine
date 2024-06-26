using System.Diagnostics;

namespace GameEngine.Core
{
    internal static class GameLoop
    {
        private static int frameRate;
        private static float frameBudget;

        private static Thread? executionThread;

        internal static void Run(int frameRate)
        {
            GameLoop.frameRate = frameRate;
            frameBudget = frameRate == -1 ? -1f : 1f / frameRate;

            executionThread = new Thread(Execute);
            executionThread.Start();
        }

        private static void Execute()
        {
            double frameBudgetInMilliseconds = frameBudget * 1000f;

            double elapsedTime = 0f;
            var frameCount = 0;

            var stopWatch = new Stopwatch();

            while (true)
            {
                stopWatch.Start();
                HandleLogic();
                stopWatch.Stop();

                var deltaTime = stopWatch.Elapsed.TotalMilliseconds;

                // Console.WriteLine(deltaTime);
                // Console.WriteLine(stopWatch.ElapsedMilliseconds);
                // Console.WriteLine(frameBudgetInMilliseconds);
                // Console.ReadLine();

                double sleepTime = 0;

                if (deltaTime < frameBudgetInMilliseconds)
                {
                    sleepTime = frameBudgetInMilliseconds - deltaTime;
                    //Console.WriteLine("Sleep a little bit: " + sleepTime);
                    Thread.Sleep(TimeSpan.FromMilliseconds(sleepTime));
                }

                elapsedTime += deltaTime + sleepTime;
                frameCount++;

                if (frameCount == frameRate || frameRate == -1f)
                {
                    Console.WriteLine(frameCount);
                    Console.WriteLine(elapsedTime / 1000f);
                    frameCount = 0;
                    elapsedTime = 0f;
                }
            }
        }

        private static void HandleInput()
        {
        }

        private static void HandleLogic()
        {
            // Test code here.

            // Thread.Sleep(100);

            //for (int i = 0; i < 100000; i++)
            //{
            //    Math.Sqrt(100000);
            //}
        }

        private static void HandleRendering()
        {
        }
    }
}
