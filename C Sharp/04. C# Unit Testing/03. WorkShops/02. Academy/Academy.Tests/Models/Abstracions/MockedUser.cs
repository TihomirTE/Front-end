namespace Academy.Tests.Models.Abstracions
{
    using Academy.Models.Abstractions;

    internal class MockedUser : User
    {
        public MockedUser(string username) 
            : base(username)
        {
        }
    }
}
