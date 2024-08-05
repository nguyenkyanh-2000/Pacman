namespace Pacman;

public interface ISubject
{
    void AttachObserver(IObserver observer);
    void DetachObserver(IObserver observer);
    void NotifyObserversThatPelletEaten(Pellet pellet);
    void NotifyObserversThatPowerPelletEaten(PowerPellet powerPellet);
    void NotifyObserversThatGhostCollided(Ghost ghost);
}