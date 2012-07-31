
namespace Meulekamp.EnumerableXmlReader.UnitTests.Model
{

    [System.SerializableAttribute()]
    public class Employees
    {

        private Employee[] itemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Employee")]
        public Employee[] Items
        {
            get { return this.itemsField; }
            set { this.itemsField = value; }
        }
    }


    [System.SerializableAttribute()]
    public  class Employee
    {

        private string lastNameField;

        private string firstNameField;

        private string titleField;

        private string titleOfCourtesyField;

        private string birthDateField;

        private string hireDateField;

        private string addressField;

        private string cityField;

        private string regionField;

        private string postalCodeField;

        private string extensionField;

        private string photoField;

        private string notesField;

        private string reportsToField;

        private EmployeeTerritorie[] employeeTerritoriesField;

        private string employeeIDField;

        /// <remarks/>
        public string LastName
        {
            get { return this.lastNameField; }
            set { this.lastNameField = value; }
        }

        /// <remarks/>
        public string FirstName
        {
            get { return this.firstNameField; }
            set { this.firstNameField = value; }
        }

        /// <remarks/>
        public string Title
        {
            get { return this.titleField; }
            set { this.titleField = value; }
        }

        /// <remarks/>
        public string TitleOfCourtesy
        {
            get { return this.titleOfCourtesyField; }
            set { this.titleOfCourtesyField = value; }
        }

        /// <remarks/>
        public string BirthDate
        {
            get { return this.birthDateField; }
            set { this.birthDateField = value; }
        }

        /// <remarks/>
        public string HireDate
        {
            get { return this.hireDateField; }
            set { this.hireDateField = value; }
        }

        /// <remarks/>
        public string Address
        {
            get { return this.addressField; }
            set { this.addressField = value; }
        }

        /// <remarks/>
        public string City
        {
            get { return this.cityField; }
            set { this.cityField = value; }
        }

        /// <remarks/>
        public string Region
        {
            get { return this.regionField; }
            set { this.regionField = value; }
        }

        /// <remarks/>
        public string PostalCode
        {
            get { return this.postalCodeField; }
            set { this.postalCodeField = value; }
        }

        /// <remarks/>
        public string Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }

        /// <remarks/>
        public string Photo
        {
            get { return this.photoField; }
            set { this.photoField = value; }
        }

        /// <remarks/>
        public string Notes
        {
            get { return this.notesField; }
            set { this.notesField = value; }
        }

        /// <remarks/>
        public string ReportsTo
        {
            get { return this.reportsToField; }
            set { this.reportsToField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("EmployeeTerritorie",
            typeof(EmployeeTerritorie), IsNullable = false)]
        public EmployeeTerritorie[] EmployeeTerritories
        {
            get { return this.employeeTerritoriesField; }
            set { this.employeeTerritoriesField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string EmployeeID
        {
            get { return this.employeeIDField; }
            set { this.employeeIDField = value; }
        }
    }

    [System.SerializableAttribute()]
    public  class EmployeeTerritorie
    {

        private string territoryIDField;

        /// <remarks/>
        public string TerritoryID
        {
            get { return this.territoryIDField; }
            set { this.territoryIDField = value; }
        }
    }
}