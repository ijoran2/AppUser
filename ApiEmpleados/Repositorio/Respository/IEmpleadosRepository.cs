using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio.modelos;

namespace Repositorio.Respository
{
    public interface IEmpleadosRepository
    {
        Task<IEnumerable<Usuarios>> Get();
        Task<Usuarios> Get(int Id);
        Task<Usuarios> Create(Usuarios usuario);
        Task Update(Usuarios usuario);
        Task Delete(int Id);

    }
}
