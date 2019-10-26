using Xunit;

namespace NoConditionals
{
    public class PopulationTests
    {
        [Fact]
        public void GivenPopulationWithAMemberHavingTwoNeighbours_WhenMutation_ThenLives()
        {
            // Arrange
            var aMember = new Member();
            var aNeighbour = new Member();
            var anotherNeighbour = new Member();

            var population = new Population(new[] { aMember }, new[] {
                new Neighbourhood(aMember, aNeighbour),
                new Neighbourhood(aMember, anotherNeighbour),
            });

            // Act
            population.Mutate();

            // Assert
            Assert.True(aMember.IsAlive);
        }


        [Fact]
        public void GivenPopulationWithAMemberHavingOneNeighbour_WhenMutation_ThenDies()
        {
            // Arrange
            var aMember = new Member();
            var aNeighbour = new Member();

            var population = new Population(new[] { aMember }, new[] {
                new Neighbourhood(aMember, aNeighbour),
            });

            // Act
            population.Mutate();

            // Assert
            Assert.False(aMember.IsAlive);
        }

        [Fact]
        public void GivenPopulationWithAMemberHavingThreeNeighbours_WhenMutation_ThenIsAlive()
        {
            // Arrange
            var aMember = new Member();
            var aNeighbour = new Member();
            var firstNeighbour = new Member();
            var secondNeighbour = new Member();

            var population = new Population(new[] { aMember, secondNeighbour, firstNeighbour }, new[] {
                new Neighbourhood(aMember, aNeighbour),
                new Neighbourhood(aMember, firstNeighbour),
                new Neighbourhood(aMember, secondNeighbour),
            });

            // Act
            population.Mutate();

            // Assert
            Assert.True(aMember.IsAlive);
        }

        [Fact]
        public void GivenPopulationWithAMemberHavingMoreThanThreeNeighbours_WhenMutation_ThenDies()
        {
            // Arrange
            var aMember = new Member();
            var aNeighbour = new Member();
            var firstNeighbour = new Member();
            var secondNeighbour = new Member();
            var thirdNeighbour = new Member();
            var fourthNeighbour = new Member();

            var population = new Population(new[] { aMember, secondNeighbour, firstNeighbour, thirdNeighbour, fourthNeighbour }, new[] {
                new Neighbourhood(aMember, aNeighbour),
                new Neighbourhood(aMember, firstNeighbour),
                new Neighbourhood(aMember, secondNeighbour),
                new Neighbourhood(aMember, thirdNeighbour),
                new Neighbourhood(aMember, fourthNeighbour),
            });

            // Act
            population.Mutate();

            // Assert
            Assert.False(aMember.IsAlive);
        }
    }
}
