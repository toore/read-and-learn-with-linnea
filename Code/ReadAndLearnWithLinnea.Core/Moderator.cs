using System;
using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public class Moderator : IModerator
    {
        private readonly Practise _practise;
        private Stack<Question> _questions;

        public Moderator(Practise practise)
        {
            _practise = practise;
        }

        public Action QuestionUpdated = () => { };
        public Action PractiseCompleted = () => { };

        public IQuestion Question { get; private set; }

        public void StartPractise()
        {
            _practise.InitializeQuestions();
            _questions = new Stack<Question>(_practise.Questions);

            MoveToNextQuestion();
        }

        private void MoveToNextQuestion()
        {
            if (_questions.Count == 0)
            {
                PractiseCompleted.Invoke();
                return;
            }

            Question = _questions.Pop();

            QuestionUpdated.Invoke();
        }

        public bool CanAnswerQuestion(IQuestion question)
        {
            return !_practise.HasQuestionBeenAnswered(question);
        }

        public void Answer(IQuestion question, string answer)
        {
            _practise.AnswerQuestion(question, answer);

            MoveToNextQuestion();
        }

        public Score GetScore()
        {
            return _practise.GetResult();
        }
    }
}