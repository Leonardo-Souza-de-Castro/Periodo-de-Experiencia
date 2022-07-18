using System;
using System.ComponentModel.DataAnnotations;

namespace Cadastro_Usuarios.Domains
{
    public class Usuarios
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string SurName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
}
