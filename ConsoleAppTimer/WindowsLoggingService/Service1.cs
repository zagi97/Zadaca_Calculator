using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsLoggingService
{
    public partial class Service1 : ServiceBase
    {
        public string sDateTime;
        public string sText;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            sDateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            sText = "Servis je pokrenut" + sDateTime;
            WriteToFile(sText);
            ScheduleService();
        }

        protected override void OnStop()
        {
            sDateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            sText = "Servis je zaustavljen" + sDateTime;
            WriteToFile(sText);
        }
        private static void WriteToFile(string text)
        {
            string path = "E:\\ServiceLog.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(string.Format(text, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
                writer.Close();
            }
        }
        public static void ScheduleService()
        {
            // Objekt klase Timer 
            Timer Schedular = new Timer(new TimerCallback(SchedularCallback));

            // Postavljanje vremena 'po defaultu'
            DateTime scheduledTime = DateTime.MinValue;

            int intervalMinutes = 1;

            // Postavljanje vremena zapisa u trenutno vrijeme + 1 minuta
            scheduledTime = DateTime.Now.AddMinutes(intervalMinutes);
            if (DateTime.Now > scheduledTime)
            {
                scheduledTime = scheduledTime.AddMinutes(intervalMinutes);
            }

            // Vremenski interval
            TimeSpan timeSpan = scheduledTime.Subtract(DateTime.Now);
            string schedule = string.Format("{0} day(s) {1} hour(s) {2} minute(s) {3} seconds(s)", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            WriteToFile("Simple Service scheduled to run after: " + schedule + " {0}");

            //Razlika između trenutnog vremena i planiranog vremena
            int dueTime = Convert.ToInt32(timeSpan.TotalMilliseconds);

            // Promjena vremena izvršavanja metode povratnog poziva.
            Schedular.Change(dueTime, Timeout.Infinite);
        }
        private static void SchedularCallback(object e)
        {
            WriteToFile("Simple Service Log: {0}");
            ScheduleService();
        }


    }
}
