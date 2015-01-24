using PropertyChanged;

namespace ReadAndLearnWithLinnea.App.Shell
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public object Child { get; set; }
    }
}