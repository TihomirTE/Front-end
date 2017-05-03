using System;
using System.Text.RegularExpressions;
using SchoolSystem.Models.Contracts;

namespace SchoolSystem.Models.Abstraction
{
    public abstract class Person : IPerson
    {
        private const int MinFirstNameLenght = 2;
        private const int MaxFirstNameLenght = 31;

        private readonly string acceptedSymbolsMessage = $"must contain only latin characters.";
        private readonly string acceptedSymbolLength = $"be between {MinFirstNameLenght} and {MaxFirstNameLenght} symbols.";

        private string firstName;
        private string lastName;

        protected Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (!Regex.Match(value, "^[A-Za-z]+$").Success)
                {
                    throw new ArgumentException($"FirstName {this.acceptedSymbolsMessage}");
                }

                if (value.Length < MinFirstNameLenght || value.Length > MaxFirstNameLenght)
                {
                    throw new ArgumentException($"LastName {this.acceptedSymbolLength}");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (!Regex.Match(value, "^[A-Za-z]+$").Success)
                {
                    throw new ArgumentException($"FirstName {this.acceptedSymbolsMessage}");
                }

                if (value.Length < MinFirstNameLenght || value.Length > MaxFirstNameLenght)
                {
                    throw new ArgumentException($"LastName {this.acceptedSymbolLength}");
                }

                this.lastName = value;
            }
        }
    }
}
