using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheView : ContentPage
    {
        private const int FREIO_ABS = 800;
        public string TextoFreioABS { get { return $"Freio ABS - R$ {FREIO_ABS}"; } }

        private const int AR_CONDICIONADO = 1000;
        public string TextoArCondicionado { get { return $"Ar Condicionado - R$ {AR_CONDICIONADO}"; } }

        private const int MP3_PLAYER = 500;
        public string TextoMP3Player { get { return $"MP3 Player - R$ {MP3_PLAYER}"; } }


        private bool temFreioABS;
        public bool TemFreioABS
        {
            get { return temFreioABS; }
            set { temFreioABS = value; OnPropertyChanged(nameof(ValorTotal)); }

        }


        private bool temArCondicionado;

        public bool TemArCondicionado
        {
            get { return temArCondicionado; }
            set { temArCondicionado = value; OnPropertyChanged(nameof(ValorTotal)); }
        }


        private bool temMP3Player;

        public bool TemMP3Player
        {
            get { return temMP3Player; }
            set { temMP3Player = value; OnPropertyChanged(nameof(ValorTotal)); }
        }



        public string ValorTotal
        {
            get
            {
                return $"Valor Total: R$ {Veiculo.Preco + (TemFreioABS ? FREIO_ABS : 0) + (TemArCondicionado ? AR_CONDICIONADO : 0) + (TemMP3Player ? MP3_PLAYER : 0)}";
            
            }
        }

        public Veiculo Veiculo { get; set; }

        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();                      

            this.Veiculo = veiculo;

            this.BindingContext = this;
        }

        private void buttonProximo_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new AgendamentoView(this.Veiculo));

        }
    }
}