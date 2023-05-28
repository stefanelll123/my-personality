using MyPersonality.Infrastructure;

namespace MyPersonality.Quizzes.Domain.Entities;

public sealed record Answer(string Description, int NumberOfPoints) : Entity;
