using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MovieCrud.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; } // Clé étrangère vers Movie

        [Required]
        [MaxLength(255)]
        public string ReviewerName { get; set; } = string.Empty;

        [Range(0, 10)]
        public decimal Rating { get; set; }

        public string? Comment { get; set; }

        // Relation avec Movie
        [ForeignKey("MovieId")]
        public Movie? Movie { get; set; }
    }
}
