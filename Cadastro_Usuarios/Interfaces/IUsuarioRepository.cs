using Cadastro_Usuarios.Domains;
using Cadastro_Usuarios.ViewModels;
using System;
using System.Collections.Generic;

namespace Cadastro_Usuarios.Interfaces
{
    public interface IUsuarioRepository
    {
        public Usuarios Buscar_Id(Guid id);
        public List<Usuarios> Listar_Todos();

        public void Cadastrar(UsuarioViewModel Usuario_Novo);

        public string Editar(UsuarioViewModel Usuario_atualizado, Guid id);

        public void Delete(Guid id);
    }
}
