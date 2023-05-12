using System.ComponentModel.DataAnnotations;

namespace DapperAPI.Models.DTO_s
{
    public class EntityDTO 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Attribute { get; set; }
        public string? Complexity { get; set; }
        public string? Biography { get; set; }
    }
}
