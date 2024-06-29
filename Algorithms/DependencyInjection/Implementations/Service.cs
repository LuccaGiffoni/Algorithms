using Algorithms.DependencyInjection.Interfaces;

namespace Algorithms.DependencyInjection.Implementations;

public class Service : IService
{
    public void Serve()
    {
        var randomSessionId = Guid.NewGuid();
        Console.WriteLine($"Service is serving at session {randomSessionId}.");
    }
}