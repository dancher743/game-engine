using GameEngine.Core;

namespace GameEngine
{
    public static class Engine
    {
        public static int FrameRate { get; set; } = -1;

        public static void Run()
        {
            GameLoop.Run(FrameRate);
        }
    }
}
