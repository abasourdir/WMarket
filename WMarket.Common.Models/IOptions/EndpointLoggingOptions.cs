using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace WMarket.Common.Models.IOptions;

public class EndpointLoggingOptions : List<EndpointLogging>;

public class EndpointLogging
{
    private string _path;

    /// <summary>
    /// Regex path
    /// </summary>
    public string Path
    {
        get => _path;
        set
        {
            _path = value;
            PathRegex = new Regex(value);
        }
    }

    /// <summary>
    /// Enabled logging
    /// </summary>
    public bool Enabled { get; set; }
    
    
    [JsonIgnore]
    public Regex PathRegex { get; private set; }
}