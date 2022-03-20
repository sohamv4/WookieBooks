
using WookieBooks.Models;

namespace WookieBooks.BLL
{
    public class BooksLogic : BaseLogic<Book>
    {
        public BooksLogic(Repository.IDataRepository<Book> repository) : base(repository)
        {
        }
        public override void Add(Book[] books)
        {
            base.Add(books);
        }
        public override void Update(Book[] books)
        {
            base.Update(books);
        }
        public override List<Book> GetAll()
        {
            return base.GetAll();
        }
        public override void Delete(Book[] pocos)
        {
            base.Delete(pocos);
        }
        public override Book Get(Guid id)
        {
            return base.Get(id);
        }
    }
}
