using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    [BindProperties]
    public class ToDoModel
    {
        [FromForm(Name = "id")]
        public int Id { get; set; }

        [FromForm(Name = "title")]
        public string? Title { get; set; }

        [FromForm(Name = "description")]

        public string? Description { get; set; }

        [FromForm(Name = "deadline")]
        public DateTime? Deadline { get; set; }

        [FromForm(Name = "priority")]
        public string? Priority { get; set; }

        [FromForm(Name = "status")]
        public string? Status { get; set; }

        [FromForm(Name = "userId")]
        public int UserId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}
