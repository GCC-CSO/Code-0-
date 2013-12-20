using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ItemGenerator
{
    /// <summary>
    /// This Class represents a weapon with normal and elemental damage
    /// </summary>
    [DataContract]
    public class Weapon : Item
    {
       
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public Weapon():base()
        {
            WeaponAttributes = new CombatAttributes();
            CombatStyles = new List<CombatStyle>();
        }
        public Weapon(CombatAttributes WeaponAttributes, List<CombatStyle> CombatStyles):base()
        {
            this.WeaponAttributes = WeaponAttributes;
            this.CombatStyles = CombatStyles;
           
        
        }
        #endregion

        #region Properties
        [DataMember]
        CombatAttributes WeaponAttributes;
        [DataMember]
        List<CombatStyle> CombatStyles;
      
        #endregion
    }
}
