using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common;

namespace ZG.Domain.Models
{
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();

        public IEnumerable<CartLine> Lines
        {
            get { return _cartLines; }
        }

        public void AddItem(Product product, int quantity)
        {
            UpdateItem(product, quantity, UpdateQuantityOption.Add);
        }

        public void UpdateItem(Product product, int quantity)
        {
            UpdateItem(product, quantity, UpdateQuantityOption.Update);
        }

        public void RemoveItem(Product product)
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
                        RemoveItem(product);
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
