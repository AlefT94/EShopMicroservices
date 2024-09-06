
namespace Ordering.Domain.Abstractions;

public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
{
    private readonly List<IDomainEvent> _domainEventes = new();
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEventes.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEventes.Add(domainEvent);
    }

    public IDomainEvent[] ClearDomainEvents() 
    {
        IDomainEvent[] dequeuedEvents = _domainEventes.ToArray();
        _domainEventes.Clear();
        return dequeuedEvents;
    }
}
