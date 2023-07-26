using StarWars.Services;

namespace StarWars.Application;

public class FetchOneStarshipCommand
{
    //id param
    private readonly ISwapiApi _api;

    public FetchOneStarshipCommand(ISwapiApi api)
    {
        _api = api;
    }

    public async Task<string> Execute()
    {
        var entities = await _api.GetElementById(1);

        if (entities is null)
        {
            throw new Exception("Erreur");
        }

        return entities;
    }
}
