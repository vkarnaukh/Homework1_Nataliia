using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Homework1_Nataliia
{
    public class Person
    {
        private string _fn;
        private string _ln;
        private DateTime _dob;
        private string _inn;
        public string FN
        {
            get { return _fn; }
            set
            {
                if (value.Length > 30)
                {
                    Console.WriteLine("first name should be no more than 30 symbols");
                }
                else if (value.Length < 1)
                {
                    Console.WriteLine("first name should contains at least 1 symbol");
                }
                else if (!Regex.IsMatch(value, "^[a-zA-Z]"))
                {
                    Console.WriteLine("only latin symbols are allowed");
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
                    Console.WriteLine("last name should be no more than 30 symbols");
                }
                else if (value.Length < 1)
                {
                    Console.WriteLine("last name should contains at least 1 symbol");
                }
                else if (!Regex.IsMatch(value, "^[a-zA-Z]"))
                {
                    Console.WriteLine("only latin symbols are allowed");
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
                    Console.WriteLine("DOB should be not later that today date");
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
                    Console.WriteLine("INN must satisfy pattern: < upper_case >< upper_case >< 10digit >");
                }
                else { _inn = value; }
            }
        }
    }
}




