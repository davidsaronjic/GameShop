using System.ComponentModel.DataAnnotations;

namespace GameShop.ViewModels
{
	public class AddGameViewModel
	{
		[Required(ErrorMessage ="Game name is required")]		
		public string GameName { get; set; }


		[Required(ErrorMessage = "Game release date is required")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ReleaseDate { get; set; }


		[Required(ErrorMessage = "Game price is required")]
		public double? GamePrice { get; set; }

	}
}
