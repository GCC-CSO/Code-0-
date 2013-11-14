using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ItemGenerator
{
    [DataContract]
    partial class CombatStyle
    {
        #region constructors
        public CombatStyle()
        {
            Attributes = new CombatAttributes();
            Name = "";
            PartialClassLocation = "";
            Animation = "";
        }
        public CombatStyle(CombatAttributes Attributes, String Name, String PartialClassLocation, String Animation)
        {
            this.Attributes = Attributes;
            this.Name = Name;
            this.PartialClassLocation = PartialClassLocation;
            this.Animation = Animation;
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
