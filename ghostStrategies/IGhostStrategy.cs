using System.Drawing;

namespace Pacman.ghostStrategies;

public interface IGhostStrategy
{
    public PointF GetChaseTargetPosition();
    public PointF GetScatterTargetPosition();
}