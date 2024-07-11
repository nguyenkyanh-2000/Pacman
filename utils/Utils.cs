using System.Drawing;

namespace Pacman;

public  class Utils
{
    public static float DistanceBetween(PointF a, PointF b)
    {
        return (float) Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
    }
}