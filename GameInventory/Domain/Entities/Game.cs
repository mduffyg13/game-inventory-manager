namespace GameInventory.Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? PlatformId { get; set; }
        public Platform? Platform { get; set; }
        public string? Format { get; set; }
        public int? SeriesId { get; set; }
        public Series? Series { get; set; }
        public int? StoreId { get; set; }
        public Store? Store { get; set; }
    }
}