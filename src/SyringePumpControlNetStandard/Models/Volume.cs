using System;

namespace SyringePumpControlNetStandard.Models
{
    public struct Volume:IEquatable<Volume>
    {
        public static Volume Default()
        {
            return new Volume(0, Units.MilliLiters);
        }
        
        public static implicit operator Volume(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return Default();

            var unitsStringValue = value.Substring(value.Length - 3);

            var stringValue = value.Replace(unitsStringValue, string.Empty);

            if (!float.TryParse(stringValue, out float floatValue))
            {
                return Default();
            }

            var unit = Units.MilliLiters;

            if (unitsStringValue.ToLower() == "ul" || unitsStringValue == "microliters")
            {
                unit = Units.MicroLiters;
            }
            
            var v = new Volume(floatValue, unit){_stringValue = value};

            return v;
        }
        
        public Volume(float value, Units unit)
        {
            Value = value;
            Unit = unit;
            var stringUnit = unit == Units.MicroLiters ? "uL" : "mL";
            _stringValue = $"{Value}{stringUnit}";
        }

        private string _stringValue;
        public float Value { get; } 

        public Units Unit { get; }

        public override string ToString()
        {
            return _stringValue;
        }

        #region IEquatable

        public bool Equals(Volume other)
        {
            return _stringValue == other._stringValue && Value.Equals(other.Value) && Unit == other.Unit;
        }

        public override bool Equals(object obj)
        {
            return obj is Volume other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_stringValue != null ? _stringValue.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)Unit;
                return hashCode;
            }
        }

        #endregion
    }
}