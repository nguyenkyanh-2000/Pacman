namespace Pacman;

public interface IObserver
{
    void UpdateWhenPelletEaten();
    void UpdateWhenEnergizedPelletEaten();
    void UpdateWhenGhostCollided();
}