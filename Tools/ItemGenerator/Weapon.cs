using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ItemGenerator
{
    [DataContract]
    class Weapon : Item
    {
        #region Constructors
        public Weapon()
        {
            WeaponAttributes = new CombatAttributes();
            CombatStyles = new List<CombatStyle>();
        }
        public Weapon(CombatAttributes WeaponAttributes, List<CombatStyle> CombatStyles)
        {
            this.WeaponAttributes = WeaponAttributes;
            this.CombatStyles = CombatStyles;
        }
        #endregion

        #region Properties
        [DataMember]
        CombatAttributes WeaponAttributes { get; set; }
        [DataMember]
        List<CombatStyle> CombatStyles { get; set; }
        [DataMember]
        bool TwoHanded { get; set; }
        [DataMember]
        bool Consumable { get; set; }
        #endregion
    }
}
