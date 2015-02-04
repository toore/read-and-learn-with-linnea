namespace ReadAndLearnWithLinnea.Core
{
    public interface IPractiseInitializerFactory
    {
        IPractiseInitializer Create(ApplicationInitializer applicationInitializer);
    }

    public class PractiseInitializerFactory : IPractiseInitializerFactory
    {
        private readonly IConsumer _consumer;
        private readonly IShuffleAlgorithm _shuffleAlgorithm;

        public PractiseInitializerFactory(IConsumer consumer, IShuffleAlgorithm shuffleAlgorithm)
        {
            _consumer = consumer;
            _shuffleAlgorithm = shuffleAlgorithm;
        }

        public IPractiseInitializer Create(ApplicationInitializer applicationInitializer)
        {
            return new PractiseInitializer(applicationInitializer, _consumer, _shuffleAlgorithm);
        }
    }
}