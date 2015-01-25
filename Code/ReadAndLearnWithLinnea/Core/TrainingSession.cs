﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadAndLearnWithLinnea.Core
{
    public class TrainingSession
    {
        private readonly FisherYatesShuffleAlgorithm _fisherYatesShuffleAlgorithm;
        private readonly Vocabulary _vocabulary;
        private Stack<Vocable> _vocables;
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
            _vocables = new Stack<Vocable>(shuffledVocables);

            ContinueSession();
        }

        private void ContinueSession()
        {
            _vocableToTranslate = _vocables.Pop();

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

        public int NoOfCorrectTranslations { get; private set; }
        public int TotalWords { get; private set; }

        public void SelectTranslation(string translation)
        {
            TotalWords++;
            if (translation.Equals(CorrectTranslation, StringComparison.InvariantCultureIgnoreCase))
            {
                NoOfCorrectTranslations++;
            }

            if (!_vocables.Any())
            {
                TrainingSessionCompleted.Invoke();
                return;
            }

            ContinueSession();

            TranslationSelected.Invoke();
        }
    }
}