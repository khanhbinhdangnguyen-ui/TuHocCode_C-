using System.Collections.Generic;
using TuHocCode.Core.Models;
using TuHocCode.Repositories;

namespace TuHocCode.Services
{
    public class DocumentService
    {
        private readonly DocumentRepository _repository = new DocumentRepository();

        public IEnumerable<DocumentIndexItem> Search(string query)
        {
            return _repository.Search(query);
        }

        public CommandDocument GetDocument(string id)
        {
            return _repository.LoadById(id);
        }
    }
}
