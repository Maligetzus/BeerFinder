using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BeerDB
{
    public class BarRepository : IBarRepository
    {
        
        private readonly BarDbContext _context;

        public BarRepository(BarDbContext context)
        {
            _context = context;
        }

        public Bar Get(Guid id, Guid userId)
        {
            if (!_context.Bars.FirstOrDefault(p => p.Id.Equals(id)).UserId.Equals(userId))
                throw new BarAccessDeniedException("Wrong user!");
            return _context.Bars.FirstOrDefault(p => p.Id.Equals(id));
        }

        public void Add(Bar bar)
        {
            _context.Bars.Add(bar);
            _context.SaveChanges();
        }

        public bool Remove(Guid id, Guid userId)
        {
            if (!_context.Bars.Contains(Get(id, userId))) return false;
            if (!_context.Bars.FirstOrDefault(p => p.Id.Equals(id)).UserId.Equals(userId))
                throw new BarAccessDeniedException("Wrong user!");
            _context.Bars.Remove(Get(id,userId));
            _context.SaveChanges();
            return true;
        }

        public void Update(Bar bar, Guid userId)
        {
            if (!_context.Bars.Contains(bar))
            {
                Add(bar);
                return;
            }
            if (!_context.Bars.FirstOrDefault(p => p.Id.Equals(bar.Id)).UserId.Equals(userId))
                throw new BarAccessDeniedException("Wrong user!");
            Remove(bar.Id,userId);
            Add(bar);
            _context.SaveChanges();
        }

        public List<Bar> GetAll()
        {
            return _context.Bars
                .Include(bar => bar.BarTags)
                .OrderByDescending(b => b.Name.Substring(0,1)).ToList();
        }

        public List<Bar> GetByBarTags(Func<Bar, bool> filterFunction, Guid userId)
        {
            return _context.Bars
                .Include(i => i.BarTags)
                .Where(b=>b.Id.Equals(userId) && filterFunction(b)).ToList();
        }

        public void AddTag(string text, Bar bar)
        {
            bar.BarTags.Add(new BarTag(text));
            _context.SaveChanges();
            //BarTag tag = _context.BarTags.FirstOrDefault(t => t.Text == text);
            //if (tag == null)
            //{
            //    tag = new BarTag(text);
            //    bar.BarTags.Add(tag);
            //    _context.BarTags.Add(tag);
            //}
            //else
            //{
            //    bar.BarTags.Add(tag);
            //}
            //_context.SaveChanges();
        }

        public class BarAccessDeniedException : Exception
        {
            public BarAccessDeniedException(string message) : base(message)
            {
                Console.WriteLine(message);
            }
        }

        public class BarDuplicateException : Exception
        {
            public BarDuplicateException(string message) : base(message)
            {
                Console.WriteLine(message);
            }
        }
    }
}
