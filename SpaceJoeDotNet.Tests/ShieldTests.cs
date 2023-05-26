using SpaceJoeDotNet.Item;
using Xunit;

namespace SpaceJoeDotNet.Tests
{
    public class ShieldTests
    {
        [Theory]
        [InlineData(50, 100, 50)]
        [InlineData(1, 1, 0)]
        [InlineData(20, 5, 0)]
        public void TakeDamage_ShouldReturnRemainingDamage(int shieldPoints, int damage, int expected)
        {
            var s = new Shield(shieldPoints, 200, 200);
            int actual = s.TakeDamage(damage);
            Assert.Equal(expected, actual);
        }
    }
}
