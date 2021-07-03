using Plugin.Media;
using Plugin.Media.Abstractions;
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

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Image MinhaImagem;

      
        //MaterView
        public FlyoutView(Usuario usuario)
        {
            InitializeComponent();
            
            this.BindingContext = new FlyoutViewModel(usuario);

            MinhaImagem = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Image>(this, "MinhaImagem");
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            AssinarMensagens();
        }      

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            CancelarMensagens();
        }
                
        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Usuario>(this, "EditarPerfil", (usuario) =>
            {
                //Acessar segunda pagina, Editar do TabbedPage
                this.CurrentPage = this.Children[1];
            });


            MessagingCenter.Subscribe<Usuario>(this, "SucessoSalvarUsuario", (usuario) =>
            {

                this.CurrentPage = this.Children[0];
            });


     
        }

        private void CancelarMensagens()
        {
            MessagingCenter.Unsubscribe<Usuario>(this, "EditarPerfil");

            MessagingCenter.Unsubscribe<Usuario>(this, "SucessoSalvarUsuario");
        }


      

    }
}