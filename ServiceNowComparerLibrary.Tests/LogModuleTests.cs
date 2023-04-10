namespace ServiceNowComparerLibrary.Tests
{
    public class LogModuleTests
    {
        [Fact]
        /// <summary>
        /// Just to check if logging works at all ;)
        /// </summary>
        public void WriteInformation_SimpleMessage()
        {
            LogModule.WriteInformation("Test");
        }
    }
}