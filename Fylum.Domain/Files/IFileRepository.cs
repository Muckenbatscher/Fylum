using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Files
{
    public interface IFileRepository
    {
        File Get(Guid id);
        IEnumerable<File> GetAllInFolder(Guid folderId);
        void Create(File file);
        void Delete(Guid id);
        void Update(Guid id, File file);
    }
}
