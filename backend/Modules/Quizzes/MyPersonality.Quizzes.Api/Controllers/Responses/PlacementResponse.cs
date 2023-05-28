using System;

namespace MyPersonality.Quizzes.Api.Controllers.Responses;

public sealed record PlacementResponse(Guid Id, string Description, int MinScore, int MaxScore);
