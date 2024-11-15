using System;

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

    public void Action(IMarioAction marioAction)
    {
        MarioDispatcher.Invoke(() =>
        {
            int score = MarioStore.Instance.Score + 100;
            MarioStore.Instance.SetMarioState(new MarioStore(
                score: MarioStore.Instance.Score + _actionTable[(int)MarioStore.Instance.CurrentState, marioAction.GetTableIndex()],
                state: _transitionTable[(int)MarioStore.Instance.CurrentState, marioAction.GetTableIndex()]
            ));
        });
    }
}

public interface IMarioAction
{
    int GetTableIndex();
}

public record ObtainMushroomAction : IMarioAction { public int GetTableIndex() => 0; }
public record ObtainCapeAction : IMarioAction { public int GetTableIndex() => 1; }
public record ObtainFireAction : IMarioAction { public int GetTableIndex() => 2; }
public record MeetMonsterAction : IMarioAction { public int GetTableIndex() => 3; }