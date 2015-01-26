using System;
using System.Collections.Generic;
using ReadAndLearnWithLinnea.Common.Shuffle;

namespace ReadAndLearnWithLinnea.Core
{
    public class Question
    {
        private readonly IShuffleAlgorithm _shuffleAlgorithm;
        private readonly string _correctAnswer;
        private readonly IEnumerable<string> _falseAnswers;
        private readonly Lazy<IEnumerable<string>> _shuffledAnswers;

        public Question(IShuffleAlgorithm shuffleAlgorithm, string text, string correctAnswer, IEnumerable<string> falseAnswers)
        {
            Text = text;
            _shuffleAlgorithm = shuffleAlgorithm;
            _correctAnswer = correctAnswer;
            _falseAnswers = falseAnswers;
            _shuffledAnswers = new Lazy<IEnumerable<string>>(() => ShuffleAnswers());
        }

        public string Text { get; private set; }

        public IEnumerable<string> Answers
        {
            get { return _shuffledAnswers.Value; }
        }

        private IEnumerable<string> ShuffleAnswers()
        {
            var answers = new List<string>();
            answers.Add(_correctAnswer);
            answers.AddRange(_falseAnswers);
            return answers.Shuffle(_shuffleAlgorithm);
        }

        public string CorrectAnswer { get { return _correctAnswer; } }
    }
}