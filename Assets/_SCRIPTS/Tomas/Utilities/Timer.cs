using System;
using UnityEngine;

namespace Tomas.Utilities
{
    public class Timer
    {
        public event Action OnTimerDone;
    
        private float _timerStartTime;
        private float _timerDuration;
        private float _timerTargetTime;

        private bool _isTimerActive;

        public Timer(float _timerDuration)
        {
            this._timerDuration = _timerDuration;
        }

        public void StartTimer()
        {
            _timerStartTime = Time.time;
            _timerTargetTime = _timerStartTime + _timerDuration;
            _isTimerActive = true;
        }

        public void StopTimer()
        {
            _isTimerActive = false;
        }

        public void TimerTick()
        {
            if (!_isTimerActive) return;

                if (Time.time >= _timerTargetTime)
            {
                OnTimerDone?.Invoke();
                StopTimer();
            }
        }
    }
}