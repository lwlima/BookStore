using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.ViewModels
{
    public class EditorBookViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Book Name")]
        public string Title { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Isbn")]
        public string Isbn { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Author Name")]
        public string Author { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}
