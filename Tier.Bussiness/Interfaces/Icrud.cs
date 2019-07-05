using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tier.Entity;

namespace Tier.Bussiness.Interfaces
{
    interface Icrud<T>
    {
        Boolean Insertar(T p);
        T Buscar(int id);
        List<T> Buscar();

        Boolean Actualizar(T p);
        Boolean Eliminar(int id);
    }
}
