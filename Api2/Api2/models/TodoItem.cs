using System.ComponentModel.DataAnnotations;

namespace Api2.models
{
    

        public class TodoItem
        {
            public int Id { get; set; }

            [Required]
            public string Title { get; set; }

            public bool IsCompleted { get; set; }
        }
    }


