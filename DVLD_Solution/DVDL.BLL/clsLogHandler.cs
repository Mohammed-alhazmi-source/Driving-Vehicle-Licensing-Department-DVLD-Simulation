using DVDL.DAL;

namespace DVDL.BLL
{
    public static class clsLogHandler
    {
        public static void Log(string Subject, string Message) => clsEventLogHandler.LogException(Subject, Message);
    }
}