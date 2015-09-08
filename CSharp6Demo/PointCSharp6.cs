using System;
using Newtonsoft.Json.Linq;

namespace CSharp6Demo
{
    public class Point
    {
        public int X { get; } // getter-only auto-property
        public int Y { get; } // getter-only auto-property

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"({X},{Y})"; // string interpolation

        public double Distance => Math.Sqrt(X* X + Y* Y); // expression body on property

        public static Point operator +(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y); // expression body on method

        public static Point operator -(Point p1, Point p2) => new Point(p1.X - p2.X, p1.Y - p2.Y); // expression body on method

        public static Point FromJson(JObject json)
        {
            if (json == null ||
                json["x"]?.Type != JTokenType.Integer || // null conditional operator
                json["y"]?.Type != JTokenType.Integer)
            {
                throw new ArgumentException("The paramater is not shaped like a point", nameof(json)); // nameof expression
            }

            return new Point((int)json["x"], (int)json["y"]);
        }
    }
}