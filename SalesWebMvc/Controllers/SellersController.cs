using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        // dependencia para o DepartamentService
        private readonly DepartmentService _departmentService;
        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        //IActionResult é o tipo de retorno de todas as acçoes
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll(); // pesquisar na BD todos os departaments
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
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

        //implementaçao baseada no scafold
        //int? significa int opcinal
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}