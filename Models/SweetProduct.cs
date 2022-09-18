using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSweetShop1.Models
{
    public class SweetProduct
    {
        public int id { get; set; }
        public string name { get; set; }
        [ForeignKey("categ")]
        public int CategID { get; set; }

        public SweetCategory? category { get; set; }
        public float price { get; set; }
    




    }
}
