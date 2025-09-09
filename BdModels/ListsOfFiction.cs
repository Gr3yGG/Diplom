using System;
using System.Collections.Generic;

namespace Diplom
{
    public partial class ListsOfFiction
    {
        public ListsOfFiction()
        {
            Bibls = new HashSet<Bibl>();
        }

        public int IdListsOfFiction { get; set; }
        public string Author { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Genre { get; set; } = null!;

        public virtual ICollection<Bibl> Bibls { get; set; }
    }
}
