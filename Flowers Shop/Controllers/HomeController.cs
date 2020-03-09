using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Flowers_Shop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Flowers_Shop.Controllers {
	public class HomeController : Controller {
		private readonly ILogger<HomeController> _logger;

		IWebHostEnvironment _wwwRoot;
		MusicContext _context;
		public HomeController(MusicContext context, IWebHostEnvironment wwwRoot)
		{
			_wwwRoot = wwwRoot;
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Way()
		{
			return View();
		}
		public IActionResult Music()
		{
			return View();
		}

		public IActionResult GetMusic()
		{
			var musics = _context.PlayMusics.ToList();
			return Json(musics);
		}

		[HttpPost]
		public IActionResult Music(IList<IFormFile> download)
		{
			//var s = HttpContext.Request.Form["download"];
			foreach (var music in download)
			{
				if (music != null)
				{
					string path = "/Music/" + music.FileName;
					// сохраняем файл в папку Files в каталоге wwwroot
					using (var fileStream = new FileStream(_wwwRoot.WebRootPath + path, FileMode.Create))
					{
						music.CopyTo(fileStream);
					}
					PlayMusic pm = new PlayMusic { FilePath = path, Name = music.FileName };
					_context.PlayMusics.Add(pm);
					_context.SaveChanges();
				}
			}



			return RedirectToAction("Music");
		}


		public IActionResult Privacy()
		{
			return View();
		}
		public IActionResult Muse()
		{
			return View();
		}



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
