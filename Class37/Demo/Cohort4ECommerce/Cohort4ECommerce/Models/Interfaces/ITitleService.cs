using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cohort4ECommerce.Models
{
    public interface ITitleService
    {
		List<Post> GetTopTitles(int number);
    }
}
