using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ItemGenerator
{
    [DataContract]
    public partial class CombatStyle:IComparable
    {
        #region constructors
        public CombatStyle()
        {
            Attributes = new CombatAttributes();
            Name = "";
            PartialClassLocation = "";
            Animation = "";
        }

        public CombatStyle(CombatStyle comb)
        {
            this.Attributes = comb.Attributes;
            this.Name = comb.Name;
            this.PartialClassLocation = comb.PartialClassLocation;
            this.Animation = comb.Animation;
        }
        public CombatStyle(CombatAttributes Attributes, String Name, String PartialClassLocation, String Animation)
        {
            this.Attributes = Attributes;
            this.Name = Name;
            this.PartialClassLocation = PartialClassLocation;
            this.Animation = Animation;
        }
        #endregion
        #region methods
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;
            CombatStyle other = obj as CombatStyle;
            if ((Attributes == other.Attributes) &&
                (Name == other.Name) &&
                (PartialClassLocation == other.PartialClassLocation) &&
                (Animation == other.Animation))
                return 0;
            else
                return 1;
        }
        
        public CombatAttributes Attack(CombatAttributes weaponStats)
        {            
            if (weaponStats == Attributes)
            {
                return weaponStats;
            }
            CombatAttributes AttackAttributes = weaponStats * Attributes;
            

            return AttackAttributes;
        }

        public override bool Equals(object obj)
        {
            CombatStyle other = obj as CombatStyle;
          /*  if ((Attributes == other.Attributes) &&
                (Name == other.Name) &&
                (PartialClassLocation == other.PartialClassLocation) &&
                (Animation == other.Animation))
                return true;
            else
                return false;
            */
            if (other == null)
                return false;
            else if (other.Name == Name)
                return true;
            else
                return false;
        }
        
        public override int GetHashCode()
        {
            return Attributes.GetHashCode() * Name.GetHashCode() * PartialClassLocation.GetHashCode() * Animation.GetHashCode();
        }
        #endregion
        #region Data Members
        [DataMember]
        public CombatAttributes Attributes {get; set;}
        [DataMember]
        public String Name {get; set;}
        [DataMember]
        public String PartialClassLocation {get; set;}
        [DataMember]
        public String Animation {get;set;}
        #endregion

    }
}
