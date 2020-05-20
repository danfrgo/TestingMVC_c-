using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        // readonly faz com que a dependencia nao possa ser alterada
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        // metodo para retornar departamentos ordenados
        public List<Department> FindAll()
        {
            //return _context.Department.ToList();
            //Lista ordenada por Nome
            return _context.Department.OrderBy(x => x.Name).ToList();
        }



    }



}
