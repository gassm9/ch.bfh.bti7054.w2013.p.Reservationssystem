using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reservationsystem.Models.ViewModels
{
    public class KeyViewModel
    {
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

        public int BlockId { get; set; }
        public virtual IEnumerable<BlockModel> Blocks { get; set; }
        public int InputTypeId { get; set; }
        public virtual IEnumerable<InputTypeModel> InputTypes { get; set; }
    }
}