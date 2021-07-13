namespace RainesGames.Units.Mechs.MechParts
{
    public class RightArm : LeftArm
    {
        public override bool HasShoulderMount()
        {
            return ArmData.HasRightShoulderMount;
        }
    }
}
