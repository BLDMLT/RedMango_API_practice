using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace RedMango_API_practice.Models.Dto
{
    public class MenuItemCreateDTO
    {  
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string SpecialTag { get; set; }
        public string Category { get; set; }
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        public IFormFile File { get; set; }
    }
}
