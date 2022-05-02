using System;
namespace TheaterAPI.Models
{
	public class Movie
	{
		public int MovieId { get; set; }
		public string? Name { get; set; }
		public string? Genre { get; set; }
        public string? Director { get; set; }

		//Navigation Properties
		//foreign key
		public int? TheatreId { get; set; }
		
    }
}

