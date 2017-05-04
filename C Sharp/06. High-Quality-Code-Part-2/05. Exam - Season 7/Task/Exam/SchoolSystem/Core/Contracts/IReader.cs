namespace SchoolSystem.Core.Contracts
{
    /// <summary>
    /// Interface for Reader provider.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Reads the data from a specific source.
        /// </summary>
        /// <returns>Returns the read data as string</returns>
        string ReadLine();
    }
}
