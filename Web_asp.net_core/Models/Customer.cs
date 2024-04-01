using System.ComponentModel.DataAnnotations;

namespace Web_asp.net_core.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
