using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;   
using System.Diagnostics;   

namespace Academy
{
	class Program
	{
		static readonly string delimiter = "\n----------------------------------------------\n";
		const string file_Name = "Group.txt";
		static void Main(string[] args)
		{

#if INHERITANCE
			Human human = new Human("Montana", "Antonio", 25);
			human.Info();
			Console.WriteLine(delimiter);

			Student student = new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_220", 95, 96);
			student.Info();
			Console.WriteLine(delimiter);

			Teacher teacher = new Teacher("White", "Walter", 50, "Chemistry", 25);
			teacher.Info();
			Console.WriteLine(delimiter);

			Human tommy = new Human("Vercetty", "Tommy", 30);
			tommy.Info();
			Console.WriteLine(delimiter);

			Student s_tommy = new Student(tommy, "Theft", "Vice", 95, 98);
			s_tommy.Info();
			Console.WriteLine(delimiter);

			Graduate g_tommy = new Graduate(s_tommy, "How to make money");
			g_tommy.Info();
			Console.WriteLine(delimiter);

			Graduate graduate = new Graduate("Schreder", "Hank", 40, "Criminalistic", "OBN", 70, 80, "How to catch Heizenberg");
			graduate.Info();
			Console.WriteLine(delimiter); 
#endif

			Human[] humans_to_File = new Human[]
				{
					new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_220", 95, 96),
					new Teacher("White", "Walter", 50, "Chemistry", 25),
					new Graduate("Vercetty", "Tommy", 30, "Theft", "Vice", 95, 98, "How to make money"),
					new Graduate("Schreder", "Hank", 40, "Criminalistic", "OBN", 70, 80, "How to catch Heizenberg"),
					new Teacher("Diaz", "Ricardo", 50, "Weapons distribution", 20)
				};

			StreamWriter sw = new StreamWriter(file_Name);
			Console.WriteLine(delimiter);
			Console.WriteLine("To File:");
			for (int i = 0; i < humans_to_File.Length; i++)
			{
				Console.WriteLine(humans_to_File[i]);
				sw.WriteLine(humans_to_File[i].ToFileString());
			}

			Process.Start("notepad.exe", "Group.txt");
			sw.Close();
			Console.WriteLine(delimiter);

			///////////////////////////////////////////////////////////////////////////////////////////////////

			Human[] humans_from_File = new Human[] { };

			foreach (var s in File.ReadAllLines(file_Name))
			{
				string[] str = s.Split(',');

				switch (str[0].Split(':')[0])
				{
					case "Student":
						humans_from_File = humans_from_File.Append(new Student(str[0].Split(':')[1], str[1], Convert.ToInt32(str[2]), str[3], str[4], Convert.ToDouble(str[5]), Convert.ToDouble(str[6]))).ToArray();
						break;
					case "Human":
						humans_from_File = humans_from_File.Append(new Human(str[0].Split(':')[1], str[1], Convert.ToInt32(str[2]))).ToArray();
						break;
					case "Teacher":
						humans_from_File = humans_from_File.Append(new Teacher(str[0].Split(':')[1], str[1], Convert.ToInt32(str[2]), str[3], Convert.ToDouble(str[4]))).ToArray();
						break;
					case "Graduate":
						humans_from_File = humans_from_File.Append(new Graduate(str[0].Split(':')[1], str[1], Convert.ToInt32(str[2]), str[3], str[4], Convert.ToDouble(str[5]), Convert.ToDouble(str[6]), str[7])).ToArray();
						break;
				}

			}
			Console.WriteLine(delimiter);
			Console.WriteLine("From File:");

			for (int i = 0; i < humans_from_File.Length; i++)
			{
				Console.WriteLine(humans_from_File[i]);
			}
			Console.WriteLine(delimiter);

			
		}
	}
}
