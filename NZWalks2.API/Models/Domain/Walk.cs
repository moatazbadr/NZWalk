namespace NZWalks2.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Double LengthKm { get; set; }
        public string? WalkImageUrl { get; set; }

        #region RelationShip Definition

        public Guid DifficultyId { get; set; } 
        public Guid RegionId { get; set; }
         
        #endregion


        #region Navigational Properties
        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }

        #endregion


    }
}
