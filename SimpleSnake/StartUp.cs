namespace SimpleSnake
{
    using SimpleSnake.GameObjects;
    using SimpleSnake.GameObjects.Foods;
    using System.Collections.Generic;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

           
            Wall wall = new Wall(60 , 30);

            Food food = new FoodHash(wall);
            food.SetRandomPosition(new Queue<Point>());
            

        }
    }
}
