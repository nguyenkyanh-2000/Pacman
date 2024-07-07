using SplashKitSDK;
using static Pacman.ProgramConfig;
namespace Pacman;
public class PlayGameState : GameState, IObserver
{
    public List<Entity> Entities { get; } = [];
    public List<Wall> Walls { get; } = [];
    private Pacman? _pacman;

    public int Score { get; set; } = 0;
    
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
                    Wall wall = new Wall(j * MapCellSize, i * MapCellSize,  MapCellSize);
                    Entities.Add(wall);
                    Walls.Add(wall);
                }
                if (lines[i][j] == 'P')
                {
                    _pacman = new Pacman(j * MapCellSize, i * MapCellSize, pacmanSprite);
                    Entities.Add(_pacman);
                    _pacman.CollisionDetector = new CollisionDetector(this);
                    _pacman.AttachObserver(this);
                }
                if (lines[i][j] == '.')
                {
                    Pellet pellet = new Pellet(j * MapCellSize, i * MapCellSize, MapCellSize);
                    Entities.Add(pellet);
                }
                if (lines[i][j] == ';')
                {
                    PowerPellet powerPellet = new PowerPellet(j * MapCellSize, i * MapCellSize, MapCellSize);
                    Entities.Add(powerPellet);
                }
            }
        }
    }
    
    public override void Initialize()
    {
        SplashKit.FillRectangle(Color.Black, 0,0, ProgramConfig.ScreenWidth, ProgramConfig.ScreenHeight); 
    }

    public override void Exit()
    {
      
    }

    public override void Draw()
    {
        SplashKit.ClearScreen(Color.Black);
        Entities.ForEach(entity => entity.Draw());
        
    }

    public override void Update()
    {
       Entities.ForEach(entity => entity.Update());
    }

    public override void HandleInput()
    {
        if (SplashKit.KeyTyped(KeyCode.SpaceKey))
        {
            GameStateManager.ChangeStateInto(GameStateManager.PAUSE);
        }
        
        _pacman?.HandleInput();
    }

    public void UpdateWhenPelletEaten()
    {
        Score += 10;
        Console.WriteLine("Pellet eaten");
    }

    public void UpdateWhenEnergizedPelletEaten()
    {
        Score += 50;
        Console.WriteLine("Energized pellet eaten");
    }

    public void UpdateWhenGhostCollided()
    {
        
    }
}