using System;
using System.Collections.Generic;

namespace BeerDB
{
    public interface IBarRepository
    {
        Bar Get (Guid todoId, Guid userId) ;
        void Add(Bar todoItem);
        bool Remove (Guid todoId, Guid userId) ;
        void Update(Bar todoItem, Guid userId);
        List<Bar> GetAll();
        List<Bar> GetByBarTags (Func<Bar, bool> filterFunction, Guid userId);
        void AddTag(string text, Bar bar);
    }
}