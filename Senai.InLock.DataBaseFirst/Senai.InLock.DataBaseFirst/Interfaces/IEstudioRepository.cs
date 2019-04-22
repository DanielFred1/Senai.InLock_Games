using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.InLock.DataBaseFirst.Domains;

namespace Senai.InLock.DataBaseFirst.Interfaces
{
    interface IEstudioRepository
    {
        void Cadastrar(Estudios estudio);

        List<Estudios> Listar();

        Estudios BuscarPorId(int id);
    }
}
