using System;
namespace TheaterAPI.Models
{
	public class Theatre
	{
		public int TheatreId { get; set; }
		public string? Name { get; set; }
		public string? Address { get; set; }
		public string? Phone_no { get; set; }

		//navigation properties -added
		//one to many relationship
		public List<Movie> Movies { get; set; } = new();
	}
}

