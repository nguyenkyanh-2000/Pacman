namespace Pacman;

public class Game
{
    public bool IsRunning { get; set; } = true;
    private GameStateManager _gameStateManager;
    
    public Game()
    {
        _gameStateManager = GameStateManager.Instance();
    }

    public void Draw()
    {
        _gameStateManager.Draw();
    }

    public void Update()
    {
        _gameStateManager.Update();
    }

    public void HandleInput()
    {
        _gameStateManager.HandleInput();
    }
}