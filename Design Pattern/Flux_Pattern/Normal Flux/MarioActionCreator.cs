namespace Flux_Pattern.Normal_Flux;

public class MarioActionCreator
{
    private static readonly State[,] _transitionTable =
    {
        {State.SUPER, State.CAPE, State.FIRE, State.SMALL },
        {State.SUPER, State.CAPE, State.FIRE, State.SMALL },
        {State.CAPE, State.CAPE, State.CAPE, State.SMALL },
        {State.FIRE, State.FIRE, State.FIRE, State.SMALL },
    };

    private static readonly int[,] _actionTable =
    {
        { +100, +200, +300,   +0 },
        {   +0, +200, +300, -100 },
        {   +0,   +0,    0, -200 },
        {   +0 ,  +0,    0, -300 }
    };

    private readonly MarioStore _store;
    private readonly Dispatcher _dispacher;

    public MarioActionCreator(Dispatcher dispatcher, MarioStore store)
    {
        _dispacher = dispatcher;
        _store = store;
    }

    public void Action(IMarioAction marioAction)
    {
        _dispacher.Invoke(() =>
        {
            int score = _store.Score + 100;
            _store.SetMarioState(new MarioStore(
                score: _store.Score + _actionTable[(int)_store.CurrentState, marioAction.GetTableIndex()],
                state: _transitionTable[(int)_store.CurrentState, marioAction.GetTableIndex()]
            ));
        });
    }
}