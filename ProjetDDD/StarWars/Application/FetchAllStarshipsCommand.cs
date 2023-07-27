using StarWars.Entities;
using StarWars.Services;

namespace StarWars.Application;

public class FetchAllStarshipsCommand : ICommand
{
    private readonly StarshipCommandBus _commandBus;
    private readonly ISwapiApi _api;

    public FetchAllStarshipsCommand(StarshipCommandBus commandBus, ISwapiApi api)
    {
        _commandBus = commandBus;
        _api = api; 
    }

    public async Task Execute()
    {
        var entities = await _api.GetAll();
        //mapping List<starshipDTO>
        _commandBus.Handle(entities);
    }
}



