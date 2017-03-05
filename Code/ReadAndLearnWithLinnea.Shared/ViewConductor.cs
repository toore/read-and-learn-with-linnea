using System;
using System.Collections.Generic;
using ReadAndLearnWithLinnea.Core;
using ReadAndLearnWithLinnea.Shared.QuestionAndAnswer;
using ReadAndLearnWithLinnea.Shared.SelectVocabulary;

namespace ReadAndLearnWithLinnea.Shared
{
    public class ViewConductor : IConsumer
    {
        private readonly App _app;
        private readonly SelectVocabularyViewModelFactory _selectVocabularyViewModelFactory;
        private readonly QuestionViewModelFactory _questionViewModelFactory;

        public ViewConductor(
            App app,
            SelectVocabularyViewModelFactory selectVocabularyViewModelFactory,
            QuestionViewModelFactory questionViewModelFactory)
        {
            _app = app;
            _selectVocabularyViewModelFactory = selectVocabularyViewModelFactory;
            _questionViewModelFactory = questionViewModelFactory;
        }

        public void SelectVocabularyToPractise(IEnumerable<IVocabulary> vocabularies, IPractiseInitializer practiseInitializer)
        {
            var viewModel = _selectVocabularyViewModelFactory.Create(vocabularies, practiseInitializer);

            var page = new SelectVocabularyPage();
            page.BindingContext = viewModel;

            _app.MainPage = page;
        }

        public void NewQuestion(IQuestion question, IModerator moderator)
        {
            var viewModel = _questionViewModelFactory.Create(moderator, question);

            var page = new QuestionPage();
            page.BindingContext = viewModel;

            _app.MainPage = page;
        }

        public async void PractiseCompleted(IScore score, IApplicationInitializer applicationInitializer)
        {
            var name = score.Name;
            var numberOfCorrectAnswers = score.NumberOfCorrectAnswers;
            var numberOfQuestions = score.NumberOfQuestions;
            var percentageCompleted = score.PercentageCompleted;

            var newLine = Environment.NewLine;

            const string hideCancelButton = null;
            await _app.MainPage.DisplayActionSheet(
                "Practise Completed!",
                hideCancelButton,
                $"Practise of {name} completed!{newLine}{newLine}You passed {numberOfCorrectAnswers} of {numberOfQuestions} ({percentageCompleted:P0}).",
                "OK");

            applicationInitializer.StartOver();
        }
    }
}