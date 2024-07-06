namespace Pacman;

public interface ISubject
{
    void AttachObserver(IObserver observer);
    void DetachObserver(IObserver observer);
    void NotifyObserversThatPelletEaten();
    void NotifyObserversThatEnergizedPelletEaten();
    void NotifyObserversThatGhostCollided();
}