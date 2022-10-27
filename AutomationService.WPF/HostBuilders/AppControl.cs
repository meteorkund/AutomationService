using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationService.WPF.HostBuilders
{
    public class AppControl
    {
        static Mutex mtx = null;
        public static bool IsAppRunning(string AppName)
        {
            Mutex.TryOpenExisting(AppName, out mtx);
            if (mtx == null)
            {
                mtx = new Mutex(true, AppName);
                return true;
            }
            else
            {
                mtx.Close();
                return false;
            }
        }
    }
}
