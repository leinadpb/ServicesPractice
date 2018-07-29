using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeASPNETCORE.Data;
using PracticeASPNETCORE.Models;

namespace PracticeASPNETCORE.Services
{
    public class StudentService : IStudents
    {
        private readonly LTIContext _context;

        public StudentService(LTIContext ctx)
        {
            _context = ctx;
        }

        /**
         * When getting the student, please verify it's not Null.
         * Created by: Daniel Peña
         * */
        public Students GetStudent(int id)
        {
            if (id < 0)
            {
                return null;
            }
            else
            {
                var student = _context.Students.Where(s => s.StudentId == id).FirstOrDefault();
                if (student != null)
                {
                    return student;
                }
                else
                {
                    return null;
                }
            }
        }

        /**
         * Objective: Get First {top} students
         * Note(s): Verify the returned list of students is not null.
         * Created by: Daniel Peña
         * */

        public (bool, List<Students>, int) GetStudents(int top)
        {
            bool showingLessThanTop = false;

            if(top <= 0)
            {
                return (true, null, 0);
            }
            else
            {
                var students = _context.Students.Select(s => s);
                List<Students> returnStudents = new List<Students>();
                int counter = 0;
                foreach(Students s in students)
                {
                    if(counter >= top)
                    {
                        break;
                    }

                    returnStudents.Add(s);

                    counter++;
                }
                if (!(counter >= top)) showingLessThanTop = true;
            
                return (showingLessThanTop, returnStudents, returnStudents.Count);
            }
        }
    }
}
