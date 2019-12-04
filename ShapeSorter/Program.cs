using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");
            Console.WriteLine("---------------");

            List<IShape> shapes = new List<IShape>()
            {
                new Circle(4),
                new Rectangle(3.2, 5.9),
                new Square(3),
                new Square(10),
                new Rectangle(2,3),
                new Circle(2),
                new Rectangle(10,10),
                new Circle(8)
            };
            Console.WriteLine("All shapes");
            foreach (IShape shape in shapes)
            {
                Console.WriteLine($"Shape with area {shape.Area}");
            }
            Console.WriteLine("---------------");

            IEnumerable<IShape> filteredShapes = shapes.Where(shape => shape.Area > 50);
            Console.WriteLine("Shapes with area > 50");
            foreach (IShape shape in filteredShapes)
            {
                Console.WriteLine($"Shape with area {shape.Area}");
            }
            Console.WriteLine("---------------");

            IEnumerable<Circle> circles = shapes.OfType<Circle>();
            Console.WriteLine("All circles");
            foreach (Circle circle in circles)
            {
                Console.WriteLine($"Circle with radius {circle.Radius} and area {circle.Area}");
            }
            Console.WriteLine("---------------");

            IEnumerable<Circle> filteredCircles = circles.Where(circle => circle.Area < 70);
            Console.WriteLine("Circles with area less than 70");
            foreach (Circle circle in filteredCircles)
            {
                Console.WriteLine($"Circle with radius {circle.Radius} and area {circle.Area}");
            }
            Console.WriteLine("---------------");

            Console.WriteLine("Combined example");
            foreach (Circle circle in shapes.OfType<Circle>().Where(c => c.Radius > 3.5))
            {
                Console.WriteLine($"Circle with radius {circle.Radius} and area {circle.Area}");
            }
            Console.WriteLine("---------------");

            Console.WriteLine("Group by type");
            var groupedShapes = shapes.GroupBy(shape => shape.GetType());
            foreach(var group in groupedShapes)
            {
                Console.WriteLine($"Shapes of type {group.Key.Name}");
                foreach(IShape shape in group)
                {
                    Console.WriteLine($"Shape of area {shape.Area}");
                }
            }
            Console.WriteLine("---------------");

            Console.WriteLine("Group by even/odd");
            var groupedByArea = shapes.GroupBy(shape => shape.Area % 2 == 0);
            foreach (var group in groupedByArea)
            {
                Console.WriteLine(group.Key ? "Even Areas": "Odd Areas");
                foreach (IShape shape in group)
                {
                    Console.WriteLine($"Shape of area {shape.Area}");
                }
            }
            Console.WriteLine("---------------");

            Console.WriteLine($"Maximum Area is {shapes.Max(shape => shape.Area)}");
            Console.WriteLine("---------------");

            Console.WriteLine($"Total Area is {shapes.Sum(shape => shape.Area)}");

            Console.ReadKey(true);
        }
    }
}
