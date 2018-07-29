using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeASPNETCORE.Models;

namespace PracticeASPNETCORE.Data
{
    public interface IStudents
    {
        Students GetStudent(int id); // Get Student with StudentID = {id}
        (bool, List<Students>, int) GetStudents(int top); // Get First {top} students.
    }
}
