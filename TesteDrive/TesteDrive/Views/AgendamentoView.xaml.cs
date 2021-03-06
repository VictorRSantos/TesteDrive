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
    public partial class AgendamentoView : ContentPage
    {

        public AgendamentoViewModel ViewModel { get; set; }

        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();


            this.ViewModel = new AgendamentoViewModel(veiculo);

            this.BindingContext = this.ViewModel;
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento",async (msg) =>
            {
                var confirma = await DisplayAlert("Salvar Agendamento", "Deseja mesmo enviar o agendamento", "sim", "não");

                if (confirma)
                {
                    this.ViewModel.SalvarAgendamento();


                }

            });


            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", (msg) =>
            {

                DisplayAlert("Agendamento", "Agendamento salvo com sucesso!","ok");
                
                //DisplayAlert("Agendamento", $"\nVeiculo:{ViewModel.Veiculo.Nome}\nNome:{ViewModel.Nome}\nFone:{ViewModel.Fone}\nEmail:{ViewModel.Email}\nAgendamento:{ViewModel.DataAgendamento.ToString(@"dd/MM/yyyy")}\nHora:{ViewModel.HoraAgendamento}", "ok");
            
            });


            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento", (msg) => 
            {

                DisplayAlert("Agendamento", "Falha ao agendar o teste drive! \nVerifique od dados e tente novamente mais tarde!","ok");
            
            });

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");

            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");

            MessagingCenter.Unsubscribe<ArgumentException>(this,"FalhaAgendamento");

        }

    }
}