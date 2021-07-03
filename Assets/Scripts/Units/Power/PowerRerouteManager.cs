using RainesGames.Common.Power;
using RainesGames.Units.Abilities;
using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Units.Power
{
    public class PowerRerouteManager : MonoBehaviour, IPowerContainer
    {
        private int _maxPower = 7;
        private Dictionary<IPowerContainerInteractable, int> _oldState;
        private int _power = 7;

        public void DiscardPowerState()
        {
            _oldState = null;
        }

        public int GetMaxPower()
        {
            return _maxPower;
        }

        public int GetPower()
        {
            return _power;
        }

        public void RecordPowerState(AbsAbility[] abilities)
        {
            _oldState = new Dictionary<IPowerContainerInteractable, int>();

            foreach(AbsAbility ability in abilities)
            {
                IPowerContainerInteractable container = (IPowerContainerInteractable)ability;
                _oldState.Add(container, container.GetPower());
            }
        }
        
        public void RevertPowerState()
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

                TransferPowerFrom(keyValuePair.Key, Mathf.Abs(difference));
            }
        }

        public void TransferPowerFrom(IPowerContainerInteractable container, int power)
        {
            if(container.GetPower() - power < 0)
            {
                Debug.Log("Not enough power to give");
                return;
            }

            if(_power == _maxPower)
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