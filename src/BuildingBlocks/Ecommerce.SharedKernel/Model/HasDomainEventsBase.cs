﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecommerce.SharedKernel.Model;

public abstract class HasDomainEventsBase
{
    private readonly List<Event> _domainEvents = [];

    [NotMapped, JsonIgnore]
    public IReadOnlyCollection<Event> DomainEvents => _domainEvents.AsReadOnly();

    public void RegisterDomainEvent(Event domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(Event domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
