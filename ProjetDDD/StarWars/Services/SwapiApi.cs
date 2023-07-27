namespace StarWars.Services;

public interface ISwapiApi
{
    Task<string> GetAll();
    Task<string> GetElementById(int id);
}

public class SwapiApi : ISwapiApi
{
    private readonly string _urlBase;

    public SwapiApi()
    {
        _urlBase = "https://swapi.dev/api/starships";
    }

    public async Task<string> GetAll()
    {
        try
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(_urlBase);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    return jsonResult;
                }
                else
                {
                    throw new Exception($"Erreur de l'API. Code d'état : {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Erreur lors de l'appel à l'API : {ex.Message}");
        }
    }

    public async Task<string> GetElementById(int id)
    {
        string url = $"{_urlBase}/id/";

        try
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    return jsonResult;
                }
                else
                {
                    throw new Exception($"Erreur de l'API. Code d'état : {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Erreur lors de l'appel à l'API : {ex.Message}");
        }
    }
}
