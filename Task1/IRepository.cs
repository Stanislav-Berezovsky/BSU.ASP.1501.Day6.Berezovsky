using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public interface IRepository<T> where T : IEquatable<T>
    {
        List<T> Load();
        void Save(IEnumerable<T> entity);
    }
}
