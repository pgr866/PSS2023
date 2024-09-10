using System.Diagnostics.CodeAnalysis;

namespace PSS.pgr866.Practica_02
{
    public class UsuarioView : IUsuarioView, IEquatable<UsuarioView>, IEqualityComparer<UsuarioView>, IComparable<UsuarioView>
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string PalabraPaso { get; set; }
        public string Categoria { get; set; }
        public bool EsValido { get; set; }

        public UsuarioView(int id, string nombre, string palabraPaso, string categoria, bool esValido)
        {
            this.Id = Convert.ToString(id);
            this.Nombre = nombre;
            this.PalabraPaso = palabraPaso;
            this.Categoria = categoria;
            this.EsValido = esValido;
        }
        public UsuarioView()
        {

        }

        public bool Equals(UsuarioView? other)
        {
            if (object.ReferenceEquals(this, other)) return true;
            if (object.ReferenceEquals(other, null)) return false;
            return this.Id.Equals(other.Id);
        }

        public bool Equals(UsuarioView? x, UsuarioView? y)
        {
            if (object.ReferenceEquals(x, y)) return true;
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) return false;
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode([DisallowNull] UsuarioView obj)
        {
            return (obj == null) ? "".GetHashCode() : (obj as object).GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return (obj == null) ? false : Equals(obj as UsuarioView);
        }
        public override int GetHashCode()
        {
            if (string.IsNullOrEmpty(this.Id)) return "".GetHashCode();
            return this.Id.GetHashCode();
        }

        public static bool operator ==(UsuarioView user1, UsuarioView user2)
        {
            if (object.ReferenceEquals(user1, user2)) return true;
            if (object.ReferenceEquals(user1, null)) return false;
            if (object.ReferenceEquals(user2, null)) return false;
            return user1.Equals(user2);
        }
        public static bool operator !=(UsuarioView user1, UsuarioView user2)
        {
            return !(user1 == user2);
        }

        public int CompareTo(UsuarioView? other)
        {
            if (object.ReferenceEquals(this, other)) return 0;
            if (object.ReferenceEquals(other, null)) return 1;
            if (object.ReferenceEquals(this, null)) return -1;
            return this.GetType().Equals(other.GetType())
                ? this.Id.CompareTo(other.Id)
                : throw new ArgumentException("No se pueden comparar objetos de diferente tipo");
        }

        public static bool operator <(UsuarioView? user1, UsuarioView? user2)
        {
            if (object.ReferenceEquals(user1, user2)) return false;
            if (object.ReferenceEquals(user1, null)) return true;
            return user1.CompareTo(user2) < 0;
        }

        public static bool operator >(UsuarioView? user1, UsuarioView? user2)
        {
            return !(user1 < user2 ||  user1 == user2);
        }

        public static bool operator <=(UsuarioView? user1, UsuarioView? user2)
        {

            return !(user1 > user2);
        }

        public static bool operator >=(UsuarioView? user1, UsuarioView? user2)
        {
            return !(user1 < user2);
        }


    }
}
