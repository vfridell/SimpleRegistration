using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRegistration
{
    public class Repository<T>
        where T : Entity
    {
        protected Dictionary<int, T> _entities = new Dictionary<int, T>();
        protected int _nextId;
               
        protected Repository() { }

        public T Get(int Id) => _entities[Id];
        public bool TryGet(int Id, out T entity) => _entities.TryGetValue(Id, out entity);

        public void Add(T entity)
        {
            if (_entities.ContainsKey(entity.Id)) throw new Exception($"Repository<{typeof(T)}> already contains entity with key {entity.Id}");
            _entities.Add(entity.Id, entity);
        }
    }
}
