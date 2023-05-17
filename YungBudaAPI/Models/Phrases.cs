using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YungBudaAPI.Models {
    public class Phrases {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public string? Artist { get; set; }

        [Required]
        [MaxLength(500)]
        public string? Phrase { get; set; }

        [Required]
        [MaxLength(50)]
        public string? SongName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Album { get; set; }

        [Required]
        [MaxLength(500)]
        public string? UrlAlbumCover { get; set; }





    }
}
