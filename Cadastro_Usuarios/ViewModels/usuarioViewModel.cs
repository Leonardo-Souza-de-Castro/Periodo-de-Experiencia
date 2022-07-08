using System.ComponentModel.DataAnnotations;

namespace Cadastro_Usuarios.ViewModels
{
    public class usuarioViewModel
    {
        [Required]
        public string FirstName { get; set; }
        public string SurName { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
