using NorthwindDatabase.Context;
using NorthwindDatabase.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindDAL
{
    public class UnitOfWork : IDisposable
    {

        private NorthwindDBContext _context = new NorthwindDBContext();
        private GenericRepository<Customers> _customersRepository;

        public GenericRepository<Customers> CustomersRepository
        {
            get
            {

                if (this._customersRepository == null)
                {
                    this._customersRepository = new GenericRepository<Customers>(_context);
                }
                return this._customersRepository;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
