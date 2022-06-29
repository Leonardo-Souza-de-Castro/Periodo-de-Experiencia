using Cadastro_Usuarios.Interfaces;
using Cadastro_Usuarios.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Cadastro_Usuarios.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
