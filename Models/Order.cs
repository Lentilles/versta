using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace versta24.Models
{
    [Table("Orders")]
    public sealed class Order
    {
        [Key]
        public Guid Id { get; private set; }
        [NotMapped]
        public string FullNumber { get { return $"{Number:000000}-{Year}"; } }
        public uint Number { get; set; }
        public string Year { get; private set; }
        public uint Weight {  get; set; }
        public DateTime Created { get; set; }
        public DateTime Pickup { get; set; }
        [ForeignKey(nameof(SenderId))]
        public DeliveryAddress Sender { get; set; }
        public Guid SenderId { get; set; }
        [ForeignKey(nameof(RecipientId))]
        public DeliveryAddress Recipient { get; set; }
        public Guid RecipientId { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
            Year = DateTime.UtcNow.Year.ToString();
            Created = DateTime.UtcNow.ToUniversalTime();
        }
    }
}
