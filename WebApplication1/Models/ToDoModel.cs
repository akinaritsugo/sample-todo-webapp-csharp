﻿namespace WebApplication1.Models
{
    public class ToDoModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}
