namespace Academy.Tests.Commands.Adding.Mock
{
    using Academy.Commands.Adding;
    using Academy.Core.Contracts;

    // make this class for testing the internal class AddStudentToSeasonCommand
    internal class AddStudentToSeasonCommnadMock : AddStudentToSeasonCommand
    {
        public AddStudentToSeasonCommnadMock(IAcademyFactory factory, IEngine engine)
            : base(factory, engine)
        {
        }

        public IAcademyFactory AcademyFactory
        {
            get
            {
                return this.factory;
            }
        }

        public IEngine Engine
        {
            get
            {
                return this.engine;
            }
        }
    }
}

