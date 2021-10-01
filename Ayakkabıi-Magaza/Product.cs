using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ayakkabıi_Magaza
{
    public class Product
    {
        [Key]
        public int Modelid { get; set; }
        public string ModelAd { get; set; }
        public string ModelRenk { get; set; }
        public string ModelStok { get; set; }
        public string ModelTür { get; set; }
        public byte[] ModelFotograf { get; set; }
        public int ModelNumara { get; set; }
        public string MarkaAd { get; set; }
        public string ModelAciklama { get; set; }
        public byte[] MarkaLogo { get; set; }


    }
}
