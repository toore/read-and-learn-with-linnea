using PropertyChanged;

namespace ReadAndLearnWithLinnea.WpfApp.Shell
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public object Child { get; set; }
    }
}