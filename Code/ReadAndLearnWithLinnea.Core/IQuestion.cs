using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public interface IQuestion
    {
        string Text { get; }
        IEnumerable<string> Answers { get; }
    }
}