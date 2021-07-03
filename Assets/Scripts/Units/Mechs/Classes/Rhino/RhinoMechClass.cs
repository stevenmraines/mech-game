namespace RainesGames.Units.Mechs.Classes.Rhino
{
    public class RhinoMechClass : AbsMechClass
    {
        public DataMechClass Data;

        protected override DataMechClass GetData()
        {
            return Data;
        }
    }
}