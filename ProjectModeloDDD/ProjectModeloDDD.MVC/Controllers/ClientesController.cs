
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjectModeloDDD.Domain.Entidades;
using ProjectModeloDDD.MVC.Models;
using ProjetcModelo.Aplication.Interface;

namespace ProjectModeloDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAplicacaoServico _clienteAplicacaoServico;

        public ClientesController(IClienteAplicacaoServico clienteAplicacaoServico)
        {
            _clienteAplicacaoServico = clienteAplicacaoServico;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            var clienteModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClientesModel>>(_clienteAplicacaoServico.PegaTodos());
            return View(clienteModel);
        }

        public ActionResult Especiais()
        {
            var clienteModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClientesModel>>(_clienteAplicacaoServico.ObterClientesEspeciais(_clienteAplicacaoServico.PegaTodos()));
            return View(clienteModel);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            var cliente = _clienteAplicacaoServico.PegarPorId(id);
            var clienteModel = Mapper.Map<Cliente, ClientesModel>(cliente);
            return View(clienteModel);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientesModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDominio = Mapper.Map<ClientesModel, Cliente>(cliente);
                _clienteAplicacaoServico.Adiciona(clienteDominio);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = _clienteAplicacaoServico.PegarPorId(id);
            var clienteModel = Mapper.Map<Cliente, ClientesModel>(cliente);
            return View(clienteModel);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientesModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clientedominio = Mapper.Map<ClientesModel, Cliente>(cliente);
                _clienteAplicacaoServico.Alterar(clientedominio);

                return RedirectToAction("Index");

            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = _clienteAplicacaoServico.PegarPorId(id);
            var clienteModel = Mapper.Map<Cliente, ClientesModel>(cliente);

            return View(clienteModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult Deleteconfirmed(int id)
        {
            var cliente = _clienteAplicacaoServico.PegarPorId(id);
            _clienteAplicacaoServico.Remove(cliente);

            return RedirectToAction("Index");
        }
    }
}
