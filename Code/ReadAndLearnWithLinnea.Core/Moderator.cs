using System;
using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public interface IModerator
    {
        void Answer(IQuestion question, string text);
        bool CanAnswerQuestion(IQuestion question);
    }

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

        public string Name { get { return _practise.Name; } }
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

        public PracticeScore GetPracticeScore()
        {
            return _practise.GetResult();
        }
    }
}