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
