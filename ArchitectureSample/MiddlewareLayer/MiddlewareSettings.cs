using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareLayer
{
    public class MiddlewareSettings
    {
        public bool HostFilterStatus { get; set; }
        public bool LoggerStatus { get; set; }
        public GlobalExceptionModel GlobalExceptionModel { get; set; }
    }

    public class GlobalExceptionModel
    {
        public bool Status { get; set; }
        public string UnauthorizedPath { get; set; }
    }
}
