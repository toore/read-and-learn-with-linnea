using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public interface IView
    {
        void ShowSelectVocabularyToPractiseView(IEnumerable<IVocabulary> vocabularies, IPractiseInitializer practiseInitializer);
        void ShowNewQuestionView(IQuestion question, IModerator moderator);
        void ShowPractiseCompletedView(IScore score, IApplicationInitializer applicationInitializer);
    }
}