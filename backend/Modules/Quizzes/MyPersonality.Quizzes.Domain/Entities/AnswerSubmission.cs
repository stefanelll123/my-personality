using System;

namespace MyPersonality.Quizzes.Domain.Entities;

public sealed record AnswerSubmission(Guid QuestionId, Guid AnswerId);
