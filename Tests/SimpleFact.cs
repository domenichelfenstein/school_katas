namespace Tests
{
    using FluentAssertions;
    using Xunit;

    public class SimpleFact
    {
        [Fact]
        public void Test()
        {
            1.Should().Be(2);
        }
    }
}