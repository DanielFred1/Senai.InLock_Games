using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.InLock.DataBaseFirst.Interfaces;
using Senai.InLock.DataBaseFirst.Domains;
using Microsoft.EntityFrameworkCore;

namespace Senai.InLock.DataBaseFirst.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        public void Cadastrar(Estudios estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }   
        }

        public List<Estudios> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.Include("Jogos").ToList();
            }
        }

        public Estudios BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.Include(x => x.Jogos).FirstOrDefault(g => g.Estudioid == id);
            }
        }
    }
}
