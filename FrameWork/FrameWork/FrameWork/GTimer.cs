using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameWork
{
    class GTimer
    {
        private double Time_Start; // thời gian bắt đầu
        private double StopWatch_Start; // thời gian bắt đầu dừng 
        private double Deta_Start; // delta
        public GTimer()
        {

            Time_Start = 0;
            StopWatch_Start = 0;
            Deta_Start = 0;
        }
        public void ResetDeta(GameTime mGameTime)
        {
            Deta_Start = mGameTime.TotalGameTime.TotalMilliseconds;
        }
        public void ResetTime(GameTime mGameTime)
        {
            Time_Start = mGameTime.TotalGameTime.TotalMilliseconds;
        }
        public void ResetStopWatch(GameTime mGameTime)
        {
            StopWatch_Start = mGameTime.TotalGameTime.TotalMilliseconds;
        }
        public void Reset(GameTime mGameTime)
        {
            ResetDeta(mGameTime);
            ResetStopWatch(mGameTime);
            ResetTime(mGameTime);
        }
        public double Deta(GameTime mGameTime)
        {

            return mGameTime.TotalGameTime.TotalMilliseconds - Deta_Start;

        }
        public double Time(GameTime mGameTime)
        {
            return mGameTime.TotalGameTime.TotalMilliseconds;
        }
        public bool StopWatch(double ms, GameTime mGameTime)
        {
            if (mGameTime.TotalGameTime.TotalMilliseconds > StopWatch_Start + ms)
            {
                ResetStopWatch(mGameTime);
                return true;
            }
            return false;
        }
        public double StartTime(GameTime mGameTime)
        {
            return mGameTime.TotalGameTime.TotalMilliseconds - Time_Start;
        }
    }
}
