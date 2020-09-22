using System;

namespace CinemaManagementSystem.Domain.Common.Models
{
    public static class Guard
    {
        public static void AgainstEmptyStringException<TException>(string value, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (!string.IsNullOrEmpty(value))
            {
                return;
            }

            ThrowException<TException>($"{name} cannot be null or empty");
        }


        public static void ForStringLength<TException>(string value, int minLength, int maxLength, string name = "Value")
            where TException : BaseDomainException, new()
        {
            AgainstEmptyStringException<TException>(value, name);

            if (minLength <= value.Length && maxLength >= value.Length)
            {
                return;
            }

            ThrowException<TException>($"{name} must have between {minLength} and {maxLength} symbols.");
        }

        public static void AgainstOutOfRange<TException>(int number, int min, int max, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (min <= number && number <= max)
            {
                return;
            }

            ThrowException<TException>($"{number} must be between {min} and {max}.");
        }

        public static void AgainstOutOfRange<TException>(double number, double min, double max, string name = "Value")
             where TException : BaseDomainException, new()
        {
            if (min <= number && number <= max)
            {
                return;
            }

            ThrowException<TException>($"{number} must be between {min} and {max}.");
        }

        public static void AgainstNullReferece<TException>(object value)
            where TException : BaseDomainException, new()
        {
            if (value != null)
            {
                return;
            }

            ThrowException<TException>($"{value} must not be null");
        }

        public static void AgainstInvalidDate<TException>(DateTime date, string name = "Value")
            where TException: BaseDomainException, new()
        {
            if (DateTime.Compare(date, DateTime.Now) > 0)
            {
                return;
            }

            ThrowException<TException>($"{name} must be after current date");
        }

        public static void Against<TException>(object actualValue, object unexpectedValue, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (!actualValue.Equals(unexpectedValue))
            {
                return;
            }

            ThrowException<TException>($"{name} must not be {unexpectedValue}");
        }

        private static void ThrowException<TException>(string message)
            where TException : BaseDomainException, new()
        {
            var exception = new TException()
            {
                Error = message
            };

            throw exception;
        }
    }
}
