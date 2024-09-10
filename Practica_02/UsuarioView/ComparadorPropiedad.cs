using System;
using System.ComponentModel;

namespace PSS.pgr866.Practica_02
{
    public class ComparadorPropiedad<T> : IComparer<T> where T : IComparable<T>
    {
        private PropertyDescriptor pd;

        public ComparadorPropiedad(string nombre)
        {
            pd = GetProperty(nombre);
            if (pd is null) throw new ArgumentException("Propiedad no existente");
            Type propertyType = Nullable.GetUnderlyingType(pd.PropertyType) ?? pd.PropertyType;

            if (!typeof(IComparable).IsAssignableFrom(propertyType))
                throw new ArgumentException("La propiedad " + nombre + " no es comparable");
        }

        private PropertyDescriptor GetProperty(string name)
        {
            T item = (T)Activator.CreateInstance(typeof(T));
            PropertyDescriptor propName = null;
            foreach (PropertyDescriptor propDesc in TypeDescriptor.GetProperties(item))
            {
                if (propDesc.Name.Contains(name)) propName = propDesc;
            }
            return propName;
        }

        public int Compare(T? a, T? b)
        {
            if (a is null && b is null) return 0;
            if (a is null) return -1;
            if (b is null) return 1;
            var valueA = pd.GetValue(a) as IComparable;
            var valueB = pd.GetValue(b) as IComparable;
            return valueA.CompareTo(valueB);
        }
    }
}