namespace Flux_Pattern.Normal_Flux;

public enum State
{
    SMALL,
    SUPER,
    FIRE,
    CAPE,
}

public class MarioStore
{
    public int Score {  get; private set; }
    public State CurrentState { get; private set; }
    public event Action<MarioStore> ScoreChanged = default!;
    public static MarioStore Instance { get; } = new MarioStore(0, State.SMALL);

    public MarioStore(int score, State state)
    {
        Score = score;
        CurrentState = state;
    }

    public void SetMarioState(MarioStore marioStore)
    {
        Score = marioStore.Score;
        CurrentState = marioStore.CurrentState;
        ScoreChanged?.Invoke(marioStore);
    }
}