using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using __FollowingAlong.Monads;
using Xunit;

namespace __FollowingAlong.TutorialTests
{
    public class Tutorial03Tests
    {
        [Fact]
        public void Bind_ShouldAllow()
        {
            string testString = "testing123";
            Box<int> testInt = new(5);
            Box<string> result = testInt.Bind(i => new Box<string>($"{testString}-{i}"));
            Assert.Equal($"{testString}-{testInt.Item}", result.Item);
        }
    }
}
