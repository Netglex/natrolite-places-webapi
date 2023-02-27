namespace NatrolitePlacesWebApi.Configurations;

public class ApiSettings
{
    public IEnumerable<string> WebApiUrls { get; set; } = Enumerable.Empty<string>();
    public string FrontendUrl { get; set; } = "Test";
}
