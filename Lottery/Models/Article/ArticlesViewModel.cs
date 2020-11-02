using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models
{
    public class ArticlesViewModel
    {
        public List<ArticleInfoModel> Articles { get; set; }

        public PageViewModel ViewModel { get; set; }

        public ArticlesViewModel(List<ArticleInfoModel> articles,int page)
        {
            Articles = articles;
            ViewModel = new PageViewModel(page);
            
        }
    }
}
