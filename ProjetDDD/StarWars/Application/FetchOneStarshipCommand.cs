using StarWars.Entities;
using StarWars.Services;

namespace StarWars.Application;

public class FetchOneStarshipCommand : ICommand
{
    private readonly StarshipCommandBus _commandBus;
    private readonly ISwapiApi _api;
    public int Id { get; set; }

    public FetchOneStarshipCommand(StarshipCommandBus commandBus, ISwapiApi api, int id)
    {
        _commandBus = commandBus;
        _api = api;
        Id = id;
    }

    public async Task Execute()
    {
        var starship = await _api.GetElementById(Id);
        //mapping starshipDTO
        _commandBus.Handle(starship);
    }
}
