using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.pgr866.Practica_05
{
    public class UsuarioView: IUsuarioView
    {
        #region IUsuario Members
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string PalabraPaso { get; set; }
        public string Categoria { get; set; }
        public bool EsValido { get; set; }
        #endregion
        public UsuarioView()
        { }
        public UsuarioView(int id, string nombre, string palabraPaso, string categoria, bool esValido)
        {
            Id = id.ToString();
            Nombre = nombre;
            PalabraPaso = palabraPaso;
            Categoria = categoria;
            EsValido = esValido;
        }
        public UsuarioView(params string[] campos)
        {
            if (campos.Length > 0) Id = campos[0];
            if (campos.Length > 1) Nombre = campos[1];
            if (campos.Length > 2) PalabraPaso = campos[2];
            if (campos.Length > 3) Categoria = campos[3];
            if (campos.Length > 4) EsValido = (campos[4].ToUpper() == "TRUE");
        }

        public override string ToString()
        {
            string cadena = "Id: " + Id + "\n" +
                            "Nombre: " + Nombre + "\n" +
                            "PalabraPaso: " + PalabraPaso + "\n" +
                            "Categoria: " + Categoria + "\n" +
                            "EsValido: " + EsValido + "\n";
            return cadena;
        }
    }
}
