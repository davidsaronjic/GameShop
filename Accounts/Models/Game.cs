using System.ComponentModel.DataAnnotations;

namespace GameShop.Models
{
	public class Game
	{
		public int Id { get; set; }

		[Required(ErrorMessage ="Game name is required")]
		public string GameName { get; set; }

		[Required(ErrorMessage ="Release date is required")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ReleaseDate { get; set; }

		[Required(ErrorMessage ="Price is required")]
		public double? GamePrice { get; set; }
	}
}
