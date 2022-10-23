using Repositorio.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Respository
{
    public interface IPaisesRepository
    {
        Task<IEnumerable<Paises>> Get();
        Task<Paises> Get(int Id);
        Task<Paises> Create(Paises pais);
        Task Update(Paises pais);
    }
}
