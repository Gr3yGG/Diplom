using System;
using System.Collections.Generic;

namespace Diplom
{
    public partial class ListsTextbooksApplication
    {
        public ListsTextbooksApplication()
        {
            Bibls = new HashSet<Bibl>();
        }

        public int IdListsTextbooksApplication { get; set; }
        public string Author { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int IdClass { get; set; }
        public string Reader { get; set; } = null!;
        public string Librarian { get; set; } = null!;
        public string DateOfIssue { get; set; } = null!;
        public string ReturnDate { get; set; } = null!;

        public virtual ICollection<Bibl> Bibls { get; set; }
    }
}
