using DemoClass17.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoClass17.Data
{
    public class MusicDbContext : DbContext
    {
		public MusicDbContext(DbContextOptions<MusicDbContext>options):base(options)
		{

		}

		public DbSet<Song> Songs { get; set; }
		public DbSet<Playlist> Playlists { get; set; }

	}
}
