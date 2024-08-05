using SplashKitSDK;

namespace Pacman;

public class Game
{
    private static Game? _instance;
    public static bool IsOver { get; set; } = false;
    public GameStateManager GameStateManager;
    
    private Game()
    {
        GameStateManager = new GameStateManager();
        GameStateManager.PushState(GameStateManager.GetState(GameStateManager.MENU));
    }
    
    public static Game Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Game();
            }
            return _instance;
        }
    }

    public void Draw()
    {
        GameStateManager.Draw();
    }

    public void Update()
    {
        GameStateManager.Update();
    }

    public void HandleInput()
    {
        if (IsOver)
        {
            if (SplashKit.KeyDown(KeyCode.RKey))
            {
                GameStateManager = new GameStateManager();
                GameStateManager.PushState(GameStateManager.GetState(GameStateManager.MENU));
                IsOver = false;
            }
        } 
        
        GameStateManager.HandleInput();
    }
}