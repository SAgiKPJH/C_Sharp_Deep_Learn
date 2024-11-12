namespace State_Pattern.상태_패턴;

public class SuperMario : IMario
{
    private readonly MarioStateMachine _stateMachine;

    public SuperMario(MarioStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public State GetName() => State.SUPER;

    public void ObtainMushRoom() =>
        _stateMachine.SetScore(_stateMachine.Score + 100);

    public void ObtainCape()
    {
        _stateMachine.SetCurrentState(new CapeMario(_stateMachine));
        _stateMachine.SetScore(_stateMachine.Score + 200);
    }

    // ...
}
public class CapeMario : IMario
{
    private readonly MarioStateMachine _stateMachine;

    public CapeMario(MarioStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public State GetName() => State.CAPE;

    public void ObtainMushRoom() =>
        _stateMachine.SetScore(_stateMachine.Score + 100);

    public void ObtainCape() =>
        _stateMachine.SetScore(_stateMachine.Score + 200);

    // ...
}