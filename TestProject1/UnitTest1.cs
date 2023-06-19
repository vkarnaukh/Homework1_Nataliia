using Homework1_Nataliia;
using System.Text.RegularExpressions;

namespace TestProject1
{
    public class Tests
    {
        Person person;
        public static bool ValidateName(string name)
        {
            string pattern = @"^[^\d\s]{1,30}$";
            return Regex.IsMatch(name, pattern);
        }
        [SetUp]
        public void Setup()
        {
            person = new Person();
            person.People = new List<Person>()
            {
                new Person(){FN = "Jerry", LN = "Mouse", DOB = new DateTime(2022,07,07), INN = "AA0123456789"},
                new Person(){FN = "Tom", LN = "Cat", DOB = new DateTime(2022,07,07), INN = "AA0123456788"},
                new Person(){FN = "Aleks", LN = "Smith", DOB = new DateTime(2020,07,07), INN = "AA0123456799"},
                new Person(){FN = "Megan", LN = "Fox", DOB = new DateTime(1986,05,16), INN = "BB0123456789"}
            };
        }

        [TestCase("", false)]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", false)]
        [TestCase("Sofia", true)]
        public void FirstNameWithCorrectValueTest(string testData, bool expected)
        {
            Assert.That(ValidateName(testData), Is.EqualTo(expected));
        }
        [TestCase("")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [TestCase("Альпака")]
        public void SetIncorrectFirstName_ThrowsArgumentException(string name)
        {
            Assert.Throws<ArgumentException>(() => person.FN = name);
        }
        [TestCase("")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [TestCase("Капібара")]
        public void SetIncorrectLastName_ThrowsArgumentException(string name)
        {
            Assert.Throws<ArgumentException>(() => person.LN = name);
        }
        [TestCase("2024, 7, 11")]
        [TestCase("2025, 7, 11")]
        [TestCase("2026, 7, 11")]
        public void SetIncorrectDayOfBirth_ThrowsArgumentException(string birthday)
        {
            DateTime dt = DateTime.Parse(birthday);
            Assert.Throws<ArgumentException>(() => person.DOB = dt);
        }
        [TestCase("AA01234567890")]
        [TestCase("Aa01234567890")]
        [TestCase("І тут капібара")]
        public void SetIncorrectInn_ThrowsArgumentException(string number)
        {
            Assert.Throws<ArgumentException>(() => person.INN = number);
        }
        [TestCase("AA0123456789")]
        [TestCase("AA0123456788")]
        [TestCase("AA0123456799")]
        [TestCase("BB0123456789")]
        public void SearchByCorrectINN_ReturnsExistingPerson(string inn)
        {
            var actualPerson = person.People.Find(x => x.INN == inn);
            Assert.That(actualPerson, Is.EqualTo(person.SearchByInn(inn)));
        }
        [TestCase("AA01234567891")]
        [TestCase("AA01234567881")]
        [TestCase("AA01234567991")]
        [TestCase("BB01234567891")]
        public void SearchByIncorrectInn_ThrowsArgumentException(string inn)
        {
            Assert.Throws<ArgumentException>(() => person.SearchByInn(inn));
        }
        [TestCase("Tom", "")]
        [TestCase("Jerry", "")]
        [TestCase("", "Smith")]
        [TestCase("", "Fox")]
        public void SearchByCorrectFNOrLN_ReturnsExistingPerson(string name, string lastName)
        {
            var actualPerson = string.IsNullOrEmpty(name) ? person.People.Find(x => x.LN == lastName) : person.People.Find(x => x.FN == name);
            Assert.That(actualPerson, Is.EqualTo(person.SearchByFNorLN(name, lastName)));
        }
        [TestCase("Tomz", "")]
        [TestCase("Jerryz", "")]
        [TestCase("", "Smithz")]
        [TestCase("", "Foxz")]
        public void SearchByIncorrectFNOrLN_ThrowsArgumentException(string name, string lastName)
        {
            Assert.Throws<ArgumentException>(() => person.SearchByFNorLN(name, lastName));
        }
        [TestCase("John", "qwe", "1990,04,04", "AQ0123456789")]
        [TestCase("Bob", "qwer", "1990,04,04", "AW0123456789")]
        [TestCase("Lee", "qwert", "1990,04,04", "AE0123456789")]
        [TestCase("Phil", "qwerty", "1990,04,04", "AR0123456789")]
        public void AddingCorrectPerson_PersonAddedToList(string name, string lastName, string birthday, string inn)
        {
            int expectedRes = person.People.Count + 1;
            person.AddPerson(new Person() { FN = name, LN = lastName, DOB = DateTime.Parse(birthday), INN = inn });
            int actualRes = person.People.Count;
            Assert.That(expectedRes, Is.EqualTo(actualRes));
        }
        [TestCase("Jerry", "Mouse", "2022,07,07", "AA0123456789")]
        [TestCase("Tom", "Cat", "2022,07,07", "AA0123456788")]
        [TestCase("Aleks", "Smith", "2022,07,07", "AA0123456799")]
        [TestCase("Megan", "Fox", "2022,07,07", "BB0123456789")]
        public void AddingExistingPerson_ThrowsArgumentException(string name, string lastName, string birthday, string inn)
        {
            Assert.Throws<ArgumentException>(() => person.AddPerson(new Person() { FN = name, LN = lastName, DOB = DateTime.Parse(birthday), INN = inn }));
        }
    }
}