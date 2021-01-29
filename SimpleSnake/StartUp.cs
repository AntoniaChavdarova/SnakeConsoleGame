namespace SimpleSnake
{
    using SimpleSnake.GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Point point = new Point(0, 0);

            point.Draw('@');

        }
    }
}
