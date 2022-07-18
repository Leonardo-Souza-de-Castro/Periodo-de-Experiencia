using Cadastro_Usuarios.Controllers;
using Cadastro_Usuarios.Domains;
using Cadastro_Usuarios.Interfaces;
using Cadastro_Usuarios.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Cadastro_usuarios.Test
{
    public class UsuarioControllerTest
    {
        [Fact]
        public void Deve_Listar_os_Usuarios()
        {
            var lista_usuarios = new List<Usuarios>();

            var user1 = new Usuarios();
            user1.Id = new Guid();
            user1.CreationDate = DateTime.Now;
            user1.FirstName = "Leonardo";
            user1.SurName = "";
            user1.Age = 17;

            var user2 = new Usuarios();
            user1.Id = new Guid();
            user1.CreationDate = DateTime.Now;
            user1.FirstName = "Leonardo";
            user1.SurName = "Souza";
            user1.Age = 17;

            lista_usuarios.Add(user1);
            lista_usuarios.Add(user2);

            var fakerepository = new Mock<IUsuarioRepository>();
            fakerepository.Setup(x => x.Listar_Todos()).Returns(lista_usuarios);

            var fakeLogger = new Mock<ILogger<UsuarioController>>();

            var controller = new UsuarioController(fakerepository.Object, fakeLogger.Object);


            var resultado = controller.Listar();


            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void Deve_cadastrar_um_Usuario()
        {
            var user1 = new UsuarioViewModel();
            user1.FirstName = "Leonardo";
            user1.SurName = "";
            user1.Age = 17;

            var fakerepository = new Mock<IUsuarioRepository>();
            fakerepository.Setup(x => x.Cadastrar(user1));

            var fakeLogger = new Mock<ILogger<UsuarioController>>();

            var controller = new UsuarioController(fakerepository.Object, fakeLogger.Object);

            var resultado = controller.Cadastrar(user1);

            Assert.IsType<StatusCodeResult>(resultado);
        }

        [Fact]
        public void Deve_atualizar_um_Usuario()
        {
            var user1 = new UsuarioViewModel();
            user1.SurName = "Souza";

            var fakerepository = new Mock<IUsuarioRepository>();
            fakerepository.Setup(x => x.Editar(user1, Guid.Parse("02842C7B-5FC5-494D-4EAD-08DA5DCCC5FD")));

            var fakeLogger = new Mock<ILogger<UsuarioController>>();

            var controller = new UsuarioController(fakerepository.Object, fakeLogger.Object);

            var resultado = controller.Editar(user1, Guid.Parse("02842C7B-5FC5-494D-4EAD-08DA5DCCC5FD"));

            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void Deve_deletar_um_Usuario()
        {

            var fakerepository = new Mock<IUsuarioRepository>();
            fakerepository.Setup(x => x.Delete( Guid.Parse("02842C7B-5FC5-494D-4EAD-08DA5DCCC5FD")));

            var fakeLogger = new Mock<ILogger<UsuarioController>>();

            var controller = new UsuarioController(fakerepository.Object, fakeLogger.Object);

            var resultado = controller.Deletar(Guid.Parse("02842C7B-5FC5-494D-4EAD-08DA5DCCC5FD"));

            Assert.IsType<StatusCodeResult>(resultado);
        }
    }
}
