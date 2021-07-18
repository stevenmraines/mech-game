using System.Collections.Generic;
using System.Linq;
using RainesGames.Grid;
using UnityEngine;

namespace RainesGames.Units.Usables.Weapons
{
    public class DrawRangeActivationResponse : IWeaponActivationResponse, IWeaponDeactivationResponse
    {
        void DrawRange(IWeapon weapon, Color color)
        {
            if(!(weapon is IRangedUsable))
                return;

            foreach(int cellIndex in ((IRangedUsable)weapon).GetCellsInRange())
                GridWrapper.SetCellColor(cellIndex, color);
        }

        // TODO This has a bit of a code smell, what exactly needs to be passed here? Do I really need the activeUnit?
        public void OnDeactivate(IUnit activeUnit, IWeapon weapon)
        {
            DrawRange(weapon, new Color(0,0,0,0));
        }
        
        public void OnActivate(IUnit activeUnit, IWeapon weapon)
        {
            DrawRange(weapon, Color.red);
        }
    }
}
