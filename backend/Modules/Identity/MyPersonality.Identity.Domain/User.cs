using MyPersonality.Identity.Domain.ValueObjects;
using MyPersonality.Infrastructure;

namespace MyPersonality.Identity.Domain;

public sealed record User(string FirstName, string LastName, Email Email, string Username, string PasswordHash) : Entity;