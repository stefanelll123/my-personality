using System.Collections.Generic;
using MyPersonality.Quizzes.Domain.Aggregates;
using MyPersonality.Quizzes.Domain.Entities;

namespace MyPersonality.Quizzes.DataAccess.Adapters;

public sealed class DatabaseContext
{
    public List<Quiz> Quizzes { get; }
    public List<QuizSubmission> QuizSubmissions { get; }
    
    public DatabaseContext()
    {
        var question1 = new Question(
            "You’re really busy at work and a colleague is telling you their life story and personal woes. You:",
            new List<Answer>
            {
                new("Don’t dare to interrupt them", 1),
                new("Think it’s more important to give them some of your time; work can wait", 2),
                new("Listen, but with only with half an ear", 3),
                new("Interrupt and explain that you are really busy at the moment", 4),
            });
        
        var question2 = new Question(
            "You’ve been sitting in the doctor’s waiting room for more than 25 minutes. You:",
            new List<Answer>
            {
                new("Look at your watch every two minutes", 1),
                new("Bubble with inner anger, but keep quiet", 2),
                new("Explain to other equally impatient people in the room that the doctor is always running late", 3),
                new("Complain in a loud voice, while tapping your foot impatiently", 4),
            });
        
        var question3 = new Question(
            "You’re having an animated discussion with a colleague regarding a project that you’re in charge of. You:",
            new List<Answer>
            {
                new("Don’t dare contradict them", 1),
                new("Think that they are obviously right", 2),
                new("Defend your own point of view, tooth and nail", 3),
                new("Continuously interrupt your colleague", 4),
            });
        var placements = new List<Placement>
        {
            new("Happy", 0, 4),
            new("Sad", 5, 8),
            new("Sad", 9, 12),
        };

        var quiz1 = new Quiz("Personality test 1", "Find out your personality", new List<Question> {question1, question2, question3}, placements);
        var quiz2 = new Quiz("Personality test 2", "Find out your personality", new List<Question> {question1, question2, question3}, placements);
        var quiz3 = new Quiz("Personality test 3", "Find out your personality", new List<Question> {question1, question2, question3}, placements);
        var quiz4 = new Quiz("Personality test 4", "Find out your personality", new List<Question> {question1, question2, question3}, placements);
        var quiz5 = new Quiz("Personality test 5", "Find out your personality", new List<Question> {question1, question2, question3}, placements);
        Quizzes = new List<Quiz> {quiz1, quiz2, quiz3, quiz4, quiz5};
        QuizSubmissions = new List<QuizSubmission>();
    }
}