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

        // recebeum int id e retorna o vendedor que possui esse id,
        // se o vendedor nao existir retorna nulo
        public Seller FindById(int id)
        {
            return _context.Seller.FirstOrDefault(obj => obj.Id == id);
        }

        // implemtançao baseada no Scafold que fiz nos departamentos
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }



    }
}
