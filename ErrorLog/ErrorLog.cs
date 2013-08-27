using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Common;
namespace Logger
{
    /// <summary>
    /// Class ErrorLog
    /// Function: WriteLog, DeleteLog, ClearLog, FindByDate
    /// </summary>
    public class ErrorLog
    {
        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="fileLog">The file log.</param>
        public static void WriteLog(string error, string fileLog)
        {
            XDocument xLog = XDocument.Load(fileLog);
            xLog.Root.AddFirst(new XElement(Constants.Log,
                    new XElement(Constants.LogId, Guid.NewGuid()),
                    new XElement(Constants.Url, string.Empty),
                    new XElement(Constants.Date, DateTime.Now.ToString()),
                    new XElement(Constants.Error, error)));

            xLog.Save(fileLog);
        }

        public static void WriteLog(string url, string error, string fileLog)
        {
            XDocument xLog = XDocument.Load(fileLog);
            xLog.Root.AddFirst(new XElement(Constants.Log,
                    new XElement(Constants.LogId, Guid.NewGuid()),
                    new XElement(Constants.Url, url),
                    new XElement(Constants.Date, DateTime.Now.ToString()),
                    new XElement(Constants.Error, error)));

            xLog.Save(fileLog);
        }

        /// <summary>
        /// Deletes the log.
        /// </summary>
        /// <param name="logId">The log id.</param>
        /// <param name="fileLog">The file log.</param>
        /// <returns><c>true</c> if delete success, <c>false</c> otherwise</returns>
        public static bool DeleteLog(string logId, string fileLog)
        {
            XDocument xLog = XDocument.Load(fileLog);
            XElement existsLog = (from c in xLog.Descendants(Constants.Log)
                                  where c.Element(Constants.LogId).Value.Equals(logId)
                                  select c).FirstOrDefault();
            if (existsLog != null)
            {
                existsLog.Remove();
                xLog.Save(fileLog);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Clears the log.
        /// </summary>
        /// <param name="fileLog">The file log.</param>
        /// <returns><c>true</c> if save success, <c>false</c> otherwise</returns>
        public static bool ClearLog(string fileLog)
        {
            try
            {
                XDocument xLog = XDocument.Load(fileLog);
                xLog.Root.RemoveAll();
                xLog.Save(fileLog);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Finds the by date.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="fileLog">The file log.</param>
        /// <returns>List{ErrorLogEnt}.</returns>
        public static List<ErrorLogEnt> FindByDate(DateTime fromDate, DateTime toDate, string fileLog)
        {
            fromDate = fromDate.Date;
            toDate = toDate.AddDays(1).AddSeconds(-1);
            XDocument xLog = XDocument.Load(fileLog);
            return (from c in xLog.Root.Descendants(Constants.Log)
                    where DateTime.Parse(c.Element(Constants.Date).Value) >= fromDate && DateTime.Parse(c.Element(Constants.Date).Value) <= toDate
                    select new ErrorLogEnt
                    {
                        Id = new Guid(c.Element(Constants.LogId).Value),
                        Url = c.Element(Constants.Url).Value,
                        Date = c.Element(Constants.Date).Value,
                        Error = c.Element(Constants.Error).Value
                    }).ToList();
        }
    }
}
