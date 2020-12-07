using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstacionamentoWeb.Models;
using EstacionamentoWeb.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace EstacionamentoWeb.Controllers
{
    public class EstacionarController : Controller
    {
        private readonly Context _context;
        private readonly UsuarioDAO _usuarioDAO;
        private readonly VeiculoDAO _veiculoDAO;
        private readonly EstacionamentoDAO _estacionamentoDAO;
        private readonly EstacionarDAO _estacionarDAO;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IWebHostEnvironment _hosting;

        public EstacionarController(IHttpContextAccessor httpContext, IWebHostEnvironment hosting, Context context, UsuarioDAO usuarioDAO, VeiculoDAO veiculoDAO, EstacionamentoDAO estacionamentoDAO, EstacionarDAO estacionarDAO)
        {
            _context = context;
            _usuarioDAO = usuarioDAO;
            _veiculoDAO = veiculoDAO;
            _estacionamentoDAO = estacionamentoDAO;
            _estacionarDAO = estacionarDAO;
            _hosting = hosting;
            _httpContext = httpContext;
        }

        // GET: Estacionar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estacionados.ToListAsync());
        }
        // GET: Estacionar/Create
        public IActionResult Create()
        {
            var name = User.Identity.Name;
            Usuario usuario = _usuarioDAO.BuscarPorEmail(name);
            int usuarioId = usuario.Id;
            ViewBag.Veiculos = new SelectList(_veiculoDAO.ListarPorUsuario(usuarioId), "Id", "Modelo");
            ViewBag.Estacionamentos = new SelectList(_estacionamentoDAO.ListarPorUsuario(usuarioId), "Id", "Nome");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Estacionar estacionar)
        {
            var email = User.Identity.Name;
            Usuario usuario = _usuarioDAO.BuscarPorEmail(email);
            estacionar.Veiculo = _veiculoDAO.BuscarPorId(estacionar.QualquerCoisa);
            estacionar.Estacionamento = _estacionamentoDAO.BuscarPorId(estacionar.EstacionamentoId);
            estacionar.Usuario = usuario;
            if (_estacionarDAO.Cadastrar(estacionar))
            {
                return RedirectToAction("Index", "Estacionar");
            }
            return View(estacionar);
        }
    }
}
