using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ayakkabıi_Magaza
{
   public class ETradeContext:DbContext
    {
        public DbSet<Product> Etrade { get; set; }
     
    }
}
