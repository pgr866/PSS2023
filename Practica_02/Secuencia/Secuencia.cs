using System;
using System.Collections;

namespace PSS.pgr866.Practica_02
{
    public class Secuencia<T> : List<T>, IEnumerable<T>, ISecuencia<T> where T : IComparable<T>
    {

        public void Añadir(T item)
        {
            this.Add(item);
        }

        public bool Eliminar(T item)
        {
            return this.Remove(item);
        }
        public bool Contiene(T item)
        {
            return this.Contains(item);
        }

        public void Limpiar()
        {
            this.Clear();
        }

        public int Cuenta
        {
            get { return this.Count; }
        }

        public void Ordenar(IComparer<T> comparador)
        {
            if (comparador is null) return;
            this.Sort(comparador);
        }

        public T this[int i]
        {
            get
            {
                if (i < 0 || i >= this.Count) throw new ArgumentOutOfRangeException("Posicion inexistente");
                return this[i];
            }
            set
            {
                if (i < 0 || i >= this.Count) throw new ArgumentOutOfRangeException("Posicion inexistente");
                this[i] = value;
            }
        }

        public IEnumerable<T> RecorridoAdelante()
        {
            foreach (T a in this)
            {
                yield return a;
            }
        }
        public IEnumerable<T> RecorridoAtras()
        {
            List<T> lista = new List<T>(this);
            lista.Reverse();
            foreach (T t in lista)
            {
                yield return t;
            }
        }

        public IEnumerable<T> RecorridoAscendente(ComparadorPropiedad<T> c)
        {
            Secuencia<T> nueva = new Secuencia<T>();
            foreach (T t in this)
            {
                nueva.Añadir(t);
            }
            nueva.Ordenar(c);
            foreach (T t in nueva)
            {
                yield return t;
            }
        }
        public IEnumerable<T> RecorridoDescendente(ComparadorPropiedad<T> c)
        {
            Secuencia<T> nueva = new Secuencia<T>();
            foreach (T t in this)
            {
                nueva.Añadir(t);
            }
            nueva.Ordenar(c);
            nueva.Reverse();
            foreach (T t in nueva)
            {
                yield return t;
            }
        }

    }
}