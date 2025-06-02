using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTS.config
{
    abstract class Services
    {
        public abstract DataTable queryExecution(string query);
        public abstract int isNotQueryExecution(string query);
    }
}
