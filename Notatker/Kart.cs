using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatker
{
    abstract public class Card
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Id { get; set; }

        public Card(string subject, string content, DateTime creationDate, DateTime expiryDate, int id)
        {
            Subject = subject;
            Content = content;
            CreationDate = creationDate;
            ExpiryDate = expiryDate;
            Id = id;
        }

        public void ShowCard()
        {

        }
    }
}
