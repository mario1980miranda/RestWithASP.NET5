using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        #region Properties
        private readonly IRepository<Person> _repository;
        #endregion

        #region Constructors
        public PersonBusinessImplementation(IRepository<Person> repository) 
        {
            _repository = repository;

        }
        #endregion

        #region Public methods
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
        #endregion
    }
}
