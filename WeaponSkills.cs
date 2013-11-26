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
