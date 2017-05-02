using System;
using SchoolSystem.Enums;

namespace SchoolSystem.Models
{
    public class Mark
    {
        private const float MinValue = 2.00f;
        private const float MaxValue = 6.00f;

        private float value;
        private Subject subject;

        public Mark(Subject subject, float value)
        {
            this.subject = subject;
            this.value = value;
        }

        public Subject Subject { get; set; }

        public float Value
        {
            get
            {
                return this.value;
            }

            private set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new ArgumentOutOfRangeException($"The mark value must be between {MinValue} and {MaxValue}");
                }

                this.value = value;
            }
        }
    }
}
