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
    public class CombatAttributes
    {
        #region Constructors
        public CombatAttributes()
        {
            elements = new Elemental(0, 0, 0, 0);
            normal = new Normal(0, 0, 0);
        }
        public CombatAttributes(Decimal Fire, Decimal Ice, Decimal Air, Decimal Earth, Decimal Slashing, Decimal Bashing, Decimal Piercing)
        {
            elements = new Elemental(Fire, Ice, Air, Earth);
            normal = new Normal(Slashing, Bashing, Piercing);
        }
        public CombatAttributes(Elemental elemental, Normal normal)
        {
            elements = elemental;
            this.normal = normal;
        }
        #endregion

        #region Structures
        #region Elemental Damage Structure
        [DataContract]
        public struct Elemental
        {
            #region constructors
            public Elemental(Decimal Fire, Decimal Ice, Decimal Air, Decimal Earth)
            {
                this.Fire = Fire;
                this.Ice = Ice;
                this.Air = Air;
                this.Earth = Earth;

            }
            #endregion
            #region Function Members
            #region Operators
            public static Elemental operator +(Elemental first, Elemental other)
            {
                return new Elemental(first.Fire + other.Fire, first.Ice + other.Ice, 
                    first.Air + other.Air, first.Earth + other.Earth);
            }
            public static Elemental operator *(Elemental first, Elemental other)
            {
                return new Elemental(first.Fire * other.Fire, first.Ice * other.Ice,
                    first.Air * other.Air, first.Earth * other.Earth);
            }
            public static Elemental operator -(Elemental first, Elemental other)
            {
                return new Elemental(first.Fire - other.Fire, first.Ice - other.Ice,
                    first.Air - other.Air, first.Earth - other.Earth);
            }
            public static Elemental operator /(Elemental first, Elemental other)
            {
                return new Elemental(first.Fire / other.Fire, first.Ice / other.Ice,
                    first.Air / other.Air, first.Earth / other.Earth);
            }
            #endregion
            #endregion
            #region Data Members
            [DataMember]
            public Decimal Fire;
            [DataMember]
            public Decimal Ice;
            [DataMember]
            public Decimal Air;
            [DataMember]
            public Decimal Earth;
            #endregion
        }
        #endregion

        #region Normal Damage Structure
        [DataContract]
        public struct Normal
        {
            #region constructors            
            public Normal(Decimal Slashing, Decimal Bashing, Decimal Piercing)
            {
                this.Slashing = Slashing;
                this.Bashing = Bashing;
                this.Piercing = Piercing;
            }
            #endregion
            #region Function Members
            #region Operators
            public static Normal operator +(Normal first, Normal other)
            {
                return new Normal(first.Slashing + other.Slashing, first.Bashing + other.Bashing, first.Piercing + other.Piercing);
            }
            public static Normal operator *(Normal first, Normal other)
            {
                return new Normal(first.Slashing * other.Slashing, first.Bashing * other.Bashing, first.Piercing * other.Piercing);
            }
            public static Normal operator -(Normal first, Normal other)
            {
                return new Normal(first.Slashing - other.Slashing, first.Bashing - other.Bashing, first.Piercing - other.Piercing);

            }
            public static Normal operator /(Normal first, Normal other)
            {
                return new Normal(first.Slashing / other.Slashing, first.Bashing / other.Bashing, first.Piercing / other.Piercing);
            }
            #endregion
            #endregion
            #region Data Members
            [DataMember]
            public Decimal Slashing;
            [DataMember]
            public Decimal Bashing;
            [DataMember]
            public Decimal Piercing;
            #endregion
        }
        #endregion
        #endregion
        #region Function Members
        #region Operators
        public static CombatAttributes operator +(CombatAttributes first, CombatAttributes other)
        {
            return new CombatAttributes(first.elements + other.elements, first.normal + other.normal);
        }
        public static CombatAttributes operator *(CombatAttributes first, CombatAttributes other)
        {
            return new CombatAttributes(first.elements * other.elements, first.normal * other.normal);
        }
        public static CombatAttributes operator -(CombatAttributes first, CombatAttributes other)
        {
            return new CombatAttributes(first.elements - other.elements, first.normal - other.normal);
        }
        public static CombatAttributes operator /(CombatAttributes first, CombatAttributes other)
        {
            return new CombatAttributes(first.elements / other.elements, first.normal / other.normal);
        }
        #endregion
        #endregion
        #region Data Members
        [DataMember]
        public Elemental elements { get; set; }
        [DataMember]
        public Normal normal { get; set; }
        #endregion
    }

}
