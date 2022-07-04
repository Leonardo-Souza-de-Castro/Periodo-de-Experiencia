using Cadastro_Usuarios.Domains;
using Cadastro_Usuarios.ViewModels;
using System;
using System.Collections.Generic;

namespace Cadastro_Usuarios.Interfaces
{
    public interface IUsuarioRepository
    {
        public List<Usuarios> Listar_Todos();

        public void Cadastrar(usuarioViewModel Usuario_Novo);

        public string Editar(usuarioViewModel Usuario_atualizado, Guid id);

        public void Delete(Guid id);
    }
}
