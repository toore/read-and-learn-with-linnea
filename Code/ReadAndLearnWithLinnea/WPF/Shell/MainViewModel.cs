using PropertyChanged;

namespace ReadAndLearnWithLinnea.WPF.WPF.Shell
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public object Child { get; set; }
    }
}