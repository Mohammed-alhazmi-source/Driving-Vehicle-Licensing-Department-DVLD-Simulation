using System;
using System.Diagnostics;
using System.Configuration;

namespace DVDL.DAL
{
    public static class clsEventLogHandler
    {
        private static string AppSource = ConfigurationManager.AppSettings["AppSource"];

        public static void LogException(string Subject, string Message)
        {
            try
            {
                if (!IsSourceExists())
                    EventLog.CreateEventSource(AppSource, "Application");

                string FullMessage = $"Subject : {Subject}\n\nMessage : {Message}";

                EventLog.WriteEntry(AppSource, FullMessage, EventLogEntryType.Error);
            }
            catch (Exception )
            {

            }          
        }

        private static bool IsSourceExists() => EventLog.SourceExists(AppSource);
    }
}