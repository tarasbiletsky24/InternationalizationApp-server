using InternationalizationApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationApp.BLL.Services
{
    public class BaseService
    {
        protected readonly IUnitOfWork db;
        public BaseService(IUnitOfWork db)
        {
            this.db = db;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
