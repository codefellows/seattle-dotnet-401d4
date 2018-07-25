using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cohort4ECommerce.Models
{
    public interface ICMSRepo
    {
		Task<IActionResult> CreatePost(Post post);
		Task<IActionResult> GetPostById(int id);
		Task<IActionResult> GetPosts();
		Task<IActionResult> UpdatePost(int id, Post post);
		Task<IActionResult> DeletePost(int id);
    }
}
