using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessCore.Areas.General.Models
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Deleted { get; set; }
    }
}
