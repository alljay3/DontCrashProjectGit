using Assets.Scripts.GameLogic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Level : MonoBehaviour
{
    public enum LevelState
    {
        NotStarted, 
        Playing,    
        Finished,
        GameOver,
        Restarting, 
        Pause    
    }

    private GamePause _gamePause;
    private InputSystem_Actions _inputActions;
    private LevelState _currentLevelState = LevelState.NotStarted;

    public event Action OnLevelRestartState;
    public event Action OnLevelStart;
    public event Action OnGameOver;
    public event Action OnLevelFinish;

    public LevelState CurrentLevelState
    {
        get { return _currentLevelState; }
        private set { _currentLevelState = value; }
    }
    [Inject]
    public void Construct(GamePause gamePause, InputSystem_Actions inputActions)
    {
        _gamePause = gamePause;
        _inputActions = inputActions;

        Init();
    }

    private void Init()
    {
        _inputActions.Player.Restart.started += OnRestartButtomPressed;
    }

    private void Start()
    {
        StartLevel();
    }
    private void OnRestartButtomPressed(InputAction.CallbackContext context)
    {
        RestartLevel();
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
        _gamePause.RequestPause();
        CurrentLevelState = LevelState.GameOver;
    }
    public void StartLevel()
    {
        OnLevelStart?.Invoke();
        CurrentLevelState = LevelState.Playing;
    }

    public void FinishLevel() { 
        OnLevelFinish?.Invoke();
        CurrentLevelState = LevelState.Finished;
        Debug.Log("YouWin");
    }
    public void RestartLevel()
    {
        CurrentLevelState = LevelState.Restarting;
        OnLevelRestartState?.Invoke();
        _gamePause.ReleasePause();
        StartLevel();

    }
}
