using Algorithms.DependencyInjection;
using Algorithms.DependencyInjection.Implementations;
using Algorithms.DependencyInjection.Interfaces;
using Algorithms.LINQMethods;

namespace Algorithms;

public static class Program
{
    public static void Main()
    {
        //ReversePhrases.Run();
        //RemoveVowels.Run();
        //AnagramGrouping.Run();

        //OrderNumbers.Run();
        
        //CreateDependencyInjection();

        Aggregation.Run();
    }

    private static void CreateDependencyInjection()
    {
        var container = new Container();

        container.Register<IService, Service>();
        container.Register<IRepository, Repository>();

        var consumer = container.Resolve<Consumer>();
        consumer?.Start();
    }
}