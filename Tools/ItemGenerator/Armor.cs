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
    using Code0;
    [DataContract]
    class Armor
    {
        #region constructors
        public Armor()
        {
            Resistance = new CombatAttributes();
            Soak = new CombatAttributes();
            StatBoost = new CharacterAttributes();
            SkillBoost = new WeaponSkills();
        }

        public Armor(CombatAttributes Resistance, CombatAttributes Soak, CharacterAttributes StatBoost, WeaponSkills SkillBoost)
        {
            this.Resistance = Resistance;
            this.Soak = Soak;
            this.StatBoost = StatBoost;
            this.SkillBoost = SkillBoost;
        }
        #endregion
        #region properties
        [DataMember]
        public CombatAttributes Resistance { get; set; }
        [DataMember]
        public CombatAttributes Soak { get; set; }
        [DataMember]
        public CharacterAttributes StatBoost { get; set; }
        [DataMember]
        public WeaponSkills SkillBoost { get; set; }
        #endregion
    }
}
