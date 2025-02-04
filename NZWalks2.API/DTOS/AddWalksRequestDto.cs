namespace NZWalks2.API.DTOS
{
    public class AddWalksRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Double LengthKm { get; set; }
        public string? WalkImageUrl { get; set; }

        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}
