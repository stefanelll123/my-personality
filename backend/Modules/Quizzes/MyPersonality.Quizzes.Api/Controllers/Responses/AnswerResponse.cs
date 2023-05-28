using System;

namespace MyPersonality.Quizzes.Api.Controllers.Responses;

public sealed record AnswerResponse(Guid Id, string Description, int NumberOfPoints);
