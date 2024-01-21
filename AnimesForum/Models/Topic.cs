using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AnimesForum.Models
{
    public class Topic
    {
        public int TopicId { get; set; }

        [StringLength(100, ErrorMessage = "The title cannot be longer than 100 characters.")]
        public required string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public required string Description { get; set; }

        public string? UserId { get; set; }

        public virtual IdentityUser? User { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }
    }
}
