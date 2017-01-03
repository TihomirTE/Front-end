namespace SchoolClasses
{
    using System.Collections.Generic;

    public interface IComment
    {
        List<string> Comments { get; }
         void AddComment(string comment);
    }
}
