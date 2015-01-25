using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ReadAndLearnWithLinnea.Core
{
    public class TrainingSessionController
    {
        private readonly TrainingSession _trainingSession;
        private Stack<Question> _questions;

        public TrainingSessionController(TrainingSession trainingSession)
        {
            _trainingSession = trainingSession;
        }

        public Action TrainingSessionCompleted = () => { };
        public Action QuestionUpdated = () => { };

        public string Name { get { return _trainingSession.Name; } }
        public Question Question { get; private set; }

        public void Start()
        {
            _trainingSession.InitializeQuestions();
            _questions = new Stack<Question>(_trainingSession.Questions);

            MoveToNextQuestion();
        }

        private void MoveToNextQuestion()
        {
            if (_questions.Count == 0)
            {
                TrainingSessionCompleted.Invoke();
                return;
            }

            Question = _questions.Pop();
            QuestionUpdated.Invoke();
        }

        public bool CanAnswerQuestion(Question question)
        {
            return !_trainingSession.HasQuestionBeenAnswered(question);
        }

        public void AnswerQuestion(Question question, string answer)
        {
            _trainingSession.AnswerQuestion(question, answer);

            MoveToNextQuestion();
        }

        public TrainingSessionResult GetResult()
        {
            return _trainingSession.GetResult();
        }
    }
}