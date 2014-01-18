using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reservationsystem.Models
{
    public class BlockModel
    {
        public int Id { get; set; }
        public string NameD { get; set; }
        public string NameF { get; set; }
        public string NameI { get; set; }
        public string NameE { get; set; }
        public int SortOrder { get; set; }
        public virtual TemplateModel Template { get; set; }
        public virtual ICollection<KeyModel> Keys { get; set; }
    }
}