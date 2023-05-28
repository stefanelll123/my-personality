using System;

namespace MyPersonality.Infrastructure;

public abstract record Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}