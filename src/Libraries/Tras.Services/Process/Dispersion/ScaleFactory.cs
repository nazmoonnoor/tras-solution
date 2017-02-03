using System;
using System.Collections.Generic;
using System.Reflection;

namespace Tras.Services.Process.Dispersion
{
    public class ScaleFactory
    {
        private Dictionary<string, Type> _scales;

        public ScaleFactory()
        {
            LoadScaleTypes();
        }

        public IRationScale CreateInstance(string scaleName)
        {
            Type t = GetTypeToCreate(scaleName);
            if (t == null)
            {
                throw new Exception("No Such Scale.");
            }

            return Activator.CreateInstance(t) as IRationScale;
        }

        private Type GetTypeToCreate(string scaleName)
        {
            foreach (var scale in _scales)
            {
                if (scale.Key.Contains(scaleName))
                {
                    return _scales[scale.Key];
                }
            }

            return null;
        }

        private void LoadScaleTypes()
        {
            _scales = new Dictionary<string, Type>();

            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in typesInThisAssembly)
            {
                if (type.GetInterface(typeof (IRationScale).ToString()) != null)
                {
                    _scales.Add(type.Name.ToLower(), type);
                }
            }
        }
    }
}
