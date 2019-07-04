using DAL.DBContext;
using ENT.Ent;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private MyDBContext context = new MyDBContext();
        private bool disposed = false;
        private Repository<Person> personRepository;
        private Repository<Country> contryRepository;

        public Repository<Country> CountryRepository
        {
            get
            {
                if (this.contryRepository == null)
                {
                    this.contryRepository = new Repository<Country>(context);
                }
                return contryRepository;
            }
        }
        public Repository<Person> PersonRepository
        {
            get
            {
                if (this.personRepository == null)
                {
                    this.personRepository = new Repository<Person>(context);
                }
                return personRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
