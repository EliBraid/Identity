namespace IdentityWeb.Model
{
    public record House
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }
    }
}
