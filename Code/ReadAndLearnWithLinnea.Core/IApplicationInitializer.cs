namespace ReadAndLearnWithLinnea.Core
{
    public interface IApplicationInitializer
    {
        void StartOver();
    }

    public class ApplicationInitializer : IApplicationInitializer
    {
        private readonly IView _view;
        private readonly IPractiseInitializerFactory _practiseInitializerFactory;
        private readonly IVocabularyRepository _vocabularyRepository;

        public ApplicationInitializer(IView view, IVocabularyRepository vocabularyRepository, IPractiseInitializerFactory practiseInitializerFactory)
        {
            _view = view;
            _practiseInitializerFactory = practiseInitializerFactory;
            _vocabularyRepository = vocabularyRepository;
        }

        public void Start()
        {
            var vocabularies = _vocabularyRepository.GetAll();

            var practiseInitializer = _practiseInitializerFactory.Create(this);

            _view.ShowSelectVocabularyToPractiseView(vocabularies, practiseInitializer);
        }

        public void StartOver()
        {
            Start();
        }
    }
}