using System;

namespace MyPersonality.Quizzes.Api.Controllers.Responses;

public sealed record AnswerSubmissionResponse(Guid Id, Guid QuestionId, Guid AnswerId);
