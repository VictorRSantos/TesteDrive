using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutPageView : FlyoutPage
    {

        private readonly Usuario usuario;

        //MASTER DETAIL VIEW
        public FlyoutPageView(Usuario usuario)
        {
            InitializeComponent();

            this.usuario = usuario;

            this.Flyout = new FlyoutView(usuario);
           
        }
    }
}