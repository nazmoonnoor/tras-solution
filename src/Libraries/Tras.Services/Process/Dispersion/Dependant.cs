using System;

namespace Tras.Services.Process.Dispersion
{

    public interface IDependant
    {
        Type ScaleType { get; }

        int GetNumberOf();
    }
    
    public class OfficerSelf : IDependant
    {
        public int NumberOf { get; set; }

        public Type ScaleType 
        {
            get
            {
                return typeof(ScaleGeneral);
            }
        }

        public int GetNumberOf()
        {
            return NumberOf;
        }
    }

    public class SoldierSelf : IDependant
    {
        public int NumberOf { get; set; }

        public Type ScaleType
        {
            get
            {
                return typeof(ScaleSoldier);
            }
        }

        public int GetNumberOf()
        {
            return NumberOf;
        }

    }
    
    public class Spouse : IDependant
    {
        public int NumberOf { get; set; }

        public Type ScaleType
        {
            get
            {
                return typeof(ScaleGeneral);
            }
        }

        public int GetNumberOf()
        {
            return NumberOf;
        }
    }
    
    public class KidsMinor : IDependant
    {
        public int NumberOf { get; set; }

        public Type ScaleType
        {
            get
            {
                return typeof(ScaleMinor);
            }
        }

        public int GetNumberOf()
        {
            return NumberOf;
        }
    }
    
    public class KidsAdult : IDependant
    {
        public int NumberOf { get; set; }

        public Type ScaleType
        {
            get
            {
                return typeof(ScaleGeneral);
            }
        }

        public int GetNumberOf()
        {
            return NumberOf;
        }
    }
    
    public class KidsHalf : IDependant
    {
        public int NumberOf { get; set; }

        public Type ScaleType
        {
            get
            {
                return typeof(ScaleHalf);
            }
        }

        public int GetNumberOf()
        {
            return NumberOf;
        }
    }
    
    public class BatMan : IDependant
    {
        public int NumberOf { get; set; }

        public Type ScaleType
        {
            get
            {
                return typeof(ScaleGeneral);
            }
        }

        public int GetNumberOf()
        {
            return NumberOf;
        }
    }
}