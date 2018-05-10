using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabPOO
{
  public class CartEventArgs:EventArgs
  {
    public List<Product> cart { get; set; }
    public List<Product> list { get; set; }
  }
}
