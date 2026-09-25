using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MuleThis
{
    class TimerManager
    {
        private Dictionary<string, Timer> timer = new Dictionary<string,Timer>();

        public void Dispose()
        {
            Timer t;
            foreach (String key in timer.Keys)
            {
                t = getTimer(key);
                if (t != null)
                {
                    t.Stop();
                    t.Dispose();
                }
            }
            timer.Clear();
        }

        public Timer getTimer(String name, int interval, EventHandler handler)
        {
            Timer t = getTimer(name);
            if (t == null)
            {
                t = new Timer();
                t.Tick += handler;
                timer.Add(name, t);
            }
            t.Interval = Math.Max(20, interval);
            return t;
        }

        public void startTimer(String name, int interval, EventHandler handler)
        {
            getTimer(name, interval, handler).Start();
        }

        private Timer getTimer(String name)
        {
            Timer t = null;
            if (timer.ContainsKey(name))
            {
                t = timer[name];
                if (t == null)
                {
                    timer.Remove(name);
                }
            }
            return t;
        }

        public bool stopTimer(String name)
        {
            try
            {
                Timer t = getTimer(name);
                if (t != null && t.Enabled)
                {
                    t.Stop();
                    return true;
                }
            } catch (Exception ex) { }
            return false;
        }
    }
}
