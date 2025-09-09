using System;
using System.Collections.Generic;

namespace Diplom
{
    public partial class SchoolBoy
    {
        public SchoolBoy()
        {
            Bibls = new HashSet<Bibl>();
        }

        public int IdSchoolBoy { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public int IdClass { get; set; }
        public long NumberPhone { get; set; }

        public virtual ICollection<Bibl> Bibls { get; set; }
    }
}
