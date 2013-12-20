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
