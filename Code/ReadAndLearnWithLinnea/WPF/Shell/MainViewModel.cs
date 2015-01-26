using PropertyChanged;

namespace ReadAndLearnWithLinnea.WPF.Shell
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public object Child { get; set; }
    }
}