using System;
using System.Threading;

namespace pathTool
{
    class ThreadLocker
    {

        static ThreadLocker mInstance = null;
        Mutex mMutex = null;

        private ThreadLocker()
        {
        }

        public static ThreadLocker GetInstance()
        {
            if (mInstance == null)
            {
                mInstance = new ThreadLocker();
                mInstance.mMutex = new Mutex(false, "ThreadLock");
            }
            return (mInstance);
        }


        public bool CreateLock()
        {
            if (mMutex == null)
            {
                mMutex = new Mutex(false, "ThreadLock");
            }
            return (mMutex.WaitOne());
        }

        public void ReleaseLock()
        {
            mMutex.ReleaseMutex();
        }

    }
}
