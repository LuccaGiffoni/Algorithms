using System.Net;
using System.Net.Sockets;
using Algorithms.DependencyInjection.Interfaces;

namespace Algorithms.DependencyInjection.Implementations;

public class Repository : IRepository
{
    public void Open()
    {
        Console.WriteLine($"Connection estabilished with {GetLocalIPAddress()}");
    }
    
    public void Save()
    {
        Console.WriteLine("Repository is saving data.");
    }
    
    private static string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        
        throw new Exception("No network adapters with an IPv4 address in the system.");
    }
}