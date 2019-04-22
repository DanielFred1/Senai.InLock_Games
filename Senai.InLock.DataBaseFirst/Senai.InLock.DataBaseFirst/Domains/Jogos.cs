using System;
using System.Collections.Generic;

namespace Senai.InLock.DataBaseFirst.Domains
{
    public partial class Jogos
    {
        public int Jogoid { get; set; }
        public string Nomejogo { get; set; }
        public string Descricao { get; set; }
        public DateTime Datalancamento { get; set; }
        public decimal? Valor { get; set; }
        public string Imagem { get; set; }
        public int? Estudioid { get; set; }

        public Estudios Estudio { get; set; }
    }
}
