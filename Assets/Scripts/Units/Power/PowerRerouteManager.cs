using RainesGames.Common.Power;
using System.Collections.Generic;
using RainesGames.Units.Usables.Abilities;
using UnityEngine;

namespace RainesGames.Units.Power
{
    public class PowerRerouteManager : IPowerContainer
    {
        private Dictionary<IPowerContainerInteractable, int> _oldState;
        private int _power = 0;

        public void DiscardPowerState()
        {
            _oldState = null;
        }

        public int GetPower()
        {
            return _power;
        }

        public void RecordPowerState(IList<IAbility> abilities)
        {
            _oldState = new Dictionary<IPowerContainerInteractable, int>();

            foreach(IAbility ability in abilities)
            {
                IPowerContainerInteractable container = (IPowerContainerInteractable)ability;
                _oldState.Add(container, container.GetPower());
            }
        }
        
        public void RevertPowerState(int maxPower)
        {
            if(_oldState == null)
                return;

            foreach(KeyValuePair<IPowerContainerInteractable, int> keyValuePair in _oldState)
            {
                int oldPower = keyValuePair.Value;
                int newPower = keyValuePair.Key.GetPower();

                if(newPower == oldPower)
                    continue;

                int difference = newPower - oldPower;

                if(difference < 0)
                {
                    TransferPowerTo(keyValuePair.Key, Mathf.Abs(difference));
                    continue;
                }

                TransferPowerFrom(keyValuePair.Key, Mathf.Abs(difference), maxPower);
            }
        }

        public void SetPower(int power)
        {
            _power = power;
        }

        public void TransferPowerFrom(IPowerContainerInteractable container, int power, int maxPower)
        {
            if(container.GetPower() - power < 0)
            {
                Debug.Log("Not enough power to give");
                return;
            }

            if(_power == maxPower)
            {
                Debug.Log("Cannot take any more power");
                return;
            }

            container.RemovePower(power);
            _power += power;
        }

        public void TransferPowerTo(IPowerContainerInteractable container, int power)
        {
            if(container.GetPower() + power > container.GetMaxPower())
            {
                Debug.Log("Cannot take any more power");
                return;
            }

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