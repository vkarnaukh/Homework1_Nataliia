using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1_Nataliia
{
    internal interface IPersonRepository
    {
        public List<Person> People { get; set; }
        public Person SearchByInn(string inn);
        public Person SearchByFNorLN(string name, string lastName);
        public void AddPerson(Person person);
    }
}
