using System;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json.Linq;

namespace CSharp6Demo
{
    public class PointCSharp5
    {
        private readonly int _x;
        private readonly int _y;

        public int X { get { return _x; } } // immutable getter
        public int Y { get { return _y; } } // immutable getter

        public PointCSharp5(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            return String.Format("({0},{1})", X, Y); // String formatting
        }

        public double Distance
        {
            get { return Math.Sqrt(X * X + Y * Y); }
        }

        public static PointCSharp5 operator +(PointCSharp5 p1, PointCSharp5 p2)
        {
            return new PointCSharp5(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static PointCSharp5 operator -(PointCSharp5 p1, PointCSharp5 p2)
        {
            return new PointCSharp5(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static PointCSharp5 FromJson(JObject json)
        {
            if (json == null ||
                json["x"] == null ||
                json["x"].Type != JTokenType.Integer ||
                json["y"] == null ||
                json["y"].Type != JTokenType.Integer)
            {
                throw new ArgumentException("The paramater is not shaped like a point", "json");
            }

            return new PointCSharp5((int)json["x"], (int)json["y"]);
        }

        public JObject ToJson()
        {
            var result = new JObject();
            result["x"] = X;
            result["y"] = Y;
            return result;
        }
    }
}