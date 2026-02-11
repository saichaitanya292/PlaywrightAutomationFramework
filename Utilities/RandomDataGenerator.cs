using System;

namespace PlaywrightAutomation.Utilities
{
    public static class RandomDataGenerator
    {
        private static readonly Random _random = new();

        public static string GetRandomEmail()
        {
            return $"test{Guid.NewGuid():N}@mail.com";
        }

        public static string GetRandomFirstName()
        {
            string[] names = { "Sai", "Arjun", "David", "John", "Ravi" };
            return names[_random.Next(names.Length)];
        }

        public static string GetRandomLastName()
        {
            string[] names = { "Kumar", "Smith", "Reddy", "Brown", "Goud" };
            return names[_random.Next(names.Length)];
        }

        public static string GetRandomMobileNumber()
        {
            return "9" + _random.Next(100000000, 999999999);
        }

        public static string GetRandomAddress()
        {
            return $"Street {_random.Next(1, 999)}, Hyderabad";
        }

        public static string GetRandomZipCode()
        {
            return _random.Next(100000, 999999).ToString();
        }
    }
}
