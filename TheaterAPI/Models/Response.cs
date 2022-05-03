using System;
namespace TheaterAPI.Models
{
	//Response Model Class
	public class Response
	{
		public int StatusCodes { get; set; }
		public string StatusDescription { get; set; }
		public List<Movie> Movies { get; set; } = new();
		public List<Theatre> Theatres { get; set; } = new();
	}
}


