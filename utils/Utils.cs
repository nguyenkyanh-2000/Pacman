using System.Drawing;

namespace Pacman;

public  class Utils
{
    public static int DistanceBetween(Point a, Point b)
    {
        return (int) Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
    }
}