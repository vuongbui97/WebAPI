using System;
using System.Collections.Generic;

namespace MyApp.DTOs.Common
{
    public class Pageable<T> where T : class
    {
        public Pageable()
        {
            
        }
        public Pageable(IEnumerable<T> items, int totalItem, int take)
        {
            Items = items;
            TotalItem = totalItem;
            TotalPage = (int)Math.Ceiling(TotalItem / (double)take);
        }
        public IEnumerable<T> Items { get; set; }
        public int TotalItem { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        
    }
}