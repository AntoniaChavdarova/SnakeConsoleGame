using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char WallSymbol = '\u25A0';
        public Wall(int leftX, int topY) : base(leftX, topY)
        {
            this.InitializeWallBorders();
        }
        
        public bool IsPointOfWall(Point snake)
        {
            return snake.TopY == 0 || snake.LeftX == 00 ||
                (snake.LeftX == this.LeftX - 1) || snake.TopY == this.TopY;
        }

        private void InitializeWallBorders()
        {
            this.SetHorizontalLine(0);
            this.SetHorizontalLine(this.TopY - 1);
            this.SetVerticalLine(0);
            this.SetVerticalLine(this.LeftX);
        }
        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX <this.LeftX ; leftX++)
            {
                this.Draw(leftX, topY, WallSymbol);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, WallSymbol);
            }
        }
    }
}
