using Fluxor;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("\n\n------Flux--------\n");

        var fluxServices = new ServiceCollection();
        fluxServices.AddSingleton<Flux_Pattern.Normal_Flux.MarioStore>();
        fluxServices.AddSingleton<Flux_Pattern.Normal_Flux.Dispatcher>();
        fluxServices.AddSingleton<Flux_Pattern.Normal_Flux.MarioActionCreator>();
        IServiceProvider fluxServiceProvider = fluxServices.BuildServiceProvider();

        var marioStore = fluxServiceProvider.GetRequiredService<Flux_Pattern.Normal_Flux.MarioStore>();
        marioStore.ScoreChanged += PrintMarioState_Flux;

        var flux_dispacher = fluxServiceProvider.GetRequiredService<Flux_Pattern.Normal_Flux.Dispatcher>();
        flux_dispacher.Dispatch += action => action();

        PrintMarioState_Flux(marioStore);
        var actionCreator = fluxServiceProvider.GetRequiredService<Flux_Pattern.Normal_Flux.MarioActionCreator>();
        actionCreator.Action(new Flux_Pattern.Normal_Flux.ObtainMushroomAction());
        actionCreator.Action(new Flux_Pattern.Normal_Flux.ObtainCapeAction());
        actionCreator.Action(new Flux_Pattern.Normal_Flux.ObtainFireAction());
        actionCreator.Action(new Flux_Pattern.Normal_Flux.MeetMonsterAction());


        Console.WriteLine("\n\n------Fluxor--------\n");

        var services = new ServiceCollection();
        services.AddFluxor(o => o
            .ScanAssemblies(typeof(Program).Assembly));
        IServiceProvider serviceProvider = services.BuildServiceProvider();

        var store = serviceProvider.GetRequiredService<IStore>();
        await store.InitializeAsync();
        var marioState = serviceProvider.GetRequiredService<IState<Flux_Pattern.Fluxor.MarioState>>();
        marioState.StateChanged += PrintMarioState_Fluxor;

        var dispatcher = serviceProvider.GetRequiredService<IDispatcher>();
        PrintMarioState_Fluxor(marioState, null);
        dispatcher.Dispatch(new Flux_Pattern.Fluxor.ObtainMushroomAction());
        dispatcher.Dispatch(new Flux_Pattern.Fluxor.ObtainCapeAction());
        dispatcher.Dispatch(new Flux_Pattern.Fluxor.ObtainFireAction());
        dispatcher.Dispatch(new Flux_Pattern.Fluxor.MeetMonsterAction());
    }

    private static void PrintMarioState_Fluxor(object? sender, EventArgs? e)
    {
        var marioSate = sender as IState<Flux_Pattern.Fluxor.MarioState>;
        Console.WriteLine($"Socre : {marioSate!.Value.Score}, State : {marioSate.Value.CurrentState}");
    }

    private static void PrintMarioState_Flux(Flux_Pattern.Normal_Flux.MarioStore marioStore) =>
        Console.WriteLine($"Socre : {marioStore.Score}, State : {marioStore.CurrentState}");
}