using GameShop.Data;
using GameShop.Models;
using GameShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Controllers
{
    public class GameController : Controller
    {
        private readonly AppDbContext _context;

        public GameController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> AllGames()
        {
            var games = await _context.Games.ToListAsync();
            return View(games);
        }

        [Authorize]
        public IActionResult AddGame()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(AddGameViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var game = new Game()
                {
                    GameName = viewModel.GameName,
                    ReleaseDate = viewModel.ReleaseDate,
                    GamePrice = viewModel.GamePrice
                };

                await _context.Games.AddAsync(game);
                await _context.SaveChangesAsync();

                return RedirectToAction("AllGames");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditGame(int id)
        {            
            //var game = await _context.Games.FindAsync(id);
            var game = await _context.FindAsync<Game>(id);
            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> EditGame(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Update(game);
                await _context.SaveChangesAsync();

                return RedirectToAction("AllGames");
            }

            return View();
        }


        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.Games.FindAsync(id);

            if(ModelState.IsValid)
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
            }
            return RedirectToAction("AllGames");
        }
    }
}
