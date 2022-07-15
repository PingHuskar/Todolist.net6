using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class Todo
    {
        [Required]
        [Display(Name = "Todo ID")]
        public int TodoID { get; set; }
        [Display(Name = "Name")]
        [MaxLength(30)]
        [Required(ErrorMessage = "Plz give this task a name")]
        public string Task { get; set; }
        
        public string Status { get; set; }
        [Display(Name = "Due")]
        public string Date { get; set; }
    }
}
