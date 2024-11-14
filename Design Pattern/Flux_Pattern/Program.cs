using Fluxor;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("\n\n------Flux--------\n");
        
        Console.WriteLine("\n\n------Fluxor--------\n");

        var services = new ServiceCollection();
        services.AddFluxor(o => o
            .ScanAssemblies(typeof(Program).Assembly));
        IServiceProvider serviceProvider = services.BuildServiceProvider();

        var store = serviceProvider.GetRequiredService<IStore>();
        await store.InitializeAsync();
        var marioState = serviceProvider.GetRequiredService<IState<Flux_Pattern.Fluxor.MarioState>>();
        marioState.StateChanged += PrintMarioState;

        var dispatcher = serviceProvider.GetRequiredService<IDispatcher>();
        PrintMarioState(marioState, null);
        dispatcher.Dispatch(new Flux_Pattern.Fluxor.ObtainMushroomAction());
        dispatcher.Dispatch(new Flux_Pattern.Fluxor.ObtainCapeAction());
        dispatcher.Dispatch(new Flux_Pattern.Fluxor.ObtainFireAction());
        dispatcher.Dispatch(new Flux_Pattern.Fluxor.MeetMonsterAction());
    }

    private static void PrintMarioState(object? sender, EventArgs? e)
    {
        var marioSate = sender as IState<Flux_Pattern.Fluxor.MarioState>;
        Console.WriteLine($"Socre : {marioSate!.Value.Score}, State : {marioSate.Value.CurrentState}");
    }
}