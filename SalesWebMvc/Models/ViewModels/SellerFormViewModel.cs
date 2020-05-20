using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models.ViewModels
{
    //form para o registo de vendedores
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; } // tem que ter um vendedor
        public ICollection<Department> Departments { get; set; } // lista de departamentos para que possa criar uma caixa para selecionar o departamento do vendedor



    }
}
