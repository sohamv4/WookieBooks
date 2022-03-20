using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WookieBooks.Models;
using WookieBooks.Repository;

namespace WookieBooks.BLL
{
    public abstract class BaseLogic<TPoco>
         where TPoco : IPoco
    {
        protected IDataRepository<TPoco> _repository;
        public BaseLogic(IDataRepository<TPoco> repository)
        {
            _repository = repository;
        }
        public virtual void Add(TPoco[] pocos)
        {
            foreach (TPoco poco in pocos)
            {
                if (poco.Id == Guid.Empty)
                {
                    poco.Id = Guid.NewGuid();
                }
            }

            _repository.Add(pocos);
        }

        public virtual void Update(TPoco[] pocos)
        {
            _repository.Update(pocos);
        }

        public virtual void Delete(TPoco[] pocos)
        {
            _repository.Remove(pocos);
        }
        public virtual List<TPoco> GetAll()
        {
            return _repository.GetAll().ToList();
        }
    }
}
