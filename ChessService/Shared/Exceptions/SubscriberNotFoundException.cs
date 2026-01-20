namespace ChessService.Shared.Exceptions
{
    public sealed class SubscriberNotFoundException(string userId) : Exception($"Unable to find a subscriber with userId {userId}");
}
