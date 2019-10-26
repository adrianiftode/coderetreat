namespace NoConditionals
{
    internal class Neighbourhood
    {
        public Neighbourhood(Member aMember, Member aNeighbour)
        {
            AMember = aMember;
            AnotherMember = aNeighbour;
        }

        public Member AMember { get; }
        public Member AnotherMember { get; }
        internal Member TheNeighbourOf(Member member)
            => AMember == member ? AnotherMember : AMember;
    }
}