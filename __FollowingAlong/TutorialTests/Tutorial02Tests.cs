using __FollowingAlong.Monads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace __FollowingAlong.TutorialTests
{
    public class Tutorial02Tests
    {
        [Fact]
        public void BindNewValue_ReplacesExistingValues()
        {
            Box<int[]> numbers = new(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            Box<int[]> newNumbers = numbers.Bind(contents => BindFunction01(contents));

            Assert.Equal(new int[] { 42, 43, 44 }, newNumbers.Item);
        }

        private static Box<int[]> BindFunction01(int[] contents) => new Box<int[]>(new int[] { 42, 43, 44 });
        
        [Fact]
        public void MapNewValue_ReplacesExistingValues()
        {
            Box<int[]> numbers = new(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            Box<int[]> newNumbers = numbers.Map(contents => MapFunction01(contents));

            Assert.Equal(new int[] { 27, 28, 29, 30 }, newNumbers.Item);
        }

        private int[] MapFunction01(int[] contents) => new int[] { 27, 28, 29, 30 };
    }
}
