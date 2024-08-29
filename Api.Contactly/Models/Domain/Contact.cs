namespace Api.Contactly.Models.Domain
{
    public class Contact
    {
        public Guid ContactId { get; set; }     
        public required string Name { get; set; }   
        public string? Email { get; set; }  
        public required string Phone { get; set; }
        public bool Favorite { get; set; }  
    }
}
