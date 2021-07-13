using RainesGames.Units.Mechs.Classes.Possessor.Arms;
using RainesGames.Units.Mechs.Classes.Possessor.Head;
using RainesGames.Units.Mechs.Classes.Possessor.Legs;
using RainesGames.Units.Mechs.Classes.Possessor.Torso;
using UnityEngine;

namespace RainesGames.Units.Mechs.Classes.Possessor
{
    [RequireComponent(typeof(ClassAbilitySet))]
    [RequireComponent(typeof(MechAbilitySet))]
    [RequireComponent(typeof(PossessorHead))]
    [RequireComponent(typeof(PossessorLeftArm))]
    [RequireComponent(typeof(PossessorLegs))]
    [RequireComponent(typeof(PossessorRightArm))]
    [RequireComponent(typeof(PossessorTorso))]
    public class PossessorMechClass : AbsMechClass
    {
        public DataMechClass Data;

        public override int GetBaseMovement()
        {
            return Data.BaseMovement;
        }

        public override string GetClassName()
        {
            return Data.ClassName;
        }

        public override int GetMaxPower()
        {
            return Data.MaxPower;
        }

        public override int GetStartOfTurnActionPoints()
        {
            return Data.StartOfTurnActionPoints;
        }
    }
}