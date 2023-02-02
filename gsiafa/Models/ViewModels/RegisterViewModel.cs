using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace gsiafa.Models.ViewModels
{
    public class RegisterViewModel
    {        
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;  

        [NotMapped]
        public string RoleId { get; set; }
        [NotMapped]
        [Display(Name = "Role")]
        public string Role { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> RoleList { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? UpdateOn { get; set; }
    }
}
