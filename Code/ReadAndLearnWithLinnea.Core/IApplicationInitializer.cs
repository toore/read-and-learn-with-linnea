namespace ReadAndLearnWithLinnea.Core
{
    public interface IApplicationInitializer
    {
        void StartOver();
    }

    public class ApplicationInitializer : IApplicationInitializer
    {
        private readonly IConsumer _consumer;
        private readonly IPractiseInitializerFactory _practiseInitializerFactory;
        private readonly IVocabularyRepository _vocabularyRepository;

        public ApplicationInitializer(IConsumer consumer, IVocabularyRepository vocabularyRepository, IPractiseInitializerFactory practiseInitializerFactory)
        {
            _consumer = consumer;
            _practiseInitializerFactory = practiseInitializerFactory;
            _vocabularyRepository = vocabularyRepository;
        }

        public void Start()
        {
            var vocabularies = _vocabularyRepository.GetAll();

            var practiseInitializer = _practiseInitializerFactory.Create(this);

            _consumer.SelectVocabularyToPractise(vocabularies, practiseInitializer);
        }

        public void StartOver()
        {
            Start();
        }
    }
}