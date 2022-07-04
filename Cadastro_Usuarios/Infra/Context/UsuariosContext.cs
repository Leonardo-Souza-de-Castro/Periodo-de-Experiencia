using Cadastro_Usuarios.Domains;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_Usuarios.Infra.Context
{
    public class UsuariosContext : DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> options) : base(options)
        {

        }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
