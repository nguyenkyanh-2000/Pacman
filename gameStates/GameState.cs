namespace Pacman;

public abstract class GameState
{
    protected GameStateManager GameStateManager;
    
    public GameState(GameStateManager gameStateManager)
    {
        GameStateManager = gameStateManager;
    }

    public abstract void Initialize();
    
    public abstract void Exit();
    
    public abstract void Draw();
    public abstract void Update();
    public abstract void HandleInput();
}