using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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

        public static bool DateTimeResponse(string dateTime)
        {
            var client = new TcpClient("time.nist.gov", 13);
            using (var streamReader = new StreamReader(client.GetStream()))
            {
                var response = streamReader.ReadToEnd();
                var utcDateTimeString = response.Substring(7, 17);
                var localDateTime = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);

                string onlyDate = localDateTime.ToString().Substring(0, 10);

                if (dateTime == onlyDate)
                    return true;
                else
                    return false;
            }

        }
    }
}
