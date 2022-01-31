using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Message
    {
        public int MessageID { get; set; }

        public int AuthorID { get; set; }

        public int ReceiverID { get; set; }

        public string Content { get; set; }
		
		public virtual LoginViewModel UserAuthor { get; set; }
		
		public virtual LoginViewModel UserReceiver { get; set; }


    }
}