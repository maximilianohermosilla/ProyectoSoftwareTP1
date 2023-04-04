using ProyectoSoftware.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSoftwareParte1
{
    public static class Migracion
    {
        public static void MigracionInicial()
        {
            MigracionService.MigracionInicial();
        }
    }
}
