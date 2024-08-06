using System.Drawing;

namespace Pacman;

public class Utils
{
    public static int DistanceBetween(Point a, Point b)
    {
        return (int) Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
    }
    
    public static int ManhattanDistanceBetween(Point a, Point b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }
    
    public static string BuildPath(string path)
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        return Path.Combine(currentDirectory, path);
    }
}