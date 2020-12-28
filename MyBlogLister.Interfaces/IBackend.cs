using System.Collections.Generic;

namespace MyBlogLister.Interfaces
{
    public interface IBackend<T> where T : class
    {
        IEnumerable<T> Load(dynamic dataSourceName);

        void Save(dynamic dataSourceName, IEnumerable<T> data);
    }
}