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
    class CharacterAttributes
    {
        #region constructors        
        public CharacterAttributes()
        {
            Fortitude = new Decimal(0);
            Strength = new Decimal(0);
            Agility = new Decimal(0);
        }
        public CharacterAttributes(decimal Fortitude, decimal Strength, decimal Agility)
        {            
            this.Fortitude = Fortitude;
            this.Strength = Strength;
            this.Agility = Agility;
        }
        #endregion

        #region properties
        [DataMember]
        public decimal Fortitude{get; set;}
        [DataMember]
        public decimal Strength{get; set;}
        [DataMember]
        public decimal Agility{ get; set; }
        #endregion
    }
}
