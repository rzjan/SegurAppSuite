namespace SegurAppSuite.Domain.Events;

public static class DomainEvents
{
    private static readonly List<Delegate> _handlers = new();

    public static void Register<T>(Action<T> handler)
    {
        _handlers.Add(handler);
    }

    public static void Raise<T>(T domainEvent)
    {
        foreach (var handler in _handlers.OfType<Action<T>>())
        {
            handler(domainEvent);
        }
    }
}