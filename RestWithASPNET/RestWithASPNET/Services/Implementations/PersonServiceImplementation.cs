using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        #region Properties
        private MySQLContext _context;
        #endregion
        #region Constructors
        public PersonServiceImplementation(MySQLContext context) 
        {
            _context = context;
        }
        #endregion
        #region Public methods
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }
        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }
            return person;
        }
        public Person Update(Person person)
        {
            if (!Exists(person.Id)) new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return person;
        }
        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion
        #region Private methods
        private bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
        #endregion
    }
}
