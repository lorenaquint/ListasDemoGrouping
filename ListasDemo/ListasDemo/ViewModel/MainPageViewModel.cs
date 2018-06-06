

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
        private FriendRepository repository;
        public ObservableCollection
            <Grouping<string, Friend>> Friends { get; set; }
        public Command SearchCommand
        {
            get;
            set;
        }
        private string filter;
        public string Filter
        {
            get
            {
                return filter;
            }
            set
            {
                SetValue(ref filter, value);
            }
        }
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
            repository  = new FriendRepository();
            Friends = repository.GetAllGrouped();
			Navigation = navigation;
			AddFriendCommand = new Command(async () => await AddFriend());
            SearchCommand = new Command(async () => await Search());
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
        private async Task Search()
        {
            repository = new FriendRepository();

            var lstFriends = repository.GetAllByFirstLetter(Filter);

            await Friends = ObservableCollection<Grouping<string, Friend>>(lstFriends);

        }
    }
}
