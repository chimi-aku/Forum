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

        public string content { get; set; }
		
		public virtual User UserFor { get; set; }
		
		public virtual User UserFrom { get; set; }


    }
}