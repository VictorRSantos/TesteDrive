using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDrive.Models
{
    public class Veiculo
    {
        public const int FREIO_ABS = 800;
        public const int AR_CONDICIONADO = 1000;
        public const int MP3_PLAYER = 500;

        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("preco")]
        public decimal Preco { get; set; }
      

        public string PrecoFormatado { get { return string.Format($"R$ {Preco}"); } }


        public bool TemFreioABS { get; set; }
        public bool TemArCondicionado { get; set; }
        public bool TemMP3Player { get; set; }

        public string PrecoTotalFormatado
        {
            get
            {
                return $"Valor Total: R$ {Preco + (TemFreioABS ? FREIO_ABS : 0) + (TemArCondicionado ? AR_CONDICIONADO : 0) + (TemMP3Player ? MP3_PLAYER : 0)}";

            }
        }

    }
}
