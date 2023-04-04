using Microsoft.EntityFrameworkCore;
using ProyectoSoftware.AccessData;

namespace ProyectoSoftware.Application.Services
{
    public class MigracionService
    {
        public static void MigracionInicial()
        {
            using (var context = new ProyectoSoftwareContext())
            {
                context.Database.Migrate();
            }
        }
    }
}
