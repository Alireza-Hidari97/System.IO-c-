using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOApp
{
    static class CourseManager
    {
        private static List<Course> courses;

        public static void Display(DisplayOption option, string toMatch = "")
        {
            foreach (Course c in courses)
            {
                switch (option)
                {
                    case DisplayOption.All:
                        if ((c.Code.ToLower() == toMatch.ToLower()) ||
                            (c.Name.ToLower() == toMatch.ToLower()) ||
                            (c.Prerequisites.ToLower().Contains(toMatch.ToLower())) ||
                            (c.Semester.ToString() == toMatch))
                        {
                            Console.WriteLine(c.ToString());
                        }
                        break;
                    case DisplayOption.Code:
                        if (c.Code.ToLower() == toMatch.ToLower())
                        {
                            Console.WriteLine(c.ToString());
                        }
                        break;
                    case DisplayOption.Name:
                        if (c.Name.ToLower() == toMatch.ToLower())
                        {
                            Console.WriteLine(c.ToString());
                        }
                        break;
                    case DisplayOption.Prerequisite:
                        if (c.Prerequisites.ToLower().Contains(toMatch.ToLower()))
                        {
                            Console.WriteLine(c.ToString());
                        }
                        break;
                    case DisplayOption.Semester:
                        if (c.Semester.ToString() == toMatch)
                        {
                            Console.WriteLine(c.ToString());
                        }
                        break;
                }
            }
        }

        public static void LoadCourses(string filename)
        {
           courses = new List<Course>();

            TextReader reader = new StreamReader(filename);

            string line = reader.ReadLine();

            int line_index = 1;

            string code = "";
            string name = "";
            string description = "";
            string semester = "";
            string prerequisites = "";

            while (line != null)
            {
                switch (line_index)
                {
                    case 1:
                        code = line;
                        break;
                    case 2:
                        name = line;
                        break;
                    case 3:
                        description = line;
                        break;
                    case 4:
                        semester = line;
                        break;
                    case 5:
                        prerequisites = line;
                        break;
                }

                if (line_index == 5)
                {
                    //create new course
                    courses.Add(new Course(code, name, description, semester, prerequisites));

                    line_index = 1;
                }
                else
                    line_index++;

                //Console.WriteLine(line);
                line = reader.ReadLine();
            }

            reader.Close();
        }
    }
}
