using State_Pattern.분기판단;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace State_Pattern.테이블_조회;

public enum State
{
    SMALL,
    SUPER,
    FIRE,
    CAPE,
}

public enum Event
{
    OBTAIN_MUSHROOM,
    OBTAIN_CAPE,
    OBTAIN_FIRE,
    MEET_MONSTER
}

public class MarioStateMachine
{
    public int Score { get; private set; }
    public State CurrentState { get; private set; }

    public static readonly State[,] transitionTable =
    {
        {State.SUPER, State.CAPE, State.FIRE, State.SMALL },
        {State.SUPER, State.CAPE, State.FIRE, State.SMALL },
        {State.CAPE, State.CAPE, State.CAPE, State.SMALL },
        {State.FIRE, State.FIRE, State.FIRE, State.SMALL },
    };

    public static readonly int[,] actionTable =
    {
        { +100, +200, +300,   +0 },
        {   +0, +200, +300, -100 },
        {   +0,   +0,    0, -200 },
        {   +0 ,  +0,    0, -300 }
    };

    public MarioStateMachine()
    {
        Score = 0;
        CurrentState = State.SMALL;
    }

    private void ExecuteEvent(Event evt)
    {
        var state = CurrentState;
        CurrentState = transitionTable[(int)state, (int)evt];
        Score += actionTable[(int)state, (int)evt];
    }

    public void ObtainMushroom() => ExecuteEvent(Event.OBTAIN_MUSHROOM);
    public void ObtainCape() => ExecuteEvent(Event.OBTAIN_CAPE);
    public void ObtainFire() => ExecuteEvent(Event.OBTAIN_FIRE);
    public void MeetMonster() => ExecuteEvent(Event.MEET_MONSTER);
}
