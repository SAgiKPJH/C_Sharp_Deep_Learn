namespace Flux_Pattern.Normal_Flux;

public interface IMarioAction
{
    int GetTableIndex();
}

public record ObtainMushroomAction : IMarioAction { public int GetTableIndex() => 0; }
public record ObtainCapeAction : IMarioAction { public int GetTableIndex() => 1; }
public record ObtainFireAction : IMarioAction { public int GetTableIndex() => 2; }
public record MeetMonsterAction : IMarioAction { public int GetTableIndex() => 3; }