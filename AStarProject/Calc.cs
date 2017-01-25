using System;

namespace AStarProject
{
    internal class Calc
    {
        public static int GetDistance(int x1, int y1, int x2, int y2, bool allowDiagonal = true) {
            var distanceX = Math.Abs(x1 - x2);
            var distanceY = Math.Abs(y1 - y2);
            if (allowDiagonal) {
                var min = Math.Min(distanceX, distanceY);
                var max = Math.Max(distanceX, distanceY);
                return (14 * min) + (10 * (max - min));
            } else {
                return (10 * distanceX) + (10 * distanceY);
            }
        }

        public static int GetDistance(asTile tileA, asTile tileB, bool allowDiagonal = true) {
            return GetDistance(tileA.X, tileA.Y, tileB.X, tileB.Y, allowDiagonal);
        }
    }
}