using ReadAndLearnWithLinnea.Core.Common.Shuffle;

namespace ReadAndLearnWithLinnea.Core
{
    public interface IPractiseInitializerFactory
    {
        IPractiseInitializer Create(ApplicationInitializer applicationInitializer);
    }

    public class PractiseInitializerFactory : IPractiseInitializerFactory
    {
        private readonly IConsumer _consumer;
        private readonly FisherYatesShuffleAlgorithm _shuffleAlgorithm;

        public PractiseInitializerFactory(IConsumer consumer, FisherYatesShuffleAlgorithm shuffleAlgorithm)
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