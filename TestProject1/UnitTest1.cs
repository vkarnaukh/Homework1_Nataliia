using Homework1_Nataliia;

namespace TestProject1
{
    public class Tests
    {
        Person person;
        [SetUp]
        public void Setup()
        {
            person = new Person();
        }

        [TestCase("",false)]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", false)]
        [TestCase("Sofia", true)]
        public void FirstNameWithCorrectValueTest(string testData, bool expected)
        {
            Assert.That(Person.ValidateName(testData), Is.EqualTo(expected));
        }
    }
}