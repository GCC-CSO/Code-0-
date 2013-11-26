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
