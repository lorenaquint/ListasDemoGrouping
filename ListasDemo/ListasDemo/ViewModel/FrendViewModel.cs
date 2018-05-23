
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
		public Friend FriendModel
		{
			get;
			set;
		}
		private INavigation Navigation;
		public FrendViewModel(INavigation navigation)
        {

			FriendModel = new Friend();
			SaveFriendCommand = new Command(async () => await SaveFriend());
			Navigation = navigation;
        }
		public FrendViewModel(INavigation navigation, Friend friend)
		{
			FriendModel = friend;
			SaveFriendCommand = new Command(async () => await SaveFriend());
            Navigation = navigation;

		}

        public async Task SaveFriend()
		{
			await App.Database.SaveFriendAsync(FriendModel);
			await Navigation.PopToRootAsync();
		}
    }
}
