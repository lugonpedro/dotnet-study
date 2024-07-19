using dotnet_study.Data;
using dotnet_study.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_study.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<SuperHero>> Add(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(hero);
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAll()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();

            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetById(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero is null)
                return NotFound("Hero not found");

            return Ok(hero);
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> Update(SuperHero hero)
        {
            var oldHero = await _context.SuperHeroes.FindAsync(hero.Id);

            if(oldHero is null)
                return NotFound("Hero not found");

            oldHero.Name = hero.Name;
            oldHero.FirstName = hero.FirstName;
            oldHero.LastName = hero.LastName;
            oldHero.Place = hero.Place;

            await _context.SaveChangesAsync();

            return Ok(hero);
        }

        [HttpDelete]
        public async Task<ActionResult<SuperHero>> Delete(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero is null)
                return NotFound("Hero not found");

            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();

            return Ok(hero);
        }
    }
}
