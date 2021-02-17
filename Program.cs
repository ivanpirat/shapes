using System;

namespace net
{
    class Program
    {
        static void Main(string[] args)
        {
            var shape1 = new Box();
            shape1.size(6);
            shape1.Render();
            shape1.info();
            var shape2 = new Rectangle();
            shape2.size(9, 4);
            shape2.Render();
            shape2.info();
            var shape3 = new Circle();
            shape3.size(55);
            shape3.Render();
            shape3.info();
        }
    }
    public class Shape
    {
        public int width { get; set; }
        public int height { get; set; }
        public string getType
        {
            get
            {
                if (width == height && width > 0 && height > 0)
                {
                    return "квадрат";
                }
                if (width != height && width > 0 && height > 0)
                {
                    return "прямоугольник";
                }
                if (radius > 0)
                {
                    return "круг";
                }
                return "";
            }

        }
        public double radius { get; set; }

        public void Render()
        {
            static void RenderSquareAndRectangle(int height, int width)
            {

                char[,] mas = new char[height, width];
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        mas[j, i] = '1';
                        if (j == 0 || i == 0 || i == width - 1)
                        {
                            Console.Write("*");
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                    }
                    Console.Write("*\n");
                }

            }
            static void circle(double radius)
            {
                radius = radius / 10;
                double thickness = 0.4;
                char symbol = '.';


                double rIn = radius - thickness, rOut = radius + thickness;

                for (double y = radius; y >= -radius; --y)
                {
                    for (double x = -radius; x < rOut; x += 0.5)
                    {
                        double value = x * x + y * y;
                        if (value >= rIn * rIn && value <= rOut * rOut)
                        {
                            Console.Write(symbol);
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();

                }
            }


            switch (getType)
            {
                case "квадрат":
                    RenderSquareAndRectangle(height, width);
                    break;
                case "прямоугольник":
                    RenderSquareAndRectangle(height, width);
                    break;
                case "круг":
                    circle(radius);
                    break;
                default:
                    Console.WriteLine("нет такой фигуры");
                    break;
            }
        }



    }
    public class Quadrilateral : Shape
    {
        public int getPerimeter
        {
            get
            {
                return 2 * (height + width);
            }
        }
        public int getSquare
        {
            get
            {
                return height * width;
            }
        }
        public void info()
        {
            Console.Write($"{getType}\n");
            Console.Write($" высота {height}, ширина  {width}\n");
            Console.Write($" периметр {getType} = {getPerimeter}\n");
            Console.Write($" площадь  {getType} = {getSquare}\n");
            Console.Write(" \n");
        }

    }
    public class Box : Quadrilateral
    {
        public void size(int x)
        {
            this.height = x;
            this.width = x;
        }
        public void calculation()
        {

        }

    }
    public class Rectangle : Quadrilateral
    {
        public void size(int y, int x)
        {
            this.height = y;
            this.width = x;

        }
    }
    public class Circle : Shape
    {
        public void size(double r)
        {
            this.radius = r;

        }
        public double getPerimeter
        {
            get
            {
                return Math.Round(2 * Math.PI * radius, 2);
            }
        }
        public double getSquare
        {
            get
            {
                 return Math.Round(Math.PI * Math.Pow(radius, 2), 2);
                
            }
        }
        public double getDiamet
        {
            get
            {
               return 2 * radius;
            }
        }
        public void info()
        {
            Console.Write($"{getType}\n");
            Console.Write($" диаметр  {getDiamet}, радиус {radius}\n");
            Console.Write($" периметр {getType} = {getPerimeter}\n");
            Console.Write($" площадь  {getType} = {getSquare}\n");
            Console.Write(" \n");
        }

    }
}
