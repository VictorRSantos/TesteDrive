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
    public partial class FlyoutView : TabbedPage
    {      
        
        //MaterView
        public FlyoutView(Usuario usuario)
        {
            InitializeComponent();
            
            this.BindingContext = new FlyoutViewModel(usuario);
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Usuario>(this, "EditarPerfil", (usuario) =>
            {
                //Acessar segunda pagina, Editar do TabbedPage
                this.CurrentPage = this.Children[1];
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Usuario>(this, "EditarPerfil");
        }
    }
}