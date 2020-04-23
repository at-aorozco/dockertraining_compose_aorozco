using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dockertraining_compose_aorozco.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dockertraining_compose_aorozco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GamesContext db;

        public GamesController(GamesContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var games = db.Game;

            return Ok(games);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await db.AddAsync(game);
            await db.SaveChangesAsync();
            return Ok(game.Id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> Delete(int id)
        {
            var movie = await db.Game.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            db.Game.Remove(movie);
            await db.SaveChangesAsync();

            return movie;
        }
    }
}