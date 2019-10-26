using System;
using System.Collections.Generic;
using System.Linq;

namespace NoConditionals
{
    internal class Member
    {
        private readonly Dictionary<Func<int, bool>, Action> _mutations = new Dictionary<Func<int, bool>, Action>();
        public Member()
        {
            _mutations.Add(neighboursCount => neighboursCount == 2 || neighboursCount == 3, () => Resurect());
            _mutations.Add(neighboursCount => neighboursCount < 2 || neighboursCount > 3, () => Kill());
        }
        public bool IsAlive { get; private set; } = true;

        public void MutateMe(IEnumerable<Neighbourhood> neighbourhoods)
        {
            int neighboursCount = GetNeighboursCount(neighbourhoods);

            foreach (var mutation in _mutations.Where(m => m.Key(neighboursCount)))
            {
                mutation.Value();
            }
        }

        private int GetNeighboursCount(IEnumerable<Neighbourhood> neighbourhoods) => neighbourhoods
                    .Where(n => n.AMember == this || n.AnotherMember == this)
                    .Where(n => n.TheNeighbourOf(this).IsAlive)
                    .Count();

        public bool Resurect() => IsAlive = true;
        public bool Kill() => IsAlive = false;
    }
}