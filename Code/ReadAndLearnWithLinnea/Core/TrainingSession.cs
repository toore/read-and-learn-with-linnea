using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadAndLearnWithLinnea.Core
{
    public class TrainingSession
    {
        private readonly FisherYatesShuffleAlgorithm _fisherYatesShuffleAlgorithm;
        private readonly Vocabulary _vocabulary;
        private Stack<Vocable> _vocablesInTrainingOrder;
        private Vocable _vocableToTranslate;

        public TrainingSession(FisherYatesShuffleAlgorithm fisherYatesShuffleAlgorithm, Vocabulary vocabulary)
        {
            _fisherYatesShuffleAlgorithm = fisherYatesShuffleAlgorithm;
            _vocabulary = vocabulary;
        }

        public Action TrainingSessionCompleted = () => { };
        public Action TranslationSelected = () => { };

        public void Start()
        {
            var shuffledVocables = _fisherYatesShuffleAlgorithm.Shuffle(_vocabulary.Vocables);
            _vocablesInTrainingOrder = new Stack<Vocable>(shuffledVocables);

            ContinueWithNextVocable();
        }

        private void ContinueWithNextVocable()
        {
            _vocableToTranslate = _vocablesInTrainingOrder.Pop();

            TextToTranslate = _vocableToTranslate.GetText(Language.English);
            CorrectTranslation = _vocableToTranslate.GetText(Language.Swedish);

            var falseTranslationsCandidates = _vocabulary.Vocables
                .Where(x => x != _vocableToTranslate)
                .Shuffle(_fisherYatesShuffleAlgorithm)
                .Take(3)
                .ToList();

            FalseTranslations = falseTranslationsCandidates.Select(x => x.GetText(Language.Swedish));
        }

        public string Name { get { return _vocabulary.Name; } }
        public string TextToTranslate { get; private set; }
        public string CorrectTranslation { get; private set; }
        public IEnumerable<string> FalseTranslations { get; private set; }

        public int NoOfCorrectAnswers { get; private set; }
        public int NoOfQuestions { get; private set; }

        public void SelectTranslation(string translation)
        {
            NoOfQuestions++;
            if (translation.Equals(CorrectTranslation, StringComparison.InvariantCultureIgnoreCase))
            {
                NoOfCorrectAnswers++;
            }

            if (!_vocablesInTrainingOrder.Any())
            {
                TrainingSessionCompleted.Invoke();
                return;
            }

            ContinueWithNextVocable();

            TranslationSelected.Invoke();
        }
    }
}