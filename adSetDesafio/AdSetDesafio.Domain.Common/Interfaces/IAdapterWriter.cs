using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdSetDesafio.Domain.Common.Interfaces
{
    public interface IAdapterWriter
    {
        Task<string> WriteDataAsync<T>(IList<T> list, string path);
    }
}
