using System;
using UnityEngine;

namespace Assets.Scripts.GameLogic
{
    public class GamePause
    {
        private bool _isPaused;
        private int _pauseRequests = 0;
        public bool IsPaused { get { return _isPaused; } }
        public Action<bool> OnPauseStateChanged;

        public GamePause(bool isPaused, int pauseRequests)
        {
            _isPaused = isPaused;
            _pauseRequests = pauseRequests;
            UpdatePauseState();
        }

        public GamePause() : this(false,0) {}

        public void RequestPause()
        {
            _pauseRequests++;
            UpdatePauseState();
        }

        public void ReleasePause()
        {
            if (_pauseRequests > 0)
            {
                _pauseRequests--;
                UpdatePauseState();
            }
        }

        private void UpdatePauseState()
        {
            bool newPauseState = _pauseRequests > 0;

            if (newPauseState != _isPaused)
            {
                _isPaused = newPauseState;
                Time.timeScale = _isPaused ? 0 : 1;

                OnPauseStateChanged?.Invoke(_isPaused);
            }
        }

    }
}
