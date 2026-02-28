using System.Collections.Generic;

namespace InsurancePolicyManagementSystem.Data
{
    public class Repository<T>
    {
        private readonly List<T> _items = new();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public List<T> GetAll()
        {
            return _items;
        }
    }
}