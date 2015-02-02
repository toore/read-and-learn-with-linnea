using ReadAndLearnWithLinnea.Core.Common.Shuffle;

namespace ReadAndLearnWithLinnea.Core
{
    public interface IPractiseInitializerFactory
    {
        IPractiseInitializer Create(ApplicationInitializer applicationInitializer);
    }

    public class PractiseInitializerFactory : IPractiseInitializerFactory
    {
        private readonly IView _view;
        private readonly FisherYatesShuffleAlgorithm _shuffleAlgorithm;

        public PractiseInitializerFactory(IView view, FisherYatesShuffleAlgorithm shuffleAlgorithm)
        {
            _view = view;
            _shuffleAlgorithm = shuffleAlgorithm;
        }

        public IPractiseInitializer Create(ApplicationInitializer applicationInitializer)
        {
            return new PractiseInitializer(applicationInitializer, _view, _shuffleAlgorithm);
        }
    }
}