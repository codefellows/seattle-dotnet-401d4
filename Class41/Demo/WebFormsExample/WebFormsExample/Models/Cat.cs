using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebFormsExample.Models
{
    public class Cat
    {
        [Key, Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public void SaveCat(Cat cat)
        {
            string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

            using (SqlConnection sqlcon = new SqlConnection(con))
            {
                SqlCommand cmd;
                sqlcon.Open();
                cmd = new SqlCommand("insert into Cat(Name, Age) values " +
                                     "(@Name,@Age)");
                cmd.Connection = sqlcon;
                cmd.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 50).Value = cat.Name;
                cmd.Parameters.Add("@Age", System.Data.SqlDbType.Int, 50).Value = cat.Age;
                cmd.ExecuteNonQuery();
                sqlcon.Close();
            }
        }


        public static List<Cat> GetCats()
        {
            List<Cat> myCats = new List<Cat>();
            string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

            using (SqlConnection sqlcon = new SqlConnection(con))
            {
                SqlCommand cmd;
                sqlcon.Open();
                cmd = new SqlCommand("Select * From Cat");
                cmd.Connection = sqlcon;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cat cc = new Cat();
                    cc.Name = reader[1].ToString();
                    cc.Age = Convert.ToInt32(reader[2]);
                    myCats.Add(cc);
                }
                sqlcon.Close();
            }

            return myCats;
        }
    }
}