using StarWars.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Application;

public class FetchOneStarshipCommandHandler : IHandler<string>
{
    public void Handle(string data)
    {
        //Console.WriteLine($"Name: {data.Name}, Model: {data.Model}, Manufacturer: {data.Manufacturer}");
    }
}