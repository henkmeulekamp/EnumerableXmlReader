using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Meulekamp.EnumerableXmlReader.UnitTests.Model;
using NUnit.Framework;

namespace Meulekamp.EnumerableXmlReader.UnitTests
{
    [TestFixture]
    public class EnumerableXmlReaderTests
    {
        [Test]
        [TestCase("c:\tempt\test.xml")]
        [TestCase("")]
        [TestCase(" ")]    
        public void FileNotfound(string file)
        {
            Assert.Throws<ArgumentException>(() => GetEnumerableXmlReader(file));
        }

        [Test]
        public void StreamEmployees()
        {
            using (var reader = GetEnumerableXmlReader())
            {
                int numberOfEmployees = reader.Stream<Employee>().Count();

                Trace.WriteLine(string.Format("{0} Employees found", numberOfEmployees));

                Assert.Greater(numberOfEmployees, 0);
            }            
        }

        [Test]
        public void FirstEmployee()
        {
            using (var reader = GetEnumerableXmlReader())
            {
                var employee = reader.Stream<Employee>().First();

                Assert.IsNotNull(employee);

                Assert.IsNotNullOrEmpty(employee.EmployeeID);
            }
        }

        [Test]
        public void FirstEmployeeHasTerretories()
        {
            using (var reader = GetEnumerableXmlReader())
            {
                var employee = reader.Stream<Employee>().First();

                Assert.IsNotNull(employee);

                Assert.True(employee.EmployeeTerritories.Any());
            }
        }
        
        private static EnumerableXmlReaders.EnumerableXmlReader GetEnumerableXmlReader(string xmlfile = null)
        {
            var file = xmlfile ?? GetSampleFile();

            var reader = new EnumerableXmlReaders.EnumerableXmlReader(file);
            return reader;
        }

        private static string GetSampleFile()
        {
            //need to go from:  source\ParkMobile.ParkingPolicyXmlReader\bin\Debug
            string file = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\..\\..\\SamplesFiles\\SouthWind.xml");
            return file;
        }
    }
}
