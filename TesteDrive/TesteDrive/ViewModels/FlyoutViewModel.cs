using System;
using System.Collections.Generic;
using System.Text;
using TesteDrive.Models;

namespace TesteDrive.ViewModels
{
    public class FlyoutViewModel
    {
        
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

        private readonly Usuario usuario;

        public FlyoutViewModel(Usuario usuario)
        {

            this.usuario = usuario;

        }

    }
}
