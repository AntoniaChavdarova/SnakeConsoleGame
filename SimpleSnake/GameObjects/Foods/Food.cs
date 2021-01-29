using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private readonly Wall wall;
        private readonly char foodSymbol;
        private readonly Random random;
        public Food(Wall wall , char foodSymbol , int points) : base(wall.LeftX , wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            this.FoodPoints = points;

            this.random = new Random();

        }

        public int FoodPoints { get; set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            bool isPointOfSnake = true;

            while (isPointOfSnake)
            {
                this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
                this.TopY = this.random.Next(2, this.wall.TopY - 2);

                isPointOfSnake = snakeElements
                    .Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;

        }

        public bool IsFoodPoint(Point snake)
        =>  snake.LeftX == this.LeftX && snake.TopY == this.TopY;
        
    }
}
