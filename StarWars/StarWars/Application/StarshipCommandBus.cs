using StarWars.Entities;

namespace StarWars.Application;

public class StarshipCommandBus
{
    public void ExecuteCommand(ICommand command)
    {
        try
        {
            command.Execute();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing command: {ex.Message}");
        }
    }

    //Ambiguité : à décommenter lorsque le mmaping sera fait et prendra en paramètre une liste<starshipDTO>
    //public void Handle(string starships)
    //{
    //    var handler = new FetchAllStarshipsCommandHandler();
    //    handler.Handle(starships);
    //}

    public void Handle(string starship)
    {
        var handler = new FetchOneStarshipCommandHandler();
        handler.Handle(starship);
    }
}
