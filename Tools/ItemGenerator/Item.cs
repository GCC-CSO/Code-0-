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
    class Item
    {
        #region Constructors
        public Item()
        {
            Name = "";
            Type = "";
            Subtype = "";
            Weight = new Decimal(0);
            Value = new Decimal(0);
        }
        public Item(String Name, String Type, String Subtype, Decimal Weight, Decimal Value)
        {
            this.Name = Name;
            this.Type = Type;
            this.Subtype = Subtype;
            this.Weight = Weight;
            this.Value = Value;
        }
        #endregion

        #region properties
        [DataMember]
        String Name { get; set; }
        [DataMember]
        String Type { get; set;}
        [DataMember]
        String Subtype { get; set;} 
        [DataMember]
        Decimal Weight { get; set; }
        [DataMember]
        Decimal Value { get; set; }
        #endregion
    }
}
