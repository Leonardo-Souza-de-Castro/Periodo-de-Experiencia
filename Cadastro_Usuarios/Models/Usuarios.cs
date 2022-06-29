using System;
using System.ComponentModel.DataAnnotations;

namespace Cadastro_Usuarios.Models
{
    public class Usuarios
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string firstName { get; set; }
        public string surName { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public DateTime creationDate { get; set; }

    }
}
