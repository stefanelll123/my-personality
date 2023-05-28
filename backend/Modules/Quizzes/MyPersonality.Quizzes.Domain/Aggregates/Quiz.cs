using System.Collections.Generic;
using MyPersonality.Infrastructure;
using MyPersonality.Quizzes.Domain.Entities;

namespace MyPersonality.Quizzes.Domain.Aggregates;

public sealed record Quiz(string Title, string Description, List<Question> Questions, List<Placement> Placements) : Entity;
