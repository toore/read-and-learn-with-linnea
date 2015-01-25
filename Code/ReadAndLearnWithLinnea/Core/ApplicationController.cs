using System;
using ReadAndLearnWithLinnea.Caliburn.Micro;
using ReadAndLearnWithLinnea.Common.Shuffle;

namespace ReadAndLearnWithLinnea.Core
{
    public class ApplicationController
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IShuffleAlgorithm _shuffleAlgorithm;

        public ApplicationController(IEventAggregator eventAggregator, IShuffleAlgorithm shuffleAlgorithm)
        {
            _eventAggregator = eventAggregator;
            _shuffleAlgorithm = shuffleAlgorithm;
        }

        public void StartApplication()
        {
            ShowSelectTrainingView();
        }

        private void ShowSelectTrainingView()
        {
            _eventAggregator.Publish(new ShowSelectTrainingViewMessage());
        }

        public void StartTrainingSession(Vocabulary vocabulary)
        {
            var trainingSession = new TrainingSession(_shuffleAlgorithm, vocabulary);
            var trainingSessionQuestionController = new TrainingSessionController(trainingSession);
            trainingSessionQuestionController.TrainingSessionCompleted = () => TrainingSessionCompleted(trainingSessionQuestionController);
            trainingSessionQuestionController.Start();

            ShowTrainingSessionView(trainingSessionQuestionController);
        }

        private void ShowTrainingSessionView(TrainingSessionController trainingSessionController)
        {
            _eventAggregator.Publish(new ShowTrainingSessionViewMessage(trainingSessionController));
        }

        private void TrainingSessionCompleted(TrainingSessionController trainingSessionController)
        {
            ShowTrainingSessionCompletedMessage(trainingSessionController, () => ShowSelectTrainingView());
        }

        private void ShowTrainingSessionCompletedMessage(TrainingSessionController trainingSessionController, Action continueWith)
        {
            var name = trainingSessionController.Name;
            var trainingSessionResult = trainingSessionController.GetResult();
            var noOfCorrectAnswers = trainingSessionResult.NoOfCorrectAnswers;
            var noOfQuestions = trainingSessionResult.NoOfQuestions;

            var showTrainingSessionCompletedMessage = new ShowTrainingSessionCompletedMessage(name, noOfCorrectAnswers, noOfQuestions, continueWith);
            _eventAggregator.Publish(showTrainingSessionCompletedMessage);
        }
    }
}