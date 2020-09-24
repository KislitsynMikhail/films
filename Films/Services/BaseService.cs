using Films.Data;
using System;

namespace Films.Services
{
    public abstract class BaseService : IDisposable
    {
        protected readonly IDatabaseContext databaseContext;
        private bool disposed = false;

        public BaseService(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        protected void CheckExistence(object obj, Exception exception)
        {
            if (obj is null)
            {
                throw exception;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }

                databaseContext.Dispose();
                disposed = true;
            }
        }

        ~BaseService()
        {
            Dispose(false);
        }
    }
}
