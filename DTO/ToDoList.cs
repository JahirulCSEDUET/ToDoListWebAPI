﻿namespace ToDoListWebAPI.DTO
{
    public class ToDoList
    {
        public int Id { get; set; }              
        public required string Title { get; set; }        
        public string? Description { get; set; } 
        public bool IsCompleted { get; set; }    
        public DateTime CreatedAt { get; set; }  
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; }
    }
}
