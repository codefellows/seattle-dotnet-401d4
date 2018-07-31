using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsExample.Models;

namespace WebFormsExample.Cats
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				Cat cat = new Cat();
				cat.Name = "Amanda";
				cat.Age = 21;
				header.InnerText = "Here is our message";

				CatDataBind();
			}
		}

		protected void CatDataBind()
		{
			List<Cat> myCats = Cat.GetCats();
			CatList.DataSource = myCats;
			CatList.DataBind();

		}

		protected void OnClick(object sender, EventArgs e)
		{
			Cat cat = new Cat();

			cat.Name = CatName.Text;
			cat.Age = Convert.ToInt16(CatAge.Text);
			cat.SaveCat(cat);

			CatDataBind();
		}

		protected void MyNewButton_Click(object sender, EventArgs e)
		{
			header.InnerText = "My Button was clicked";
		}
	}
}