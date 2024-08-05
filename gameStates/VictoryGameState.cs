using SplashKitSDK;

namespace Pacman;

public class VictoryGameState: GameState
{
    public VictoryGameState(GameStateManager gameStateManager): base(gameStateManager) 
    {
    }

    public override void Initialize()
    {
        SplashKit.FillRectangle(Color.Black, 0, 0, ProgramConfig.ScreenWidth, ProgramConfig.ScreenHeight);
        
        SplashKit.DrawText("VICTORY", Color.Green, ProgramConfig.GameFont, 50, 100, 100);
        
        PlayGameState playGameState = (PlayGameState) GameStateManager.GetState(GameStateManager.PLAYGAME);
        int score = playGameState.Score;
        
        SplashKit.DrawText("My total score is " + score, Color.White, ProgramConfig.GameFont, 15, 100, 200);
        SplashKit.DrawText("Press R to replay", Color.White, ProgramConfig.GameFont, 15, 100, 250);

        Game.IsOver = true;
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
    }
}