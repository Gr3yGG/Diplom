using System;
using System.Collections.Generic;

namespace Diplom
{
    public partial class User
    {
        public User()
        {
            Bibls = new HashSet<Bibl>();
        }

        public int IdUser { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Dolzhnost { get; set; } = null!;

        public virtual ICollection<Bibl> Bibls { get; set; }
    }
}
