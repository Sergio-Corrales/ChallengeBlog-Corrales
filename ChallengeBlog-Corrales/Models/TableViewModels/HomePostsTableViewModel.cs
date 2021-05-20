using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBlog_Corrales.Models.TableViewModels
{
    public class HomePostsTableViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Picture { get; set; }
    }
}
