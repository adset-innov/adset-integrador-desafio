using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdSetDesafio.Domain.Common.Interfaces
{
    public interface IAdapterReader
    {
        void SetConfiguration(Encoding encoding);

        Task<IList<T>> ReadDataAsync<T>(string path);
    }
}
