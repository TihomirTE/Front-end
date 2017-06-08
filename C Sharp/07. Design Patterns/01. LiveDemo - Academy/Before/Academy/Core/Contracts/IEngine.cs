using Academy.Models.Contracts;
using System.Collections.Generic;

namespace Academy.Core.Contracts
{
    public interface IEngine
    {
        void Start();

        IReader Reader { get; set; }

        IWriter Writer { get; set; }

        IParser Parser { get; set; }
    }
}
