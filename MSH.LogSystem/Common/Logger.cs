﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Logger
    {
        private static log4net.ILog Log { get; set; }

        private static StackTrace Trace { get; set; }

        #region Debug

        public static void Debug(object message)
        {
            Trace = new StackTrace();
            Log = log4net.LogManager.GetLogger(string.Format("{0}.{1}", Trace.GetFrame(1).GetMethod().ReflectedType, Trace.GetFrame(1).GetMethod().Name));
            Log.Debug(message);
        }
        
        #endregion

        #region Error
        public static void Error(object message)
        {
            Trace = new StackTrace();
            Log = log4net.LogManager.GetLogger(string.Format("{0}.{1}", Trace.GetFrame(1).GetMethod().ReflectedType, Trace.GetFrame(1).GetMethod().Name));
            Log.Error(message);
        }
        
        #endregion

        #region Info
        public static void Info(object message)
        {
            Trace = new StackTrace();
            Log = log4net.LogManager.GetLogger(string.Format("{0}.{1}", Trace.GetFrame(1).GetMethod().ReflectedType, Trace.GetFrame(1).GetMethod().Name));
            Log.Info(message);
        }
        
        #endregion

        #region Warn
        public static void Warn(object message)
        {
            Trace = new StackTrace();
            Log = log4net.LogManager.GetLogger(string.Format("{0}.{1}", Trace.GetFrame(1).GetMethod().ReflectedType, Trace.GetFrame(1).GetMethod().Name));
            Log.Warn(message);
        }
        
        #endregion

        //清理日志文件
        public static void CleanLogs(int days)
        {
            try
            {
                string logFilePath = "Logs";
                if (!Directory.Exists(logFilePath)) return;
                DirectoryInfo folder = new DirectoryInfo(logFilePath);
                foreach (FileInfo file in folder.GetFiles("*.txt"))
                {
                    if (!File.Exists(file.FullName)) continue;
                    if (file.CreationTime < DateTime.Now.AddDays(-1 * days))
                        File.Delete(file.FullName);
                }
            }
            catch (Exception ex)
            {
                Logger.Info($"清理日志文件时发生错误:{ex}");
            }
        }
    }
}
