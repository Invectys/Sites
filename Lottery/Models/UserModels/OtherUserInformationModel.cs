using Lottery.Models.Social;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Models.UserModels
{
    public class OtherUserInformationModel
    {
        public int Id { get; set; }
        public int ArticleOffered { get; set; }
        public int ArticleShared { get; set; }
        public long  MoneyWined { get; set; }
        public long  MoneyFailed { get; set; }

        //public int? LikesId { get; set; }
        //public ICollection<Like> Likes { get; set; }

        //public int? UsersLikedId { get; set; }
        //public List<string> UsersLiked { get; set; }
        

        public OtherUserInformationModel()
        {
            
        }
    }
}
