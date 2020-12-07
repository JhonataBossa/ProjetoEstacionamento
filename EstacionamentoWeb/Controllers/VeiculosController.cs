using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstacionamentoWeb.DAL;
using EstacionamentoWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoWeb.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly Context _context;
        private readonly VeiculoDAO _veiculoDAO;
        private readonly UsuarioDAO _usuarioDAO;
        private readonly IWebHostEnvironment _hosting;

        public VeiculosController(Context context, IWebHostEnvironment hosting, VeiculoDAO veiculoDAO, UsuarioDAO usuarioDAO)
        {
            _veiculoDAO = veiculoDAO;
            _hosting = hosting;
            _context = context;
            _usuarioDAO = usuarioDAO;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de Veículos";
            return View(_veiculoDAO.Listar());
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                var email = User.Identity.Name;
                Usuario usuario = _usuarioDAO.BuscarPorEmail(email);
                if (_veiculoDAO.Cadastrar(veiculo, usuario))
                {
                    return RedirectToAction("Index", "Veiculos");
                }
                ModelState.AddModelError("", "Este Veículo já está cadastrado.");
            }
            return View(veiculo);
        }
        public IActionResult Alterar(int id)
        {
            return View(_veiculoDAO.BuscarPorId(id));
        }
        [HttpPost]
        public IActionResult Alterar(Veiculo veiculo)
        {
            _veiculoDAO.Alterar(veiculo);
            return RedirectToAction("Index", "Veiculos");
        }

        // GET: Veiculos/Delete/5
        public IActionResult Remover(int id)
        {
            _veiculoDAO.Remover(id);
            return RedirectToAction("Index", "Veiculos");
        }
    }
}
