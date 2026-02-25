using System.Collections.Generic;
using System.IO;
using System.Linq;
using TuHocCode.Core.Models;
using TuHocCode.Core.Utils;

namespace TuHocCode.Repositories
{
    public class DocumentRepository
    {
        public DocumentIndexCollection LoadIndex()
        {
            return JsonLoader.LoadFromFile<DocumentIndexCollection>(PathHelper.DocumentIndexPath);
        }

        public CommandDocument LoadByRelativePath(string relativePath)
        {
            var fullPath = Path.Combine(PathHelper.DocumentsRoot, relativePath);
            return JsonLoader.LoadFromFile<CommandDocument>(fullPath);
        }

        public CommandDocument LoadById(string id)
        {
            var index = LoadIndex();
            var item = index.documents?.FirstOrDefault(x => x.id == id);
            if (item == null)
            {
                return null;
            }

            return LoadByRelativePath(item.file);
        }

        public IEnumerable<DocumentIndexItem> Search(string query)
        {
            var normalized = (query ?? string.Empty).Trim().ToLowerInvariant();
            var index = LoadIndex();
            if (string.IsNullOrWhiteSpace(normalized))
            {
                return index.documents ?? new DocumentIndexItem[0];
            }

            return (index.documents ?? new DocumentIndexItem[0]).Where(d =>
                (d.title ?? string.Empty).ToLowerInvariant().Contains(normalized) ||
                (d.command ?? string.Empty).ToLowerInvariant().Contains(normalized) ||
                (d.tags != null && d.tags.Any(t => (t ?? string.Empty).ToLowerInvariant().Contains(normalized))));
        }
    }
}
