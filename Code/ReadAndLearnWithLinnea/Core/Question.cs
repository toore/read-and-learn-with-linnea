using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public class Question
    {
        private readonly string _correctAnswer;
        private readonly IEnumerable<string> _falseAnswers;

        public Question(string text, string correctAnswer, IEnumerable<string> falseAnswers)
        {
            Text = text;
            _correctAnswer = correctAnswer;
            _falseAnswers = falseAnswers;
        }

        public string Text { get; private set; }

        public IEnumerable<string> Answers
        {
            get
            {
                var answers = new List<string>();
                answers.Add(_correctAnswer);
                answers.AddRange(_falseAnswers);

                return answers;
            }
        }

        public string CorrectAnswer { get { return _correctAnswer; } }
    }
}