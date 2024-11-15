namespace Flux_Pattern.Normal_Flux;

public class Dispatcher
{
    public event Action<Action> Dispatch = default!;
    public void Invoke(Action action) => Dispatch?.Invoke(action);
}