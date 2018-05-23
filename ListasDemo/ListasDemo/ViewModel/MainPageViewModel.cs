

namespace ListasDemo.ViewModel
{ 
	using ListasDemo.Model;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ListasDemo.Helpers;
	using Xamarin.Forms;
	using ListasDemo.View;

	public class MainPageViewModel:Notificable
    {
        public ObservableCollection
            <Grouping<string, Friend>> Friends { get; set; }
		public Command AddFriendCommand
		{
			get;
			set;
		}
		public Command ITemTappedCommand
        {
            get;
            set;
        }
		private Friend currentFriend;
        
		public Friend CurrentFriend
        {
            get
            {
				return currentFriend;
            }
            set
            {
				SetValue(ref currentFriend, value);
            }

        }
		private INavigation Navigation;
		public MainPageViewModel(INavigation navigation)
        {
            FriendRepository repository 
                = new FriendRepository();
            Friends = repository.GetAllGrouped();
			Navigation = navigation;
			AddFriendCommand = new Command(async () => await AddFriend());
			ITemTappedCommand = new Command(async () => await NavigateToEditFriendView());
        }

		public async Task AddFriend()
		{
			await Navigation.PushAsync(new FriendPage());
		}
		public async Task NavigateToEditFriendView()
        {
			await Navigation.PushAsync(new FriendPage(CurrentFriend));
        }
    }
}
