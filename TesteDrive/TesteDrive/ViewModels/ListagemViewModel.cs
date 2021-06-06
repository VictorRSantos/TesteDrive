using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TesteDrive.Models;
using Xamarin.Forms;

namespace TesteDrive.ViewModels
{
    public class ListagemViewModel : BaseViewModel
    {
        const string URL_GET_VEICULOS = "http://aluracar.herokuapp.com/";

        public ObservableCollection<Veiculo> Veiculos { get; set; }

        private Veiculo veiculoSelecionado;

        public Veiculo VeiculoSelecionado
        {
            get { return veiculoSelecionado; }
            set
            {
                veiculoSelecionado = value;
                if (value != null)
                    //Mensageria
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");

            }
        }

        private bool aguarde;
        public bool Aguarde
        {
            get { return aguarde; }
            set { aguarde = value; OnPropertyChanged(); }
        }


        public ListagemViewModel()
        {
            this.Veiculos = new ObservableCollection<Veiculo>();
        }

        public async Task GetVeiculos()
        {
            Aguarde = true;

            using (var cliente = new HttpClient())
            {

                var resultado = await cliente.GetStringAsync(URL_GET_VEICULOS);

                var veiculosJson = JsonConvert.DeserializeObject<List<Veiculo>>(resultado);

              
                foreach (var veiculoJson in veiculosJson)
                {

                    this.Veiculos.Add(veiculoJson);

                }


            }

            Aguarde = false;

        }


    }
}
