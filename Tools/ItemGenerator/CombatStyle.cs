/*
   Copyright 2013 Glendale Community College Computer Science Organization

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
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
            CombatAttributes AttackAttributes = new CombatAttributes();
            
            return new CombatAttributes();
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
