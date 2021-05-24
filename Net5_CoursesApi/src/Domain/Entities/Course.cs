namespace Infra.Entities
{
    public class Course : Base
    {
        public string Description { get; set; }
        public string Category { get; set; }
        public int UserId { get; set; }
        public virtual User User{ get; set; }
    }
}