using System.Collections.Generic;

namespace MyPersonality.Quizzes.Api.Controllers.Requests;

public sealed record QuizUpdateRequest(string? Title, string? Description, List<QuestionUpdateRequest>? Questions, List<PlacementUpdateRequest>? Placements);

public sealed record QuestionUpdateRequest(string? Description, List<AnswerUpdateRequest>? Answers);

public sealed record AnswerUpdateRequest(string? Description, int? NumberOfPoints);

public sealed record PlacementUpdateRequest(string? Description, int? MinScore, int? MaxScore);
