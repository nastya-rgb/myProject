using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flowers_Shop.Models {
	public class MusicContext : DbContext {
		public DbSet<PlayMusic> PlayMusics { get; set; }
		public MusicContext(DbContextOptions<MusicContext> options) : base(options)
		{
		}

		//protected override void OnConfiguring(DbContextOptionsBuilder options)
		//    => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Musics;Trusted_Connection=True;");
	}
}
