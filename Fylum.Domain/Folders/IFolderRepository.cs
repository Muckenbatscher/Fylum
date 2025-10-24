using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Domain.Folders
{
    public interface IFolderRepository
    {
        Folder Get(Guid id);
        IEnumerable<Folder> GetAllInFolder(Guid folderId);
        void Create(Folder folder);
        void Delete(Guid id);
        void Update(Guid id, Folder folder);
    }
}
