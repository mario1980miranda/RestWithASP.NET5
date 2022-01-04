using RestWithASPNET.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNET.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);

        PersonVO FindById(long id);

        List<PersonVO> FindAll();

        PersonVO Update(PersonVO person);

        void Delete(long id);
    }
}
