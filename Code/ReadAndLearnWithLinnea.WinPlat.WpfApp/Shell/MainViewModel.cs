using PropertyChanged;

namespace ReadAndLearnWithLinnea.WinPlat.WpfApp.Shell
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public object Child { get; set; }
    }
}