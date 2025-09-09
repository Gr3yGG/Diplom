using System;
using System.Collections.Generic;

namespace Diplom
{
    public partial class ListsOfTextbook
    {
        public ListsOfTextbook()
        {
            Bibls = new HashSet<Bibl>();
        }

        public int IdListsOfTextbook { get; set; }
        public string Author { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Date { get; set; } = null!;

        public virtual ICollection<Bibl> Bibls { get; set; }
    }
}
