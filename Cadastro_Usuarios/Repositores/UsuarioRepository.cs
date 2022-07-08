﻿using Cadastro_Usuarios.Domains;
using Cadastro_Usuarios.Infra.Context;
using Cadastro_Usuarios.Interfaces;
using Cadastro_Usuarios.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro_Usuarios.Repositores
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuariosContext ctx;

        public UsuarioRepository(UsuariosContext appContext)
        {
            ctx = appContext;
        }

        /// <summary>
        /// Metodo responsavel por cadastrar um novo usuario
        /// </summary>
        /// <param name="Usuario_Novo">O novo usuario a ser cadastrado</param>
        public void Cadastrar(usuarioViewModel Usuario_Novo)
        {
            Usuarios usuario = new Usuarios();

            usuario.Id = new Guid();
            usuario.creationDate = DateTime.Now;
            usuario.firstName = Usuario_Novo.FirstName;
            usuario.surName = Usuario_Novo.SurName;
            usuario.age = Usuario_Novo.Age;
            ctx.Usuarios.Add(usuario);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Metodo responsavel por deletar um usuario existente
        /// </summary>
        /// <param name="id">Id do usuario cadastrado</param>
        public void Delete(Guid id)
        {
            Usuarios usuarios = ctx.Usuarios.FirstOrDefault(x => x.Id == id);

            ctx.Usuarios.Remove(usuarios);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Metodo responsavel por editar um usuario existente
        /// </summary>
        /// <param name="Usuario_atualizado">Novas informações</param>
        /// <param name="id">Id do usuario já cadastrado</param>
        /// <returns></returns>
        public string Editar(usuarioViewModel Usuario_atualizado, Guid id)
        {
            Usuarios usuarios = ctx.Usuarios.FirstOrDefault(x => x.Id == id);

            if (usuarios == null)
            {
                return "Usuario não encontrado!";
            }

            if (Usuario_atualizado.SurName != null)
            {
                usuarios.surName = Usuario_atualizado.SurName;
            }
            if (Usuario_atualizado.FirstName != null)
            {
                usuarios.firstName = Usuario_atualizado.FirstName;
            }
            if (Usuario_atualizado.Age > 0)
            {
                usuarios.age = Usuario_atualizado.Age;
            }

            ctx.Usuarios.Update(usuarios);

            ctx.SaveChanges();

            return "Atualizado com sucesso";
        }

        /// <summary>
        /// Metodo responsavel por listar os usuario cadastrados
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        public List<Usuarios> Listar_Todos()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
