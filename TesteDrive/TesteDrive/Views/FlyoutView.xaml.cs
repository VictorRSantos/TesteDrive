using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDrive.Models;
using TesteDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutView : ContentPage
    {

        public FlyoutViewModel ViewModel { get; set; }
        
        //MaterView
        public FlyoutView(Usuario usuario)
        {
            InitializeComponent();

            this.ViewModel = new FlyoutViewModel(usuario);

            this.BindingContext = this.ViewModel;
        }
    }
}