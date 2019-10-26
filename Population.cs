using System.Collections.Generic;

namespace NoConditionals
{
    internal class Population
    {
        private readonly IReadOnlyCollection<Member> _members;
        private readonly IReadOnlyCollection<Neighbourhood> _neighbourhoods;
        public Population(IReadOnlyCollection<Member> members, IReadOnlyCollection<Neighbourhood> neighbourhoods)
        {
            _members = members;
            _neighbourhoods = neighbourhoods;
        }

        public void Mutate()
        {
            foreach (var member in _members)
            {
                member.MutateMe(_neighbourhoods);
            }
        }
    }
}