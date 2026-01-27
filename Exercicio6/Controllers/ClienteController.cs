using Exercicio6ASP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio6ASP.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            Clientes cliente = new Clientes();
            {
                cliente.Nome = "João";
                cliente.Apelido = "Silva";
                cliente.Telefone = "912345678";
            }
            ;
            Automovel automovel = new Automovel();
            {
                automovel.Marca = "Toyota";
                automovel.Modelo = "Corolla";
            }
            ;

            ClienteAutomovel clienteAutomovel = new ClienteAutomovel();
            {
                clienteAutomovel.Cliente = cliente;
                clienteAutomovel.Automovel = automovel;
            }
            ;
            //return View(cliente); //tecla a direito aqui criat new view raszor view. 
            return View(clienteAutomovel);
            //cria a view associada a esta action
            //e passa o modelo cliente para a view
        }
        public IActionResult Lista()
        {
            List<Clientes> listaclientes = new List<Clientes>()
            {
                new Clientes() { Nome = "Ana", Apelido = "Costa", Telefone = "923456789" },
                new Clientes() { Nome = "Bruno", Apelido = "Mendes", Telefone = "934567890" },
                new Clientes() { Nome = "Carla", Apelido = "Santos", Telefone = "945678901" }
            };
            return View(listaclientes);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}

