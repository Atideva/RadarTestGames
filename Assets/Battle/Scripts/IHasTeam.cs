namespace Battle.Scripts
{
    public interface IHasTeam
    {
        public Team Team { get; }
        void SetTeam(Team team);
    }
}