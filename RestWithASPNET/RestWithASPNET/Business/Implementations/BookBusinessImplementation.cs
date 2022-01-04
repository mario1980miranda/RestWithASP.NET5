using RestWithASPNET.Data.Converter.Implementations;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using RestWithASPNET.Repository;
using System.Collections.Generic;

namespace RestWithASPNET.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        #region Properties
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;
        #endregion

        #region Constructors
        public BookBusinessImplementation(IRepository<Book> repository) 
        {
            _repository = repository;
            _converter = new BookConverter();
        }
        #endregion

        #region Public methods
        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
        #endregion
    }
}
