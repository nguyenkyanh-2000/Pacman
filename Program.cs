using SplashKitSDK;
namespace Pacman
{
    public class Program
    {
        static void Main()
        {

            Window window = new Window("Pacman", ProgramConfig.ScreenWidth, ProgramConfig.ScreenHeight);
            SplashKit.LoadFont(ProgramConfig.GameFont, Utils.BuildPath("resources/fonts/PressStart2P-Regular.ttf"));
            SplashKit.SetResourcesPath(Utils.BuildPath("resources"));
            Game game = Game.Instance;

            do
            {
                SplashKit.ProcessEvents();
                
                game.HandleInput();
                game.Update();
                game.Draw();
                
                
                SplashKit.RefreshScreen(60);
            } while (!window.CloseRequested);
        }
    }
}