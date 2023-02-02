namespace gsiafa.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User : IdentityUser
    {
        public Guid UserId { get; set; } = Guid.Empty; 
        public string FirstName { get; set; } = string.Empty;        
        public string Surname { get; set; } = string.Empty;
        public int Status { get; set; }
        public DateTime? DateExpired { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdateOn { get; set; }

    }
}
