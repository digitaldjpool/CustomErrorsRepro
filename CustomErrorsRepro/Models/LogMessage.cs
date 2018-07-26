using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomErrorsRepro.Models
{
    public struct LogMessage
    {
        public string LogDate { get; set; }
        public string Message { get; set; }
        public string CustomErrorsMode { get; set; }
    }
}