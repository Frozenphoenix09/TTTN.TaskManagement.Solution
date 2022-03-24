using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTN.TaskManagement.Data.SeedWork
{
    public class PageList<T> where T : class
    {
        public MetaData MetaData { get; set; }
        public List<T> Items { get; set; }
        public PageList()
        {

        }
        public PageList(List<T> items , int totalRecord , int currentPage , int pageSize)
        {
            MetaData = new MetaData
            {
                TotalRecord = totalRecord,
                PageSize = pageSize,
                CurrentPage = currentPage,
                TotalPage = (int)Math.Ceiling(totalRecord / (double)pageSize)
            };
            Items = items;
        }
    }
}
