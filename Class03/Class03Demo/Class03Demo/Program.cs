using System;
using System.IO;
using System.Text;

namespace Class03Demo
{
    class Program
    {
	    static string path = "../../../MyFile.txt";

		static void Main(string[] args)
        {
            CreateFile();
	        ReadAFile();
			UpdateFile();
			Console.WriteLine("----------");
			ReadAFile();
			DeleteFile();

        }

	    static void CreateFile()
	    {
		    if (!File.Exists((path)))
		    {
				using (StreamWriter sw = new StreamWriter(path))
				{
					sw.Write("This is my file");
				}
			}


			
			//For visibility purposes only....
		    //using (FileStream fs = File.Create(path))
		    //{
			   // //Filesstream requires a byte array to send data to a text file. 
			   // // we have to convert our sentance into a byte array throug hteh utfc encoding.
			   // Byte[] info = new UTF8Encoding(true).GetBytes("List of Words in File");
			   // // Add some information to the file.
			   // fs.Write(info, 0, info.Length);
		    //}

		}

	    static void ReadAFile()
	    {
		    //using (StreamReader sr = File.OpenText(path))
		    //{
			   // string s = "";
			   // while ((s = sr.ReadLine()) != null)
			   // {
				  //  Console.WriteLine(s);
			   // }
			    
		    //}


			// Second way to read a file

		    try
		    {
			    string[] myText = File.ReadAllLines(path);

			    foreach (string value in myText)
			    {
					Console.WriteLine(value);
			    }
			}
		    catch (Exception e)
		    {
			    Console.WriteLine("Something went wrong");
			    
		    }


		  

	    }


	    static void UpdateFile()
	    {
		    using (StreamWriter sw = File.AppendText(path))
		    {
			    sw.WriteLine("Its Wed!!");
		    }
	    }

	    static void DeleteFile()
	    {
		    File.Delete(path);
	    }

		//static string MyMethod(string name, int age)
		//{
		// return "";
		//}

		//static string MyMethod(int age)
		//{
		// return "";
		//}
	}
}
