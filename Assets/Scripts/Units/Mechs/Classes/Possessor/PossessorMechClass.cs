namespace RainesGames.Units.Mechs.Classes.Possessor
{
    public class PossessorMechClass : AbsMechClass
    {
        public DataMechClass Data;

        protected override DataMechClass GetData()
        {
            return Data;
        }
    }
}