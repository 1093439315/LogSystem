using DTO;
using Entity;
using MongoDB.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbAccess
{
    public class LogAccess
    {
        public void AddInfoLog(LogRequest logRequest)
        {
            //取业务Id 如果没有则新建业务
            var entity = new InfoLog()
            {
                
            };
            //DbProvider.Insert()
        }
    }
}
