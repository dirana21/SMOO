using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using LAB_7.Models;

namespace LAB_7.Services
{
    public class XmlStudentRepository : IStudentRepository
    {
        private readonly string _filePath;

        public XmlStudentRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IList<Student> LoadStudents()
        {
            if (!File.Exists(_filePath))
                return new List<Student>();

            var doc = XDocument.Load(_filePath);
            var result = doc.Root?
                .Elements("Student")
                .Select(x => new Student
                {
                    LastName = (string)x.Element("LastName"),
                    FirstName = (string)x.Element("FirstName"),
                    Age = (int?)x.Element("Age") ?? 16,
                    Gender = (string)x.Element("Gender")
                })
                .ToList() ?? new List<Student>();

            return result;
        }

        public void SaveStudents(IList<Student> students)
        {
            var doc = new XDocument(
                new XElement("Students",
                    students.Select(s =>
                        new XElement("Student",
                            new XElement("LastName", s.LastName),
                            new XElement("FirstName", s.FirstName),
                            new XElement("Age", s.Age),
                            new XElement("Gender", s.Gender)
                        ))
                ));

            doc.Save(_filePath);
        }
    }
}
