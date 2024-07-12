using System.Drawing;

namespace Pacman;

public interface IGhostStrategy
{
    public Point GetChaseTargetPosition();
    public Point GetScatterTargetPosition();
}