using __FollowingAlong.Monads;
using System;
using Xunit;

namespace __FollowingAlong.Tutorials
{
    public class Tutorial01Tests
    {
        [Fact(DisplayName = "Selecting x => x + 5 via fluent syntax should return a value 5 higher")]
        public void SelectFluentAdd5_ShouldReturn5Higher()
        {
            Box<int> box = new(1);
            Assert.Equal(6, box.Select(x => x + 5).Item);
        }

        [Fact(DisplayName = "Selecting x => x + 5 via query syntax should return a value 5 higher")]
        public void SelectQueryAdd5_ShouldReturn5Higher()
        {
            Box<int> box = new(3);
            var result = from x in box
                         select x + 5;
            Assert.Equal(8, result.Item);
        }
    }
}
