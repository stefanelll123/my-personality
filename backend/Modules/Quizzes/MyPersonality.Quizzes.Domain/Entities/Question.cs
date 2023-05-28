using System.Collections.Generic;
using MyPersonality.Infrastructure;

namespace MyPersonality.Quizzes.Domain.Entities;

public sealed record Question(string Description, List<Answer> Answers) : Entity;
