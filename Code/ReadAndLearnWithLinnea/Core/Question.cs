using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public class Question
    {
        private readonly string _correctAnswer;
        private readonly IEnumerable<string> _falseAnswers;
        public string Text { get; private set; }

        public Question(string text, string correctAnswer, IEnumerable<string> falseAnswers)
        {
            _correctAnswer = correctAnswer;
            _falseAnswers = falseAnswers;
            Text = text;
        }

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
    }
}