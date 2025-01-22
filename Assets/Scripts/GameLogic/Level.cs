using Assets.Scripts.GameLogic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Level : MonoBehaviour
{
    private GamePause _gamePause;
    private InputSystem_Actions _inputActions;
    public event Action OnLevelRestartState;
    public event Action OnLevelStart;
    public event Action OnGameOver;

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

    private void OnRestartButtomPressed(InputAction.CallbackContext context)
    {
        RestartLevel();
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
        _gamePause.RequestPause();
    }
    public void StartLevel()
    {
        OnLevelStart?.Invoke();
    }

    public void RestartLevel()
    {
        OnLevelRestartState?.Invoke();
        _gamePause.ReleasePause();
        StartLevel();
    }
}
