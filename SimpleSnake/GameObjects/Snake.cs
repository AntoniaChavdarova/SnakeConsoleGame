using SimpleSnake.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake 
    {
        private const char SnakeSymbol = '\u25CF';

        private readonly Queue<Point> snakeElements;
        private readonly Food[] foods;
        private readonly Wall wall;

        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeElements = new Queue<Point>();
            this.foods = new Food[3];
            this.foodIndex = this.RandomFoodNumber;
            this.GetFoods();
            this.CreateSnake();
           

        }

        public int TotalPoints { get; set; }
        private int RandomFoodNumber => new Random().Next(0, this.foods.Length);

        private void CreateSnake()
        {
            for (int i = 1; i <= 6; i++)
            {
                this.snakeElements.Enqueue(new Point(2, i));
            }
        }

        private void GetFoods()
        {
            this.foods[0] = new FoodHash(this.wall);
            this.foods[1] = new FoodDollar(this.wall);
            this.foods[2] = new FoodAsterisk(this.wall);
        }

        public bool IsMoving(Point direction)
        {
            Point currSnakeHead = this.snakeElements.Last();

            this.GetNextPoint(direction, currSnakeHead);

            bool isPointOfSnake = this.snakeElements.Any(x => x.LeftX == this.nextLeftX && x.TopY == this.nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);

            if (this.wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            if (this.foods[this.foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, currSnakeHead);
            }

            this.snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(SnakeSymbol);
            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(' ');



            return true;
        }

        private void Eat(Point direction, Point currSnakeHead)
        {
            this.TotalPoints += this.foods[this.foodIndex].FoodPoints;
            int length = this.foods[this.foodIndex].FoodPoints;
            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                GetNextPoint(direction, currSnakeHead);
            }

            this.foodIndex = this.RandomFoodNumber;
            this.foods[this.foodIndex].SetRandomPosition(this.snakeElements);
        }

        private void GetNextPoint(Point direction, Point currSnakeHead)
        {
            this.nextLeftX = currSnakeHead.LeftX + direction.LeftX;
            this.nextTopY = currSnakeHead.TopY + direction.TopY;
        }
    }
}
