namespace ChessService.Shared.Exceptions
{
    public class ConfigurationException(string property) : Exception($"Configuration problem for {property}");
}
