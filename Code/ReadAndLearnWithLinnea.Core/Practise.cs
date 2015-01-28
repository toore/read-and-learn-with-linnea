using System;
using System.Collections.Generic;
using System.Linq;
using ReadAndLearnWithLinnea.Core.Common.Shuffle;

namespace ReadAndLearnWithLinnea.Core
{
    public class Practise
    {
        private readonly IShuffleAlgorithm _shuffleAlgorithm;
        private readonly IVocabulary _vocabulary;
        private readonly Dictionary<IQuestion, string> _answers;

        private const Language TranslateFromLanguage = Language.English;
        private const Language TranslateToLanguage = Language.Swedish;

        public Practise(IShuffleAlgorithm shuffleAlgorithm, IVocabulary vocabulary)
        {
            _shuffleAlgorithm = shuffleAlgorithm;
            _vocabulary = vocabulary;
            _answers = new Dictionary<IQuestion, string>();
        }

        public IEnumerable<Question> Questions { get; private set; }

        public void InitializeQuestions()
        {
            Questions = _vocabulary.Vocables.Shuffle(_shuffleAlgorithm)
                .Select(q => CreateQuestion(q))
                .ToList();
        }

        public void AnswerQuestion(IQuestion question, string answer)
        {
            if (!IsQuestionPartOfTrainingSession(question))
            {
                throw new AnsweredQuestionIsNotPartOfTrainingSessionException();
            }
            if (HasQuestionBeenAnswered(question))
            {
                throw new QuestionHasAlreadyBeenAnsweredException();
            }

            _answers.Add(question, answer);
        }

        private bool IsQuestionPartOfTrainingSession(IQuestion question)
        {
            return Questions.Contains(question);
        }

        public bool HasQuestionBeenAnswered(IQuestion question)
        {
            return _answers.ContainsKey(question);
        }

        private Question CreateQuestion(Vocable vocable)
        {
            var text = GetTextToTranslate(vocable);
            var correctAnswer = GetTranslation(vocable);
            var falseAnswers = GetIncorrectTranslations(vocable);

            var question = new Question(_shuffleAlgorithm, text, correctAnswer, falseAnswers);

            return question;
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
                .Shuffle(_shuffleAlgorithm)
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
                .Shuffle(_shuffleAlgorithm)
                .First();

            return text;
        }

        public Score GetResult()
        {
            if (_answers.Count < Questions.Count())
            {
                throw new NotAllQuestionsHaveBeenAnsweredException();
            }

            var noOfCorrectAnswers = GetNoOfCorrectAnswers();
            var noOfQuestions = Questions.Count();
            var name = _vocabulary.Name;

            return new Score(name, noOfCorrectAnswers, noOfQuestions);
        }

        private int GetNoOfCorrectAnswers()
        {
            return _answers.Count(a => a.IsAnswerCorrect());
        }
    }

    public class NotAllQuestionsHaveBeenAnsweredException : ApplicationException
    {
    }

    public class AnsweredQuestionIsNotPartOfTrainingSessionException : ApplicationException
    {
    }

    public class QuestionHasAlreadyBeenAnsweredException : ApplicationException
    {
    }

    public static class TrainingSessionResultExtensions
    {
        public static bool IsAnswerCorrect(this KeyValuePair<IQuestion, string> answer)
        {
            var question = ((Question)answer.Key);
            return question.CorrectAnswer.Equals(answer.Value, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}