using Xamarin.Forms;

namespace Builtcode.Doctor.UI.Mobile.Views
{
    public partial class MedicoPage : ContentPage
    {
        public MedicoPage()
        {
            InitializeComponent();
        }
        
        private void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            // to clear selection on cell
            (sender as ListView).SelectedItem = null;
        }
    }
}