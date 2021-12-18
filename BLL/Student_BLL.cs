using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class Student_BLL
    {
        private Student_DAL Student_DAL;

        public Student_BLL() 
        { 
            Student_DAL = new Student_DAL(); 
        }
        public List<Student_Entity> GetStudents() 
        {
            return Student_DAL.GetStudents(); 
        }
        public void AddStudent(Student_Entity student)
        {
            Student_DAL.AddStudent(student);
        }
        public void UpdateStudent(Student_Entity student)
        {
            Student_DAL.UpdateStudent(student);
        }
        public void DeleteStudent(int student)
        {
            Student_DAL.DeleteStudent(student);
        }
        public List<Student_Entity> SearchStudent(string column, string key)
        {
            return Student_DAL.SearchStudent(column, key);
        }
    }
}
