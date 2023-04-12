namespace ServiceNowComparerLibrary.Tests
{
    public class CryptoModuleTests
    {
        [Theory]
        [InlineData("*'#§$%&/()=?")]
        [InlineData("1234567890")]
        [InlineData("qwertzzuiopsdfghjk")]
        [InlineData("isduzf8237tt4")]
        public void CreateSHA512_ShouldHash(string input)
        {
            Assert.True(!String.IsNullOrEmpty(CryptoModule.CreateSHA512(input)));
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("")]
        public void CreateSHA512_ShouldThrowException(string input)
        {
            Assert.Throws<ArgumentException>(() => CryptoModule.CreateSHA512(input));
        }
    }
}