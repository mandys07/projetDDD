using StarWars.Services;

namespace StarWars.Application;

public class FetchAllStarshipsCommandHandler : IStarshipCommandBus<string>
{
    private readonly ISwapiApi _api;

    public FetchAllStarshipsCommandHandler(ISwapiApi api)
    {
        _api = api;
    }

    public async Task<string> Execute()
    {
        var entities = await _api.GetAll();

        if (entities is null)
        {
            throw new Exception("Erreur");
        }

        return entities;
    }
}
