namespace NatrolitePlacesWebApi.Configurations;

public class ApiSettings
{
    public IEnumerable<string> WebApiUrls { get; set; } = Enumerable.Empty<string>();
    public string FrontendDomain { get; set; } = string.Empty;
}
