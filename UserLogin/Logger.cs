using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UserLogin
{
    public static class Logger
    {
        // NOTE: Променете това съответно на вашата система
        private const string logFilename = "\\\\Mac\\Home\\Desktop\\ПС проект\\05. UserLogin\\UserLogin\\test.txt";

        static private List<string> currentSessionActivities = new List<string>();

        static public void LogActivity(string activity)
        {
            // Log to DB
            UserContext context = new UserContext();
            context.Logs.Add(new Log(DateTime.Now, LoginValidation.currentUserUsername, (int)LoginValidation.CurrentUserRole, activity));
            context.SaveChanges();

            // Log to current session
            string activityLine = DateTime.Now + " | " + LoginValidation.currentUserUsername + " | " + LoginValidation.CurrentUserRole + " | " + activity;
            currentSessionActivities.Add(activityLine);

            // Log to file
            try
            {
                if (File.Exists(logFilename))
                {
                    File.AppendAllText(logFilename, activityLine + "\n");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Възникна грешка при записването в файла " + logFilename);
                Console.WriteLine(e.Message);
            }
        }

        static public IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            return (from activity in currentSessionActivities where activity.Contains(filter) select activity).ToList();
        }

        static public IEnumerable<string> GetLogs()
        {
            //StringBuilder logText = new StringBuilder();
            List<string> logText = new List<string>();
            StreamReader file = new StreamReader(logFilename);
            string line = "";

            while ((line = file.ReadLine()) != null)
            {
                logText.Add(line);
            }

            return logText;
        }
    }
}
