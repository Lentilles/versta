using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace versta24.Models
{
    [Table("DeliveryAddresses")]
    public class DeliveryAddress
    {
        [Key]
        public Guid Id { get; set; }
        [NotMapped]
        public string FullAddress
        {
            get
            {
                return $"{City}, {Address}";
            }
        }
        public string City { get; set; }
        public string Address { get; set; }


        public DeliveryAddress()
        {
            Id = Guid.NewGuid();
        }
    }
}
