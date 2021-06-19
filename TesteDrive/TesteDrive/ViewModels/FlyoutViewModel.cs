using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TesteDrive.Models;
using Xamarin.Forms;

namespace TesteDrive.ViewModels
{
    public class FlyoutViewModel : BaseViewModel
    {

        private bool editando = false;

        public bool Editando
        {
            get { return editando; }
            private set { editando = value; OnPropertyChanged(); }
        }


        public string Nome
        {
            get { return this.usuario.nome; }
            set { this.usuario.nome = value; }
        }

        public string Email
        {
            get { return this.usuario.email; }
            set { this.usuario.email = value; }
        }             

        public string DataNascimento
        {
            get { return this.usuario.dataNascimento; }
            set { this.usuario.dataNascimento = value; }
        }
         
        public string Telefone
        {
            get { return this.usuario.telefone; }
            set { this.usuario.telefone = value; }
        }

        private readonly Usuario usuario;

        public ICommand EditarPerfilCommand { get; private set; }

        public ICommand SalvarCommand { get; private set; }

        public ICommand EditarCommand { get; private set; }

        public FlyoutViewModel(Usuario usuario)
        {

            this.usuario = usuario;

            DefinirComandos(usuario);

        }

        private void DefinirComandos(Usuario usuario)
        {
            EditarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(usuario, "EditarPerfil");
            });


            SalvarCommand = new Command(() =>
            {
                this.Editando = false;

                MessagingCenter.Send<Usuario>(usuario, "SucessoSalvarUsuario");

            });


            EditarCommand = new Command(() =>
            {
                this.Editando = true;
            
            });

        }
    }
}
