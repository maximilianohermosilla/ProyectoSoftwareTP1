using Microsoft.EntityFrameworkCore;
using ProyectoSoftwareParte1.Models;

namespace ProyectoSoftwareParte1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MigracionInicial();
            Menu.MenuPrincipal();
        }

        public static void MigracionInicial()
        {
            using (var context = new ProyectoSoftwareContext())
            {
                context.Database.Migrate();
            }
        }
    }
}