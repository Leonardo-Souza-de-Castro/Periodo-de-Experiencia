using System;
using System.Collections.Generic;
using System.Text;

namespace Cadastro_Usuario.Models
{
    internal class Usuarios
    {
        public Guid Id { get; set; }
        public string firstName { get; set; }
        public string surName { get; set; }
        public int age { get; set; }
        public DateTime creationDate { get; set; }
    }
}
