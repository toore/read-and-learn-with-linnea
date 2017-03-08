using Xamarin.Forms;

namespace Xamarin.SelectVocabulary
{
    public partial class SelectVocabularyPage
    {
        public SelectVocabularyPage()
        {
            InitializeComponent();
        }

        private void DeselectItem(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}