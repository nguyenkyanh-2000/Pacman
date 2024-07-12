using System.Drawing;
using SplashKitSDK;
using static Pacman.ProgramConfig;
using Color = SplashKitSDK.Color;

namespace Pacman;
public class PlayGameState : GameState, IObserver
{
    public List<Entity> Entities { get; } = [];
    private List<Ghost> Ghosts { get; } = [];
    public List<Wall> Walls { get; } = [];
    
    public static Pacman Pacman = null!;
    public static Ghost Blinky = null!;
    public static Ghost Clyde = null!;
    
    
    public int Score { get; set; } = 0;
    
    public PlayGameState(GameStateManager gameStateManager): base(gameStateManager)
    {
        
        // Reading the map from a file
        List<String> lines = File.ReadAllLines("resources/levels/level.txt").ToList();
        
        // Creating the entities
        GhostFactory ghostFactory;
        
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
                    Pacman = new Pacman(j * MapCellSize, i * MapCellSize);
                    Entities.Add(Pacman);
                    Pacman.CollisionDetector = new CollisionDetector(this);
                    Pacman.AttachObserver(this);
                }
                // Fill all empty spaces on the map with pellets
                if (lines[i][j] == ' ')
                {
                    Pellet pellet = new Pellet(j * MapCellSize, i * MapCellSize, MapCellSize / 5);
                    Entities.Add(pellet);
                }
                if (lines[i][j] == ';')
                {
                    PowerPellet powerPellet = new PowerPellet(j * MapCellSize, i * MapCellSize, MapCellSize);
                    Entities.Add(powerPellet);
                }
                
                if (lines[i][j] == 'b')
                {
                    ghostFactory = new BlinkyFactory();
                    Blinky= ghostFactory.CreateGhost(j * MapCellSize, i * MapCellSize);
                    Entities.Add(Blinky);
                    Ghosts.Add(Blinky);
                }
                
                if (lines[i][j] == 'c')
                {
                    ghostFactory = new ClydeFactory();
                    Clyde = ghostFactory.CreateGhost(j * MapCellSize, i * MapCellSize);
                    Entities.Add(Clyde);
                    Ghosts.Add(Clyde);
                }
                
                if (lines[i][j] == 'p')
                {
                    ghostFactory = new PinkyFactory();
                    Ghost pinky = ghostFactory.CreateGhost(j * MapCellSize, i * MapCellSize);
                    Entities.Add(pinky);
                    Ghosts.Add(pinky);
                }
                
                if (lines[i][j] == 'i')
                {
                    ghostFactory = new InkyFactory();
                    Ghost inky = ghostFactory.CreateGhost(j * MapCellSize, i * MapCellSize);
                    Entities.Add(inky);
                    Ghosts.Add(inky);
                }
            }
        }
        
        // Setting the collision detector for the ghosts
        Ghosts.ForEach(ghost => ghost.CollisionDetector = new CollisionDetector(this));
    }
    
    public override void Initialize()
    {
        SplashKit.ClearScreen(Color.Black);
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
        
        Pacman?.HandleInput();
    }

    public void UpdateWhenPelletEaten()
    {
        Score += 10;
    }

    public void UpdateWhenEnergizedPelletEaten()
    {
        Score += 50;
        Ghosts.ForEach(ghost =>
        {
            ghost.ToFrightenedMode();
        });
    }

    public void UpdateWhenGhostCollided()
    {
        GameStateManager.ChangeStateInto(GameStateManager.GAMEOVER);
    }
}