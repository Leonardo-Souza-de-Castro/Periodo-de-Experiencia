using Cadastro_Usuarios.Models;
using System;
using System.Collections.Generic;

namespace Cadastro_Usuarios.Interfaces
{
    public interface IUsuarios
    {
        void Cadastrar (Usuarios usuarioNovo);

        List<Usuarios> Listar();

        void Atualizar (Usuarios usuario, Guid id);

        void Deletar(Guid id);
    }
}
