using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourSpace.Modules.Lister
{
    public class BookViewer<T>
    {

        public int CurrentPage { get => _currentPage; }


        private int _currentPage = 0;
        private int _amountOnPage;
        private List<T> _list;
        public BookViewer(List<T> list,int amountOnPage)
        {
            _amountOnPage = amountOnPage;
            _list = list;
        }

        public List<T> GetCurrentPage()
        {
            return GetPage(_currentPage);
        }

        public List<T> GetPage(int page)
        {
            if(page > GetTotalPages())
            {
                throw new Exception("page > total pages");
            }

            return _list.Skip(page * _amountOnPage).Take(_amountOnPage).ToList();
        }

        public int GetTotalPages()
        {
            return _list.Count / _amountOnPage;
        }

        public void NextPage()
        {
            if(GetTotalPages() > _currentPage)
            {
                _currentPage++;
            }
        }
        public void PreviousPage()
        {
            if (_currentPage > 0)
            {
                _currentPage--;
            }
        }
    }
}
