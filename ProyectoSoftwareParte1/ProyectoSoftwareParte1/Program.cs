using Microsoft.EntityFrameworkCore;
using ProyectoSoftware.Application.Services;

namespace ProyectoSoftwareParte1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Migracion.MigracionInicial();
            Menu.MenuPrincipal();
        }
    }
}