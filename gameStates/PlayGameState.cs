using SplashKitSDK;
using static Pacman.ProgramConfig;
namespace Pacman;
public class PlayGameState : GameState
{
    public List<Entity> Entities { get; } = new();
    public List<Wall> Walls { get; } = new();
    private Pacman? _pacman;
    public PlayGameState(GameStateManager gameStateManager): base(gameStateManager)
    {
        
        // Reading the map from a file
        List<String> lines = File.ReadAllLines("resources/levels/level1.txt").ToList();
        
        // Loading the pacman sprite
        Bitmap pacmanBitmap = SplashKit.LoadBitmap("Pacman", "pacman.png");
        AnimationScript pacmanMovingScript = new AnimationScript("PacmanMovingScript", "pacman.txt");
        Sprite pacmanSprite = new Sprite("PacmanSprite", pacmanBitmap, pacmanMovingScript);
        pacmanBitmap.SetCellDetails(pacmanSprite.Width/16,pacmanSprite.Height, 16, 1, 16 );
        
        // Creating the entities
        
        for (int i = 0; i < lines.Count; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                if (lines[i][j] == '#')
                {
                    // Create a wall. NOTE: Size is smaller than map cell size to allow for better pacman movement
                    Wall wall = new Wall(j * MapCellSize, i * MapCellSize,  MapCellSize - 2);
                    Entities.Add(wall);
                    Walls.Add(wall);
                }
                if (lines[i][j] == 'P')
                {
                    _pacman = new Pacman(j * MapCellSize, i * MapCellSize, pacmanSprite);
                    Entities.Add(_pacman);
                    _pacman.CollisionDetector = new CollisionDetector(this);
                }
                if (lines[i][j] == '.')
                {
                    Pellet pellet = new Pellet(j * MapCellSize, i * MapCellSize, 5);
                    Entities.Add(pellet);
                }
                if (lines[i][j] == 'E')
                {
                    EnergizedPellet energizedPellet = new EnergizedPellet(j * MapCellSize, i * MapCellSize, 7.5f);
                    Entities.Add(energizedPellet);
                }
            }
        }
    }
    
    public override void Initialize()
    {
        SplashKit.FillRectangle(Color.White, 0,0, ProgramConfig.ScreenWidth, ProgramConfig.ScreenHeight); 
    }

    public override void Exit()
    {
      
    }

    public override void Draw()
    {
        SplashKit.ClearScreen(Color.White);
        foreach (Entity entity in Entities)
        {
            entity.Draw();
        }
        
    }

    public override void Update()
    {
        foreach (Entity entity in Entities)
        {
            entity.Update();
        }
    }

    public override void HandleInput()
    {
        if (SplashKit.KeyTyped(KeyCode.SpaceKey))
        {
            GameStateManager.ChangeStateInto(GameStateManager.PAUSE);
        }
        
        _pacman?.HandleInput();
    }
}