
using Microsoft.AspNetCore.Http;

namespace Logica.Interfaces
{
    internal interface IDataBase
    {
        void Create(IFormCollection info);
        List<int> Read(IFormCollection info);        
        void Update(IFormCollection info);
        void Delete(int id);
    }
}
