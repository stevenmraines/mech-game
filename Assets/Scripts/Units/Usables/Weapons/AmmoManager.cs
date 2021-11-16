using UnityEngine;

namespace RainesGames.Units.Usables.Weapons
{
    public class AmmoManager
    {
        private int _clipsRemaining = 0;
        private int _shotsRemaining = 0;

        public AmmoManager(int clipsRemaining, int shotsRemaining)
        {
            _clipsRemaining = clipsRemaining;
            _shotsRemaining = shotsRemaining;
        }

        public void Decrement(int shotsSpent = 1)
        {
            _shotsRemaining = Mathf.Max(0, _shotsRemaining - shotsSpent);
        }

        public int GetClipsRemaining()
        {
            return _clipsRemaining;
        }

        public int GetShotsRemaining()
        {
            return _shotsRemaining;
        }

        public void Reload(int shotsPerClip)
        {
            // Out of ammo, do nothing
            if(_clipsRemaining == 0)
                return;

            _shotsRemaining = shotsPerClip;

            // Unlimited reloads, no need to decrement number of remaining clips
            if(_clipsRemaining < 0)
                return;

            _clipsRemaining--;
        }
    }
}