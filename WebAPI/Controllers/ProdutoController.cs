using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ProdutoController : ApiController
    {
        Produto[] produtos = new Produto[]
        {
            new Produto()
            {
                Codigo = 1,
                Nome = "Moto G",
                Categoria = "Celulares",
                Valor = 800.99M
            },
            new Produto()
            {
                Codigo = 2,
                Nome = "Moto X",
                Categoria = "Celulares",
                Valor = 1200.99M
            },
            new Produto()
            {
                Codigo = 3,
                Nome = "Teclado",
                Categoria = "Informática",
                Valor = 100.99M
            },
            new Produto()
            {
                Codigo = 4,
                Nome = "Mouse",
                Categoria = "Informática",
                Valor = 120.99M
            },
            new Produto()
            {
                Codigo = 5,
                Nome = "Case GoPro",
                Categoria = "Acessórios",
                Valor = 220.99M
            }
        };

        [HttpGet]
        public IEnumerable<Produto> ListarTodos()
        {
            return produtos;
        }

        
        public IHttpActionResult FindById(int codigo)
        {
            var produto = produtos.FirstOrDefault(p => p.Codigo == codigo);

            if(produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }
        
        public IEnumerable<Produto> ListaPorCategoria(string categoria)
        {
            return produtos.Where(p => string.Equals(p.Categoria, categoria, StringComparison.OrdinalIgnoreCase));
        }

    }
}
