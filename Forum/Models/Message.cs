using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Message
    {
        public int MessageID { get; set; }

        public string AuthorID { get; set; }

        public string ReceiverID { get; set; }

        public string Content { get; set; }
		
		public virtual ApplicationUser UserAuthor { get; set; }
		
		public virtual ApplicationUser UserReceiver { get; set; }


    }
}