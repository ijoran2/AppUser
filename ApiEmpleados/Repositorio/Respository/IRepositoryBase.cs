using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Respository
{
    public interface IRepositoryBase<T>
    {
        Task Delete(int Id);
    }
}
