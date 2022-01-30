using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinGrpc.Mobile.ViewModels;

namespace XamarinGrpc.Mobile.Services
{
    public class NavigationService
    {
        private const string ViewModel = nameof(ViewModel);
        private const string Page = nameof(Page);
        
        public async Task Navigate<TViewModel>() where TViewModel : BaseViewModel
        {
            await GoToAsync(nameof(TViewModel).Replace(ViewModel, Page));

            // await GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}")
        }
        
        // public async Task Navigate<TViewModel>() where TViewModel : BaseViewModel, 
        // {
        //     await GoToAsync(nameof(TViewModel).Replace(ViewModel, Page));
        //
        //     // await GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}")
        // }

        private Task GoToAsync(string location) => Shell.Current.GoToAsync(new ShellNavigationState(location));
    }
}