using System;

namespace HumanFactory
{
    public class HumanFactory
    {
        public void MakeHuman(int humanNumber)
        {
            var humanInstance = new Human()
            {
                Age = humanNumber
            };

            if (humanNumber % 2 == 0)
            {
                humanInstance.Name = "Popeye";
                humanInstance.Gender = Gender.Man;
            }
            else
            {
                humanInstance.Name = "Maria";
                humanInstance.Gender = Gender.Women;
            }
        }
    }
}
