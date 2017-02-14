namespace Academy.Tests.Commands.Adding.Mock
{
    using Academy.Commands.Adding;
    using Academy.Core.Contracts;

    internal class AddStudentToCourseCommandMock : AddStudentToCourseCommand
    {
        public AddStudentToCourseCommandMock(IAcademyFactory factory, IEngine engine) 
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
