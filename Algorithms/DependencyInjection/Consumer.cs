using Algorithms.DependencyInjection.Interfaces;

namespace Algorithms.DependencyInjection;

public class Consumer(IService service, IRepository repository)
{
    public void Start()
    {
        service.Serve();
        repository.Open();
    }
}