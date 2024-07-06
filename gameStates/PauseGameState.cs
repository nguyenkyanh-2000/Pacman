using SplashKitSDK;

namespace Pacman;

public class PauseGameState: GameState
{
    public PauseGameState(GameStateManager gameStateManager): base(gameStateManager) 
    {
        
    }

    public override void Initialize()
    {
        SplashKit.FillRectangle(Color.Black, 0, 0, ProgramConfig.ScreenWidth, ProgramConfig.ScreenHeight);
        SplashKit.DrawText("PAUSED", Color.Yellow, ProgramConfig.GameFont, 50, 100, 100);
        SplashKit.DrawText("Press Space again to return", Color.White, ProgramConfig.GameFont, 20, 100, 200);
    }

    public override void Exit()
    {
      
    }

    public override void Draw()
    {
      
    }

    public override void Update()
    {
        
    }

    public override void HandleInput()
    {
        if (SplashKit.KeyTyped(KeyCode.SpaceKey))
        {
            GameStateManager.ChangeStateInto(GameStateManager.PLAYGAME);
        }
    }
}