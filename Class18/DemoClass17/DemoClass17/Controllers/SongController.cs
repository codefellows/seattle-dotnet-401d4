using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoClass17.Data;
using DemoClass17.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoClass17.Controllers
{
	[Route("api/[controller]")]
	//[ApiController]
	public class SongController : ControllerBase
	{
		private MusicDbContext _context;

		public SongController(MusicDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IEnumerable<Song> Get()
		{
			return _context.Songs;
		}

		[HttpGet("{id}", Name ="Get")]

		public IActionResult GetSong([FromRoute]int id)
		{
			var song = _context.Songs.FirstOrDefault(s => s.ID == id);
			if(song == null)
			{
				return NotFound();
			}
			return Ok(song);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody]Song song)
		{
			await _context.Songs.AddAsync(song);
			await _context.SaveChangesAsync();

			return CreatedAtRoute("Get", new { id = song.ID }, song);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Song song)
		{

			if(id != song.ID)
			{
				return BadRequest(ModelState);
			}
			// checks to see if it exists,
			var result = _context.Songs.FirstOrDefault(s => s.ID == id);

			if(result == null)
			{
				return RedirectToAction("Post", song);
			}

			result.Name = song.Name;
			result.Artist = song.Artist;
			result.Album = song.Album;

			//result = song;

			_context.Songs.Update(result);
			//_context.Entry(song).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			await _context.SaveChangesAsync();

			return Ok();
		}

		//[HttpDelete]

	}
}