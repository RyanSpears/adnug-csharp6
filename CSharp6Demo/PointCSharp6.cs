using System;
using Newtonsoft.Json.Linq;

namespace CSharp6Demo
{
    public class PointCSharp6
    {
        public int X { get; } // getter-only auto-property
        public int Y { get; } // getter-only auto-property

        public PointCSharp6(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"({X},{Y})"; // string interpolation

        public double Distance => Math.Sqrt(X* X + Y* Y); // expression body on property

        public static PointCSharp6 operator +(PointCSharp6 p1, PointCSharp6 p2) 
            => new PointCSharp6(p1.X + p2.X, p1.Y + p2.Y); // expression body on method

        public static PointCSharp6 operator -(PointCSharp6 p1, PointCSharp6 p2) 
            => new PointCSharp6(p1.X - p2.X, p1.Y - p2.Y); // expression body on method

        public static PointCSharp6 FromJson(JObject json)
        {
            if (json == null ||
                json["x"]?.Type != JTokenType.Integer || // null conditional operator
                json["y"]?.Type != JTokenType.Integer)
            {
                throw new ArgumentException("The paramater is not shaped like a point", nameof(json)); // nameof expression
            }

            return new PointCSharp6((int)json["x"], (int)json["y"]);
        }
    }
}