using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOApp
{
    class Course
    {
        public string Code { get; }
        public string Description { get; }
        public string Name { get; }
        public string Prerequisites { get; }
        public int Semester { get; }

        //contructor
        public Course(string code,
            string name,
            string description,
            string semester,
            string prerequisites)
        {
            Code = code;
            Description = description;
            Name = name;
            Prerequisites = prerequisites;
            Semester = int.Parse(semester);
        }

        public override string ToString()
        {
            string result;

            result = " - " + (Code.Length <= 7 ? Code : Code.Substring(0, 7));
            result += ": " + (Description.Length <= 40 ? Description : Description.Substring(0, 40));

            return result;
        }
    }
}
