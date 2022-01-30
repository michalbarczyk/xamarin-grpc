using System.ComponentModel;
using Xamarin.Forms;
using XamarinGrpc.Mobile.ViewModels;

namespace XamarinGrpc.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}