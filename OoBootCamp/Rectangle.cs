/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */
 
namespace OoBootCamp
{
    // Understands a 4-sided polygon with sides at right angles
    public class Rectangle
    {
        private readonly double _width;
        private readonly double _height;

        public Rectangle(double width, double height)
        {
            _width = width;
            _height = height;
        }

        public double Area()
        {
            return _height * _width;
        }
    }
}
