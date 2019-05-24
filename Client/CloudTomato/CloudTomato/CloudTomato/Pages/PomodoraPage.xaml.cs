using CloudTomato.CoreLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CloudTomato.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PomodoraPage : ContentPage
    {
        PomodoraSessionViewModel ViewModel;

        public PomodoraPage()
        {
            ViewModel = new PomodoraSessionViewModel();
            BindingContext = ViewModel;

            InitializeComponent();
        }
    }
}