using SplashKitSDK;

namespace Pacman;

public class MenuGameState : GameState
{
    public MenuGameState(GameStateManager gameStateManager): base(gameStateManager) 
    {
    }

    public override void Initialize()
    {
        SplashKit.FillRectangle(Color.Black, 0, 0, ProgramConfig.ScreenWidth, ProgramConfig.ScreenHeight);
        SplashKit.DrawText("PACMAN", Color.Yellow, ProgramConfig.GameFont, 50, 100, 100);
        SplashKit.DrawText("Press Enter to Start", Color.White, ProgramConfig.GameFont, 15, 100, (double) ProgramConfig.ScreenHeight/2);
        SplashKit.DrawText("Press ESC to Exit", Color.White, ProgramConfig.GameFont, 15, 100, (double) ProgramConfig.ScreenHeight/2 + 50);
        SplashKit.DrawText("Press Space to pause", Color.White, ProgramConfig.GameFont, 15, 100, (double) ProgramConfig.ScreenHeight/2 + 100);
        SplashKit.DrawText("Made by Ky Anh Nguyen", Color.Yellow, ProgramConfig.GameFont, 15, 100,  ProgramConfig.ScreenHeight - 100);
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
        if (SplashKit.KeyTyped(KeyCode.ReturnKey))
        {
            GameStateManager.ChangeStateInto(GameStateManager.PLAYGAME);
        }
        
        if (SplashKit.KeyTyped(KeyCode.EscapeKey))
        {
            Environment.Exit(0);
        }
    }
}
