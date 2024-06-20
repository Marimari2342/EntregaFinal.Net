using System;
using Microsoft.EntityFrameworkCore;

namespace SGE.Repositorios
{
    public class EntidadesSqlite
    {
        public static void Inicializar()
        {
            using var context = new EntidadesContext();
            if (context.Database.EnsureCreated()) //Si la base de datos no existe se crea según el modelo definido.
            {
                Console.WriteLine("Se creó la base de datos");
            }
        }
    }
}