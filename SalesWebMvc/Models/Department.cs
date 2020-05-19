using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {

        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }


        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            // pegar todos os vendedores da cada departamento  e somar o total de vendas
            // de cada vendedor num intervalo de data

            // pego cada vendedor da minha lista, chamando o TotalSales do vendedor
            // daquele periodo inicial e final, e faço a soma desse resultado para todos os vendedores
            //do meu departamento
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }


    }
}
