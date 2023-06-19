using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Homework1_Nataliia
{
    public class Person : IPersonRepository
    {
        private string _fn;
        private string _ln;
        private DateTime _dob;
        private string _inn;
        public List<Person> People { get; set; }
        public string FN
        {
            get { return _fn; }
            set
            {
                if (value.Length > 30)
                {
                    throw new ArgumentException("first name should be no more than 30 symbols");
                }
                else if (value.Length < 1)
                {
                    throw new ArgumentException("first name should contains at least 1 symbol");
                }
                else if (!Regex.IsMatch(value, "^[a-zA-Z]"))
                {
                    throw new ArgumentException("only latin symbols are allowed");
                }
                else
                {
                    _fn = value;
                }
            }
        }

        public string LN
        {
            get { return _ln; }
            set
            {
                if (value.Length > 30)
                {
                    throw new ArgumentException("first name should be no more than 30 symbols");
                }
                else if (value.Length < 1)
                {
                    throw new ArgumentException("first name should contains at least 1 symbol");
                }
                else if (!Regex.IsMatch(value, "^[a-zA-Z]"))
                {
                    throw new ArgumentException("only latin symbols are allowed");
                }
                else
                {
                    _ln = value;
                }
            }
        }
        public DateTime DOB
        {
            get { return _dob; }
            set
            {
                if (value.Date > DateTime.Now)
                {
                    throw new ArgumentException("DOB should be not later that today date");
                }
                else
                {
                    _dob = value;
                }
            }
        }
        public string INN
        {
            get { return _inn; }
            set
            {
                if (!Regex.IsMatch(value, "^[A-Z]{2}[0-9]{10}$"))
                {
                    throw new ArgumentException("INN must satisfy pattern: < upper_case >< upper_case >< 10digit >");
                }
                else { _inn = value; }
            }
        }
        public Person SearchByInn(string inn)
        {
            foreach (Person person in People)
            {
                if (person.INN.Contains(inn))
                {
                    return person;
                }
            }
            throw new ArgumentException("Person with reqiered INN doesn't exists in the system");
        }
        public Person SearchByFNorLN(string name, string lastName)
        {
            if (string.IsNullOrEmpty(name))
            {
                foreach (Person person in People)
                {
                    if (person.LN.Contains(lastName))
                    {
                        return person;
                    }
                }
            }
            else if (string.IsNullOrEmpty(lastName))
            {
                foreach (Person person in People)
                {
                    if (person.FN.Contains(name))
                    {
                        return person;
                    }
                }
            }
            throw new ArgumentException("Person with reqiered First or Last name doesn't exists in the system");
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Person personToCheck = (Person)obj;
            return FN == personToCheck.FN && LN == personToCheck.LN && INN == personToCheck.INN;
        }
        public override int GetHashCode()
        {
            return FN.GetHashCode() + LN.GetHashCode() + DOB.GetHashCode() + INN.GetHashCode();
        }
        public void AddPerson(Person personToAdd)
        {
            bool exist = false;
            if (personToAdd != null)
            {
                foreach (Person person in People)
                {
                    if (person.Equals(personToAdd))
                    {
                        exist = true;
                        throw new ArgumentException("This person exists in the system");
                    }
                }
                if (!exist)
                {
                    People.Add(personToAdd);
                }
            }
        }
    }
}




