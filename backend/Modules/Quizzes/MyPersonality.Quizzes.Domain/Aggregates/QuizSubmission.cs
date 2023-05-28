using System;
using System.Collections.Generic;
using MyPersonality.Infrastructure;
using MyPersonality.Quizzes.Domain.Entities;

namespace MyPersonality.Quizzes.Domain.Aggregates;

public sealed record QuizSubmission(Guid QuizId, List<AnswerSubmission> AnswerSubmissions) : Entity;
