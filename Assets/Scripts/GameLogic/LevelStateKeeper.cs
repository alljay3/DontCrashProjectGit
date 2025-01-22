using UnityEngine;
using Zenject;

public abstract class LevelStateKeeper : MonoBehaviour
{
    protected Level _level;
    [Inject]
    private void Construct(Level level)
    {
        _level = level;
        _level.OnLevelRestartState += RestoreState;
        _level.OnLevelStart += OnStart;
    }

    protected virtual void RestoreState()
    {
    }
    protected virtual void OnStart()
    {
    }

    private void OnDestroy()
    {
        if (_level != null)
        {
            _level.OnLevelRestartState -= RestoreState;
            _level.OnLevelStart -= OnStart;
        }
    }
}
