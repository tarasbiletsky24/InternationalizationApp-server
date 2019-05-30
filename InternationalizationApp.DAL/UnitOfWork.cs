using InternationalizationApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalizationApp.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context context;
        private bool disposed;
        private IUserRepository users;

        public UnitOfWork(Context context)
        {
            this.context = context;
            disposed = false;
        }

        public IUserRepository Users => users ?? (users = new UserRepository(context));

        public void Save()
        {
            context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

