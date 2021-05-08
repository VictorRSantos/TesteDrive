using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TesteDrive.Views
{

    public class Veiculo
    {

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public int Ano { get; set; }

        public string PrecoFormatado { get { return string.Format($"R$ {Preco}"); }}
    }

    public partial class ListagemView : ContentPage
    {

        public List<Veiculo> Veiculos { get; set; }

        public ListagemView()
        {
            InitializeComponent();


            this.Veiculos = new List<Veiculo>()
            {
                new Veiculo{Nome="Azera", Preco=60000, Ano=2012},
                new Veiculo{Nome="Fiesta 2.0", Preco=50000, Ano=2015},
                new Veiculo{Nome="HB20 S", Preco=40000, Ano=2017}


            };

            this.BindingContext = this;
            
        }

        private void listviewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo)e.Item;

            Navigation.PushAsync(new DetalheView(veiculo));


        }
    }
}
