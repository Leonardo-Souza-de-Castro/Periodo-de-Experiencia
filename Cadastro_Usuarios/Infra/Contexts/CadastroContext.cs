using Cadastro_Usuarios.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_Usuarios.Infra.Contexts
{
    public class CadastroContext : DbContext
    {
        public CadastroContext(DbContextOptions<CadastroContext> options) : base(options)
        {

        }

        public DbSet<Usuarios> Usuarios { get; set; }


    }
}
