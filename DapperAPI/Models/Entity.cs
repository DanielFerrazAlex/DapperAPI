using System.ComponentModel.DataAnnotations;

namespace DapperAPI.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Attribute { get; set; }
        public string? Complexity { get; set; }
        public string? Biography { get; set; }
        public string? Image { get; set;  }

    }
}
