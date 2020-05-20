using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        // readonly faz com que a dependencia nao possa ser alterada
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            //converte todos os vendedores para uma lista
            return _context.Seller.ToList();
        }

        // o metodo vai inserir o obj na base de dados
        public void Insert(Seller obj)
        {
            //obj.Department = _context.Department.First(); Selecionava o primeiro departamento
            _context.Add(obj);
            _context.SaveChanges();
        }

    }
}
