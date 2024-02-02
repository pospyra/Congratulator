namespace Contracts
{
    public class InfoPersonResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateBirthday { get; set; }
        public string? KodBase64 { get; set; }
    }
}
