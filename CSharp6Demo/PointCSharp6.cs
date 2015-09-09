using System;
using Newtonsoft.Json.Linq;

using static System.Math; // using static members

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

        public double Distance => Sqrt(X * X + Y * Y); // expression-bodied properties

        public static PointCSharp6 operator +(PointCSharp6 p1, PointCSharp6 p2)
            => new PointCSharp6(p1.X + p2.X, p1.Y + p2.Y); // expression-bodied method

        public static PointCSharp6 operator -(PointCSharp6 p1, PointCSharp6 p2)
            => new PointCSharp6(p1.X - p2.X, p1.Y - p2.Y); // expression-bodied method

        public static PointCSharp6 FromJson(JObject json)
        {
            if (json == null ||
                json["x"]?.Type != JTokenType.Integer || // null conditional operators
                json["y"]?.Type != JTokenType.Integer)
            {
                throw new ArgumentException("The paramater is not shaped like a point", nameof(json)); // nameof expression
            }

            return new PointCSharp6((int)json["x"], (int)json["y"]);
        }

        public JObject ToJson() // index initializers
        {
            return new JObject { ["x"] = X, ["y"] = Y };
        }
    }
}