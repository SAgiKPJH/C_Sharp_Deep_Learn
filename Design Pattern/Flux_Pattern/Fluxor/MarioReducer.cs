using Fluxor;

namespace Flux_Pattern.Fluxor;

public class MarioReducer
{
    private static readonly int[,] _actionTable =
    {
        { +100, +200, +300,   +0 },
        {   +0, +200, +300, -100 },
        {   +0,   +0,    0, -200 },
        {   +0 ,  +0,    0, -300 }
    };

    private static readonly State[,] _transitionTable =
    {
        {State.SUPER, State.CAPE, State.FIRE, State.SMALL },
        {State.SUPER, State.CAPE, State.FIRE, State.SMALL },
        {State.CAPE, State.CAPE, State.CAPE, State.SMALL },
        {State.FIRE, State.FIRE, State.FIRE, State.SMALL },
    };

    [ReducerMethod]
    public MarioState ReduceAction(MarioState state, IMarioAction action) => new
    (
        score: state.Score + _actionTable[(int)state.CurrentState, action.GetTableIndex()], 
        state: _transitionTable[(int)state.CurrentState, action.GetTableIndex()]
    );
}