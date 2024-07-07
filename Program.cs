using SplashKitSDK;

namespace Pacman
{
    public class Program
    {
        static void Main()
        {

            Window window = new Window("Pacman", ProgramConfig.ScreenWidth, ProgramConfig.ScreenHeight);
            SplashKit.LoadFont(ProgramConfig.GameFont, "PressStart2P-Regular.ttf");
            Game game = new Game();

            do
            {
                SplashKit.ProcessEvents();
                
                game.HandleInput();
                game.Update();
                game.Draw();
                
                SplashKit.RefreshScreen(60);
            } while (!window.CloseRequested && game.IsRunning);
        }
    }
}