using MyPersonality.Infrastructure;

namespace MyPersonality.Quizzes.Domain.Entities;

public sealed record Placement(string Description, int MinScore, int MaxScore) : Entity;
