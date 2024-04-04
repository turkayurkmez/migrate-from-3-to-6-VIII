using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp10NewFeatures
{
    public struct Point
    {
        public int X { get; init; }
        public int Y { get; init; }

        public Point()
        {
            X = 0;
            Y = 0;
        }
    }

    public record struct PointRecordStruct(int X, int Y);

    public record struct Address(string City, string Street, string Country);



}
