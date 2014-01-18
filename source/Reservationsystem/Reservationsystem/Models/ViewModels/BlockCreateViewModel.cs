using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Reservationsystem.Models.ViewModels
{
    public class BlockCreateViewModel
    {
        public string NameD { get; set; }
        public string NameF { get; set; }
        public string NameI { get; set; }
        public string NameE { get; set; }
        public int SortOrder { get; set; }
        
        [DisplayName("Template")]
        public int TemplateId { get; set; }
        public virtual IEnumerable<TemplateModel> Templates { get; set; }
    }
}