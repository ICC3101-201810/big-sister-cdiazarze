using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LabPOO
{
  [Serializable]
  public class Product
  {

    private string name;
    private int stock;
    private int price; //Price for one unit of the product
    private string unit;

    public delegate void ProductAddedEventHandler(object source, CartEventArgs e);
    public event ProductAddedEventHandler ProductAdded;


    public Product(string name, int price, int stock, string unit)
    {
      this.name = name;
      this.stock = stock;
      this.price = price;
      this.unit = unit;
    }




    public bool Agregar(List<Product> carrito, List<Product> list)
    {
      if (stock > 0)
      {
        carrito.Add(this);
        stock--;
        OnProductAdded(carrito, list);
        return true;
      }
      return false;
    }

    protected virtual void OnProductAdded(List<Product> carrito, List<Product> list)
    {
      if (ProductAdded != null)
        ProductAdded(this, new CartEventArgs() { cart=carrito, list=list});
    }


    public void Quitar(object source, CartEventArgs e)
    {
      foreach (Product p in e.list)
        if (p.Name.Equals(this.Name))
        {
          if (p.Stock < 1)
          {
            e.cart.Remove(this);
            stock++;
            Console.WriteLine("No Matias! Malo!\nBigGrumpySister devuelve el/la " + this.name + " que Matias queria...\n");
            Thread.Sleep(3000);
          }
          else p.stock--;
        }
    }

    public string Name { get => name; }
    public int Stock { get => stock; }
    public int Price { get => price; }
    public string Unit { get => unit; }
  } 
}
