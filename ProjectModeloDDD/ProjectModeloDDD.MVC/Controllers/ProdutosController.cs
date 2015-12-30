
using System.Collections.Generic;
using System.Security.Principal;
using System.Web.Mvc;
using AutoMapper;
using ProjectModeloDDD.Domain.Entidades;
using ProjectModeloDDD.MVC.Models;
using ProjetcModelo.Aplication.Interface;

namespace ProjectModeloDDD.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoAplicacaoServico _produtoAplicacaoServico;

        public ProdutosController(IProdutoAplicacaoServico produtoAplicacaoServico)
        {
            _produtoAplicacaoServico = produtoAplicacaoServico;
        }

        // GET: Produtos
        public ActionResult Index()
        {
            var produto = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutosModel>>(_produtoAplicacaoServico.PegaTodos());
            return View(produto);
        }

        public ActionResult Busca(string nome)
        {
            var produtoModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutosModel>>(_produtoAplicacaoServico.BuscaPorProduto(nome));
            return View(produtoModel);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int id)
        {
            var produto = _produtoAplicacaoServico.PegarPorId(id);
            var produtoModel = Mapper.Map<Produto, ProdutosModel>(produto);
            return View(produtoModel);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDominio = Mapper.Map<Produto, Produto>(produto);
                _produtoAplicacaoServico.Adiciona(produtoDominio);

                return RedirectToAction("Index");
            }

            return View(produto);

        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = _produtoAplicacaoServico.PegarPorId(id);
            var produtoModel = Mapper.Map<Produto, ProdutosModel>(produto);
            return View(produtoModel);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutosModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDominio = Mapper.Map<ProdutosModel, Produto>(produto);
                _produtoAplicacaoServico.Alterar(produtoDominio);
                
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int id)
        {
            var produto = _produtoAplicacaoServico.PegarPorId(id);
            var produtoModel = Mapper.Map<Produto, ProdutosModel>(produto);
            return View(produtoModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost , ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult Deleteconfirmed(int id)
        {
            var cliente = _produtoAplicacaoServico.PegarPorId(id);
            _produtoAplicacaoServico.Remove(cliente);

            return RedirectToAction("Index");
        }
    }
}
