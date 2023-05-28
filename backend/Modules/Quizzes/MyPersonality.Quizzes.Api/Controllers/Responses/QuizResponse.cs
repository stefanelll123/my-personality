using System;
using System.Collections.Generic;

namespace MyPersonality.Quizzes.Api.Controllers.Responses;

public sealed record QuizResponse(Guid Id, string Title, string Description, List<QuestionResponse> Questions, List<PlacementResponse> Placements);
