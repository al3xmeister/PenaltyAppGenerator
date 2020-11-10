using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PenaltyApp.ViewModels;
using Xamarin.Forms;

namespace PenaltyApp
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new MainPageViewModel();
        }
       
    }
}
