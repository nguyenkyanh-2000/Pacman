using System.Drawing;

namespace Pacman.ghostStrategies;

public interface IGhostStrategy
{
    public Point GetChaseTargetPosition();
    public Point GetScatterTargetPosition();
}