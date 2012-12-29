using System;
using System.Collections.Generic;
using System.Text;

namespace Doodle_Jump.Utility
{
    static public class FPS
    {
        private static float mFrameLenght = 1000.0f;
        private static long mLastTime;
        private static long mCurrentTime;
        private static long mFrames;
        private static long mElapsedTime;
        private static float mFps;

        public static void reset()
        {
            mLastTime = 0;
            mCurrentTime = 0;
            mFrames = 0;
            mElapsedTime = 0;
            mFps = 0;
        }

        public static void Update()
        {
            mFrames++;
            mCurrentTime = DateTime.Now.Ticks / 10000;
            mElapsedTime = mCurrentTime - mLastTime;
            if (mElapsedTime >= (long)mFrameLenght)
            {
                mFps = ((float)mFrames * mFrameLenght / (float)mElapsedTime);
                mFrames = 0;
                mLastTime = mCurrentTime;

            }
        }

        public static int Get()
        {
            return (int)mFps;
        }
    }
}
