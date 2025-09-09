using System;
using System.Collections.Generic;

namespace Diplom
{
    public partial class Bibl
    {
        public int IdBibl { get; set; }
        public int IdUser { get; set; }
        public int IdSchoolBoy { get; set; }
        public int IdListsOfFiction { get; set; }
        public int IdListsOfTextbook { get; set; }
        public int IdListsTextbooksApplication { get; set; }
        public int IdTypesOfLiterature { get; set; }

        public virtual ListsOfFiction IdListsOfFictionNavigation { get; set; } = null!;
        public virtual ListsOfTextbook IdListsOfTextbookNavigation { get; set; } = null!;
        public virtual ListsTextbooksApplication IdListsTextbooksApplicationNavigation { get; set; } = null!;
        public virtual SchoolBoy IdSchoolBoyNavigation { get; set; } = null!;
        public virtual TypesOfLiterature IdTypesOfLiteratureNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
