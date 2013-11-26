using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Code0
{
    [DataContract]
    class WeaponSkills
    {
        #region constructors
        public WeaponSkills()
        {
            ShortBlade = 0;
            LongBlade = 0;
            Polearms = 0;
            Bashing = 0;
            Archery = 0;
            Unarmed = 0;
        }

        public WeaponSkills(int ShortBlade, int LongBlade, int Polearms, int Bashing, int Archery, int Unarmed)
        {
            this.ShortBlade = ShortBlade;
            this.LongBlade = LongBlade;
            this.Bashing = Bashing;
            this.Archery = Archery;
            this.Unarmed = Unarmed;
        }
        #endregion
        #region properties
        [DataMember]
        public int ShortBlade{ get; set;}
        [DataMember]
        public int LongBlade { get; set; }
        [DataMember]
        public int Polearms { get; set; }
        [DataMember]
        public int Bashing { get; set; }
        [DataMember]
        public int Archery { get; set; }
        [DataMember]
        public int Unarmed { get; set; }
        #endregion
    }
}
