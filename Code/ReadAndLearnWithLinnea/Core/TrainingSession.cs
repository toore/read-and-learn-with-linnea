using System;
using System.Collections.Generic;
using System.Linq;
using ReadAndLearnWithLinnea.Common.Shuffle;

namespace ReadAndLearnWithLinnea.Core
{
    public class TrainingSession
    {
        private const Language TranslateFromLanguage = Language.English;
        private const Language TranslateToLanguage = Language.Swedish;
        private readonly FisherYatesShuffleAlgorithm _fisherYatesShuffleAlgorithm;
        private readonly Vocabulary _vocabulary;
        private Stack<Vocable> _vocablesInTrainingOrder;
        private string _correctAnswer;

        public TrainingSession(FisherYatesShuffleAlgorithm fisherYatesShuffleAlgorithm, Vocabulary vocabulary)
        {
            _fisherYatesShuffleAlgorithm = fisherYatesShuffleAlgorithm;
            _vocabulary = vocabulary;
        }

        public Action TrainingSessionCompleted = () => { };
        public Action NewTranslationQuestionAsked = () => { };
        private IEnumerable<string> _falseAnswers;

        public void Start()
        {
            var shuffledVocables = _fisherYatesShuffleAlgorithm.Shuffle(_vocabulary.Vocables);
            _vocablesInTrainingOrder = new Stack<Vocable>(shuffledVocables);

            UpdateTranslationQuestion(_vocablesInTrainingOrder.Pop());
        }

        private void UpdateTranslationQuestion(Vocable vocable)
        {
            Text = GetTextToTranslate(vocable);
            _correctAnswer = GetTranslation(vocable);
            _falseAnswers = GetIncorrectTranslations(vocable);
        }

        private string GetTextToTranslate(Vocable vocable)
        {
            return GetText(vocable, TranslateFromLanguage);
        }

        private string GetTranslation(Vocable vocable)
        {
            return GetText(vocable, TranslateToLanguage);
        }

        private IEnumerable<string> GetIncorrectTranslations(Vocable vocableToTranslate)
        {
            var falseTranslationsCandidates = _vocabulary.Vocables
                .Where(x => x != vocableToTranslate)
                .Shuffle(_fisherYatesShuffleAlgorithm)
                .Take(3)
                .Select(x => GetText(x, TranslateToLanguage))
                .ToList();

            return falseTranslationsCandidates;
        }

        private string GetText(Vocable vocable, Language language)
        {
            var text = vocable.Words
                .Where(x => x.Language == language)
                .Select(x => x.Text)
                .Shuffle(_fisherYatesShuffleAlgorithm)
                .First();

            return text;
        }

        public string Name { get { return _vocabulary.Name; } }
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

        public int NoOfCorrectAnswers { get; private set; }
        public int NoOfQuestions { get; private set; }

        public void SelectAnswer(string translationAnswer)
        {
            NoOfQuestions++;
            if (translationAnswer.Equals(_correctAnswer, StringComparison.InvariantCultureIgnoreCase))
            {
                NoOfCorrectAnswers++;
            }

            if (!_vocablesInTrainingOrder.Any())
            {
                TrainingSessionCompleted.Invoke();
                return;
            }

            UpdateTranslationQuestion(_vocablesInTrainingOrder.Pop());

            NewTranslationQuestionAsked.Invoke();
        }
    }
}