using System;
using System.Collections.Generic;

namespace Diplom
{
    public partial class TypesOfLiterature
    {
        public TypesOfLiterature()
        {
            Bibls = new HashSet<Bibl>();
        }

        public int IdTypesOfLiterature { get; set; }
        public string Author { get; set; } = null!;
        public string ArtisticLiterature { get; set; } = null!;
        public string Author1 { get; set; } = null!;
        public string RefrenceLiterature { get; set; } = null!;
        public string Author2 { get; set; } = null!;
        public string LiteratureByIndustry { get; set; } = null!;
        public string Author3 { get; set; } = null!;
        public string Textbooks { get; set; } = null!;
        public string Author4 { get; set; } = null!;
        public string TrainingManuals { get; set; } = null!;

        public virtual ICollection<Bibl> Bibls { get; set; }
    }
}
