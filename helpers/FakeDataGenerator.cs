using Bogus;

namespace WebAutomationPratique.helpers {
    public class FakeDataGenerator {

        private Faker generator;

        public FakeDataGenerator() {
            generator = new Faker();
        }

        public string FirstName => generator.Name.FirstName();

        public string LastName => generator.Name.LastName();

        public string Email => generator.Internet.Email().ToLower();

        public string City => generator.Address.City();

        public string PostlCode => generator.Address.CountryCode();

        public string MobilePhone => generator.Phone.PhoneNumber();

        public string Address => generator.Address.StreetAddress();

        public string Componay => generator.Company.CompanyName();

    }

}
