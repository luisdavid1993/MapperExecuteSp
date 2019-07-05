using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data.Utiles
{
    interface Ioperaciones<T>
    {
        Boolean InsertDTO(T obj);
        Boolean UpdateDTO(T obj);
        T GetDTO(int id);
        List<T> GetDTO();
        Boolean deleteDTO(int id);
    }
}
