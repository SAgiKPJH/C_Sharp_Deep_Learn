namespace State_Pattern.분기판단;

public enum State
{
    SMALL,
    SUPER,
    FIRE,
    CAPE,
}

public class MarioStateMachine
{
    public int Score { get; private set; }
    public State CurrentState { get; private set; }

    public MarioStateMachine()
    {
        Score = 0;
        CurrentState = State.SMALL;
    }

    public void ObtainMushRoom()
    {
        if (CurrentState is State.SMALL)
        {
            CurrentState = State.SUPER;
            Score += 100;
        }
    }

    public void ObtainCape()
    {
        if (CurrentState is State.SMALL || CurrentState is State.SUPER)
        {
            CurrentState = State.CAPE;
            Score += 200;
        }
    }

    //...
}