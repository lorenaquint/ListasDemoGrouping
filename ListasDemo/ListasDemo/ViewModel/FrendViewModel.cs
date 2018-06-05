
namespace ListasDemo.ViewModel
{
	using System;
	using System.Threading.Tasks;
	using ListasDemo.Model;
	using Xamarin.Forms;

    public class FrendViewModel
    {

        public Command SaveFriendCommand
        {
            get;
            set;
        }
        public bool IsEnabled
        {
            get;
            set;
        }
        public Command DeleteFriendCommand
        {
            get;
            set;
        }
        public Friend FriendModel
        {
            get => _friendModel;
            set => _friendModel = value;
        }
        private INavigation Navigation;
        private Friend _friendModel;

        public FrendViewModel(INavigation navigation)
        {

            FriendModel = new Friend();
            SaveFriendCommand = new Command(async () => await SaveFriend());
            IsEnabled = false;
            Navigation = navigation;
        }

        private async Task DeleteFriend()
        {
            await App.Database.DeleteFriendAsync(FriendModel);
            await Navigation.PopToRootAsync();
        }

        public FrendViewModel(INavigation navigation, Friend friend)
        {
            FriendModel = friend;
            IsEnabled = true;
            SaveFriendCommand = new Command(async () => await SaveFriend());
            DeleteFriendCommand = new Command(async () => await DeleteFriend());
            Navigation = navigation;

        }

        public async Task SaveFriend()
        {
            if (string.IsNullOrWhiteSpace(this.FriendModel.Email) || string.IsNullOrWhiteSpace(this.FriendModel.FirstName) || string.IsNullOrWhiteSpace(this.FriendModel.Phone))
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                                                                "Ningún campo puede estar vacío",
                                                                "Aceptar");
                return;
            }
            await App.Database.SaveFriendAsync(FriendModel);
            await Navigation.PopToRootAsync();
        }
    }
}
