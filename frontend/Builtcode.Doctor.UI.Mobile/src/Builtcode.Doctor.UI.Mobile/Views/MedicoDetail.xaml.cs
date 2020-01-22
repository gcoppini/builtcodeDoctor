using Rg.Plugins.Popup.Pages;

namespace Builtcode.Doctor.UI.Mobile.Views
{
    public partial class MedicoDetail : PopupPage
    {
        public MedicoDetail()
        {
            InitializeComponent();
        }
        
        // Prevent hide popup
        protected override bool OnBackButtonPressed() => true;
    }
}