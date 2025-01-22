using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<InputSystem_Actions>().AsSingle();
        var inputActions = Container.Resolve<InputSystem_Actions>();
        inputActions.Enable();
    }

}
