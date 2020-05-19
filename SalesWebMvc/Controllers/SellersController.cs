using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        //IActionResult é o tipo de retorno de todas as acçoes
        public IActionResult Create()
        {
            return View();
        }

        // este metodo vai receber um objeto vendedor que veio na requisçao
        //para isso basta coloca-lo como parametro - (Seller seller)
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Seller seller)
        {
            //implementaçao para inserir os dados na bd
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }



    }
}