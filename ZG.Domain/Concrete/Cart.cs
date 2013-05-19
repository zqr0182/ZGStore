using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common;
using ZG.Domain.Models;

namespace ZG.Domain.Concrete
{
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();

        public IEnumerable<CartLine> Lines
        {
            get { return _cartLines; }
        }

        public int NumerbOfItems
        {
            get { return _cartLines.Sum(l => l.Quantity); }
        }

        public void AddItem(Product product, int quantity)
        {
            UpdateItem(product, quantity, UpdateQuantityOption.Add);
        }

        public void UpdateItem(Product product, int quantity)
        {
            UpdateItem(product, quantity, UpdateQuantityOption.Update);
        }

        public void RemoveLine(Product product)
        {
            _cartLines.RemoveAll(l => l.Product.Id == product.Id);
        }

        public decimal ComputeTotalValue()
        {
            return _cartLines.Sum(l => l.Quantity * l.Product.Price);
        }

        public void Clear()
        {
            _cartLines.Clear();
        }

        public void UpdateItem(Product product, int quantity, UpdateQuantityOption updateQuantityOption)
        {
            CartLine line = _cartLines.FirstOrDefault(p => p.Product.Id == product.Id);

            if (line == null)
            {
                _cartLines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                if (updateQuantityOption == UpdateQuantityOption.Add)
                {
                    line.Quantity += quantity;
                }
                else if (updateQuantityOption == UpdateQuantityOption.Update)
                {
                    if (quantity > 0)
                    {
                        line.Quantity = quantity;
                    }
                    else
                    {
                        RemoveLine(product);
                    }
                }
            }
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
