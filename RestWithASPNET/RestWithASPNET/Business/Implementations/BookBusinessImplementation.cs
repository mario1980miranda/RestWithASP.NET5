using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        #region Properties
        private readonly IRepository<Book> _repository;
        #endregion

        #region Constructors
        public BookBusinessImplementation(IRepository<Book> repository) 
        {
            _repository = repository;
        }
        #endregion

        #region Public methods
        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
        #endregion
    }
}
