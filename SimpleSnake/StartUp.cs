namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using SimpleSnake.GameObjects.Foods;
    using System.Collections.Generic;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            Wall wall = new Wall(60, 20);
            Food food = new FoodAsterisk(wall);

            Snake snake = new Snake(wall);


            Engine engine = new Engine(wall, snake);
            engine.Run();
            
           
            



        }
    }
}
