﻿using Xamarin.Forms;

namespace ReadAndLearnWithLinnea.Shared.QuestionAndAnswer
{
    public partial class QuestionPage
    {
        public QuestionPage()
        {
            InitializeComponent();
        }

        private void DeselectItem(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}