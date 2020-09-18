using ShoppingLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingLibrary.Interfaces
{
    public interface ICheckoutStrategy
    {
        double CalculateTotalCost(List<ShoppingCart> cart);
    }
}
