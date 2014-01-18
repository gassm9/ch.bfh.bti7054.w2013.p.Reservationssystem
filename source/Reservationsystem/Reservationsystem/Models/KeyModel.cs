using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reservationsystem.Models
{
    public class KeyModel
    {
        public int Id { get; set; }
        public string UniqueName { get; set; }
        public string NameD { get; set; }
        public string NameF { get; set; }
        public string NameI { get; set; }
        public string NameE { get; set; }
        public string DescriptionD { get; set; }
        public string DescriptionF { get; set; }
        public string DescriptionI { get; set; }
        public string DescriptionE { get; set; }
        public string Regex { get; set; }
        public string ValidationMessageD { get; set; }
        public string ValidationMessageF { get; set; }
        public string ValidationMessageI { get; set; }
        public string ValidationMessageE { get; set; }
        public int SortOrder { get; set; }

        public virtual BlockModel Block { get; set; }
        public virtual InputTypeModel InputType { get; set; }
    }
}
