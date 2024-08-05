namespace Pacman;

public interface IObserver
{
    void UpdateWhenPelletEaten(Pellet pellet);
    void UpdateWhenPowerPelletEaten(PowerPellet powerPellet);
    void UpdateWhenGhostCollided(Ghost ghost);
}