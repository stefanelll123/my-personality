using System.Collections.Generic;

namespace MyPersonality.Quizzes.Api.Controllers.Requests;

public sealed record QuizRequest(string Title, string Description, List<QuestionRequest> Questions, List<PlacementRequest> Placements);

public sealed record QuestionRequest(string Description, List<AnswerRequest> Answers);

public sealed record AnswerRequest(string Description, int NumberOfPoints);

public sealed record PlacementRequest(string Description, int MinScore, int MaxScore);
