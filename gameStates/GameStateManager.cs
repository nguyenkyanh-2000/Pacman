namespace Pacman;

public class GameStateManager
{
    private static GameStateManager? _instance;
    private Stack<GameState> _gameStates;

    private GameState MenuGameState;
    private GameState PlayGameState;
    private GameState PauseGameState;
    private GameState GameOverState;

    public const int MENU = 0;
    public const int PLAYGAME = 1;
    public const int PAUSE = 2;
    public const int GAMEOVER = 3;
    
    
    private GameStateManager()
    {
        _gameStates = new Stack<GameState>();
        MenuGameState = new MenuGameState(this);
        PlayGameState = new PlayGameState(this);
        PauseGameState = new PauseGameState(this);
        GameOverState = new GameOverState(this);
        PushState(MenuGameState);
    }
    
    public static GameStateManager Instance()
    {
        if (_instance == null)
        {
            _instance = new GameStateManager();
        }
        return _instance;
    }

    public GameState GetState(int state)
    {
        switch (state)
        {
            case MENU:
                return MenuGameState;
            case PLAYGAME:
                return PlayGameState;
            case PAUSE:
                return PauseGameState;
            case GAMEOVER:
                return GameOverState;
            default:
                return MenuGameState;
        }
    }
    
    public GameState CurrentState()
    {
        
        return _gameStates.Peek();
    }
    
    public void PushState(GameState state)
    {
        _gameStates.Push(state);
        _gameStates.Peek().Initialize();
    }
    
    public void PopState()
    {
        _gameStates.Peek().Exit();
        _gameStates.Pop();
    }
    
    public void ClearStates(){
        _gameStates.Clear();
    }
    
    public void ChangeStateInto(int state)
    {
        if (_gameStates.Count > 0)
        {
            _gameStates.Peek().Exit();
            _gameStates.Pop();
        }
        
        switch (state)
        {
            case MENU:
                PushState(MenuGameState);
                break;
            case PLAYGAME:
                PushState(PlayGameState);
                break;
            case PAUSE:
                PushState(PauseGameState);
                break;
            case GAMEOVER:
                PushState(GameOverState);
                break;
        }
    }
 
    
    public void Update()
    {
        if (_gameStates.Count > 0)
        {
            _gameStates.Peek().Update();
        }
    }

    public void Draw()
    {
       if (_gameStates.Count > 0)
       {
           _gameStates.Peek().Draw();
       }
    }
    
    public void HandleInput()
    {
        if (_gameStates.Count > 0)
        {
            _gameStates.Peek().HandleInput();
        }
    }
}