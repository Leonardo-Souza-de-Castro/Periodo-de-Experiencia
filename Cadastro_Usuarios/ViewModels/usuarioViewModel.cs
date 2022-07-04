using System.ComponentModel.DataAnnotations;

namespace Cadastro_Usuarios.ViewModels
{
    public class usuarioViewModel
    {
        [Required]
        public string firstName { get; set; }
        public string surName { get; set; }
        [Required]
        public int age { get; set; }
    }
}
