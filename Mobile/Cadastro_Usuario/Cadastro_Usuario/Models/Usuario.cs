using System;
using System.Collections.Generic;
using System.Text;

namespace Cadastro_Usuario.Models
{
    internal class Usuario
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public DateTime creationDate { get; set; }
    }
}
