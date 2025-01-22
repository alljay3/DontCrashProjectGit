using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class AirplaneTrail : LevelStateKeeper
{

    private InputSystem_Actions _actions;
    private TrailRenderer _trailRenderer;

    private void Awake()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        _trailRenderer.emitting = false;
    }
    protected override void RestoreState()
    {
        base.RestoreState();
        _trailRenderer.Clear();
        gameObject.SetActive(false);
    }

    protected override void OnStart()
    {
        base.OnStart();
        gameObject.SetActive(true);
    }

    [Inject]
    public void Construct(InputSystem_Actions actions)
    {
        _actions = actions;
    }

    private void OnEnable()
    {
        _actions.Player.Gas.started += StartTrail;
        _actions.Player.Gas.canceled += StopTrail;
    }

    private void StopTrail(InputAction.CallbackContext context)
    {
        _trailRenderer.emitting = false;
    }

    private void StartTrail(InputAction.CallbackContext context)
    {
        _trailRenderer.emitting = true;
    }

    private void OnDisable()
    {
        _actions.Player.Gas.started -= StartTrail;
        _actions.Player.Gas.canceled -= StopTrail;
    }

}
