using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatker
{
    public class Note : Card
    {
        public Note(string Subject, string Content, DateTime CreationDate, DateTime ExpiryDate, int Id) : base(Subject, Content, CreationDate, ExpiryDate, Id)
        {

        }
    }
}
