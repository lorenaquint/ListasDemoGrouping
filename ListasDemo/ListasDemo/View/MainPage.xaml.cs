using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListasDemo.ViewModel;
using Xamarin.Forms;

namespace ListasDemo.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //this.BindingContext = new 
              //  MainPageViewModel();
        }
		protected override void OnAppearing()
		{
			this.BindingContext = new 
				MainPageViewModel(Navigation);
		}
	}
}
