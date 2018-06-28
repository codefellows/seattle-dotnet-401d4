using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoClass17.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
		string value = await APICall();
            return View();
        }

		public async Task<string> APICall()
		{
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://playlists.azurewebsites.net/");

				var response = client.GetAsync("api/Song/1").Result;

				var result = await response.Content.ReadAsStringAsync();

				string stringResult = await response.Content.ReadAsStringAsync();

			}

			return "";
		}
    }
}