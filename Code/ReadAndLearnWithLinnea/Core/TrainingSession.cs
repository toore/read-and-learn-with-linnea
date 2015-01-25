using System;
using System.Collections.Generic;
using System.Linq;
using ReadAndLearnWithLinnea.Common.Shuffle;

namespace ReadAndLearnWithLinnea.Core
{
    public class TrainingSession
    {
        private readonly IShuffleAlgorithm _shuffleAlgorithm;
        private readonly Vocabulary _vocabulary;
        private readonly Dictionary<Question, string> _answers;

        private const Language TranslateFromLanguage = Language.English;
        private const Language TranslateToLanguage = Language.Swedish;

        public TrainingSession(IShuffleAlgorithm shuffleAlgorithm, Vocabulary vocabulary)
        {
            _shuffleAlgorithm = shuffleAlgorithm;
            _vocabulary = vocabulary;
            _answers = new Dictionary<Question, string>();
        }

        public string Name
        {
            get { return _vocabulary.Name; }
        }

        public IEnumerable<Question> Questions { get; private set; }

        public void InitializeQuestions()
        {
            Questions = _shuffleAlgorithm.Shuffle(_vocabulary.Vocables)
                .Select(q => CreateQuestion(q))
                .ToList();
        }

        public void AnswerQuestion(Question question, string answer)
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

        private bool IsQuestionPartOfTrainingSession(Question question)
        {
            return Questions.Contains(question);
        }

        public bool HasQuestionBeenAnswered(Question question)
        {
            return _answers.ContainsKey(question);
        }

        private Question CreateQuestion(Vocable vocable)
        {
            var text = GetTextToTranslate(vocable);
            var correctAnswer = GetTranslation(vocable);
            var falseAnswers = GetIncorrectTranslations(vocable);

            var question = new Question(text, correctAnswer, falseAnswers);

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

        public TrainingSessionResult GetResult()
        {
            if (_answers.Count < Questions.Count())
            {
                throw new NotAllQuestionsHaveBeenAnsweredException();
            }

            var noOfCorrectAnswers = GetNoOfCorrectAnswers();
            var noOfQuestions = Questions.Count();

            return new TrainingSessionResult(noOfCorrectAnswers, noOfQuestions);
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
        public static bool IsAnswerCorrect(this KeyValuePair<Question, string> answer)
        {
            return answer.Key.CorrectAnswer.Equals(answer.Value, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}