public class RespawnActivity : LevelStateKeeper
{
    private bool _startActivity;
    private void Start()
    {
        _startActivity = gameObject.activeSelf;
    }

    protected override void RestoreState()
    {
        base.RestoreState();
        gameObject.SetActive(_startActivity);
    }
}