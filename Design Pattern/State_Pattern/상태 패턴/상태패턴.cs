namespace State_Pattern.상태_패턴;

public enum State
{
    SMALL,
    SUPER,
    FIRE,
    CAPE,
}

public interface IMario
{
    State GetName();
    void ObtainMushRoom();
    void ObtainCape();
    // void ObtainFire();
    // void MeetMonster();
}

public class MarioStateMachine
{
    public int Score { get; private set; }
    public IMario CurrentState { get; private set; }

    public MarioStateMachine()
    {
        Score = 0;
        CurrentState = new SmallMario(this);
    }

    public State GetCurrentState() => CurrentState.GetName();

    public void SetCurrentState(IMario mario) => CurrentState = mario;
    public void SetScore(int score) => Score = score;

    public void ObtainMushRoom() => CurrentState.ObtainMushRoom();
    public void ObtainCape() => CurrentState.ObtainCape();
}

public class SmallMario : IMario
{
    private readonly MarioStateMachine _stateMachine;

    public SmallMario(MarioStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public State GetName() => State.SMALL;

    public void ObtainMushRoom()
    {
        _stateMachine.SetCurrentState(new SuperMario(_stateMachine));
        _stateMachine.SetScore(_stateMachine.Score + 100);
    }

    public void ObtainCape()
    {
        _stateMachine.SetCurrentState(new CapeMario(_stateMachine));
        _stateMachine.SetScore(_stateMachine.Score + 200);
    }

    // ...
}