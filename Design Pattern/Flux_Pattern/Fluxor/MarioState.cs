using Fluxor;
namespace Flux_Pattern.Fluxor;

public enum State
{
    SMALL,
    SUPER,
    FIRE,
    CAPE,
}

[FeatureState]
public class MarioState
{
    public int Score { get; } = 0;
    public State CurrentState { get; } = State.SMALL;

    private MarioState() { }

    public MarioState(int score, State state)
    {
        Score = score;
        CurrentState = state;
    }
}