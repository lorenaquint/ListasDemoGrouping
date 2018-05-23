

namespace ListasDemo
{
	using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ListasDemo.Data;
	using ListasDemo.Services;
	using Xamarin.Forms;
    public partial class App : Application
    {
		private static FriendDatabase database;


		public static FriendDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new FriendDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("friendsdb.db3"));
				}
				return database;
			}
		}
        public App()
        {
            InitializeComponent();

			MainPage = new NavigationPage(new View.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
