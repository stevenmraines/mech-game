using RainesGames.Common.Power;
using RainesGames.Units.Abilities;
using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Units.Power
{
    public class PowerManager : IPowerContainer
    {
        private UnitController _controller;
        public UnitController Controller => _controller;

        private int _maxPower = 7;
        public int MaxPower => _maxPower;

        private int _power = 7;
        public int Power => _power;

        private Dictionary<IPowerContainerInteractable, int> _oldState;

        public PowerManager(UnitController controller)
        {
            _controller = controller;
        }

        public void DiscardOldState()
        {
            _oldState = null;
        }

        public void RecordOldState()
        {
            _oldState = new Dictionary<IPowerContainerInteractable, int>();

            foreach(AbsAbility ability in _controller.GetPoweredAbilities())
            {
                IPowerContainerInteractable container = (IPowerContainerInteractable)ability;
                _oldState.Add(container, container.Power);
            }
        }
        
        public void RevertChanges()
        {
            if(_oldState == null)
                return;

            foreach(KeyValuePair<IPowerContainerInteractable, int> keyValuePair in _oldState)
            {
                int oldPower = keyValuePair.Value;
                int newPower = keyValuePair.Key.Power;

                if(newPower == oldPower)
                    continue;

                int difference = newPower - oldPower;

                if(difference < 0)
                {
                    TransferPowerTo(keyValuePair.Key, Mathf.Abs(difference));
                    continue;
                }

                TransferPowerFrom(keyValuePair.Key, Mathf.Abs(difference));
            }
        }

        public void TransferPowerFrom(IPowerContainerInteractable container, int power = 1)
        {
            // If the container does not have the power to give
            if(container.Power - power < 0)
            {
                Debug.Log("Not enough power to give");
                return;
            }

            // If this cannot take on the given power
            if(_power == _maxPower)
            {
                Debug.Log("Cannot take any more power");
                return;
            }

            container.RemovePower(power);
            _power += power;
        }

        public void TransferPowerTo(IPowerContainerInteractable container, int power = 1)
        {
            // If the container cannot take on the given power
            if(container.Power + power > container.MaxPower)
            {
                Debug.Log("Cannot take any more power");
                return;
            }

            // If this does not have the power to give
            if(_power - power < 0)
            {
                Debug.Log("Not enough power to give");
                return;
            }

            container.AddPower(power);
            _power -= power;
        }
    }
}