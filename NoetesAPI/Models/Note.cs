using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoetesAPI.Models
{
    public class Note
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; internal set; }

        public string Title {  get; set; }

        public string Description { get; set; }


        public DateTime CreatedDate { get; internal set; }

        public DateTime UpdatedDate { get; internal set;}

        [ForeignKey("Id")]
        public int UserId { get; internal set; }
        public User User { get; internal set; }
    }
}
