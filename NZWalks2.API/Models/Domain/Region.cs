﻿namespace NZWalks2.API.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        
        public string? RegionImgUrl { get; set; }

    }
}
