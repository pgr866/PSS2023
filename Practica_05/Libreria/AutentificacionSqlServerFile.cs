using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.pgr866.Practica_05
{
    /// <summary>
    /// Clase AutentificacionSqlServerFile que implementa el interface IAutentificacion mediante una cadena de conexion a base de datos (parámetro del constructor) a una base de datos SqlServer (*.mdf)
    /// </summary>
    public class AutentificacionSqlServerFile : IAutentificacion
    {
        private string cadenaConex;
        /// <summary>
        ///   Constructor de la clase que tiene como parámetro la cadena de conexion a la base de datos.
        ///   Generar una excepción ErrorDatos si la conexion no es accesible.
        /// </summary>
        /// <param name="conexion"> cadena de conexion:  
        /// ejemplo de cadena de conexion = @"data source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AutentificacionDB.mdf;Integrated Security=True";
        ///</param>
        public AutentificacionSqlServerFile(string cadenaConexion)
        {
            cadenaConex = cadenaConexion;
        }

        public bool EliminarUsuario(string id)
        {
            try
            {
                int userId = Int32.Parse(id);
                using (SqlConnection conn = new SqlConnection(cadenaConex))
                {
                    conn.Open();
                    SqlCommand cmdDel = conn.CreateCommand();
                    cmdDel.CommandText = "Delete Autentificaciones where Id = @IdUsuario ";
                    cmdDel.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = userId;
                    int result = cmdDel.ExecuteNonQuery();

                    conn.Close();
                    
                    if (result != 1)
                        return false;
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public CodigoAutentificacion EsUsuarioAutentificado(string id, string PalabraPaso)
        {
            Int32 numeroId = Int32.Parse(id);
            CodigoAutentificacion codigo = CodigoAutentificacion.AccesoCorrecto;
            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConex))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "select Id, Nombre, PalabraPaso, EsValido "
                                + " from Autentificaciones  "
                                + " where Id=@newId";
                    cmd.Parameters.Add("@newId", SqlDbType.Int).Value = numeroId;

                    SqlDataReader resul = cmd.ExecuteReader();
                    if (!resul.HasRows)
                        codigo = CodigoAutentificacion.ErrorIdUsuario;
                    else
                    {
                        resul.Read();

                        string resulPalabra = resul.GetFieldValue<string>(2);
                        bool resulValido = resul.GetFieldValue<bool>(3); 

                        if (resulPalabra != PalabraPaso)
                        {
                            if (resulValido == true)
                                codigo = CodigoAutentificacion.ErrorPalabraPaso;
                            else
                                codigo = CodigoAutentificacion.ErrorPalabraPaso |
                                        CodigoAutentificacion.AccesoInvalido;
                        }
                        else
                        {
                            if (resulValido == false)
                                codigo = CodigoAutentificacion.AccesoInvalido;
                        }
                    }
                    conn.Close();
                }
            }
            catch
            {
                codigo = CodigoAutentificacion.ErrorDatos;
            }
            return codigo;
        }

        //Este método no hace falta hacerlo 
        public void GuardarDatos()
        {
        }

        public bool InsertarUsuario(IUsuarioView user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConex))
                {
                    conn.Open();

                    SqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = "Insert INTO Autentificaciones (Nombre, PalabraPaso, Categoria,EsValido) " +
                                      " values (@newNombre , @newPalabraPaso,  @newCategoria , @newEsValido)";
                    cmd.Parameters.Add("@newNombre", SqlDbType.NVarChar, 20).Value = user.Nombre;
                    cmd.Parameters.Add("@newPalabraPaso", SqlDbType.NVarChar, 20).Value = user.PalabraPaso;
                    cmd.Parameters.Add("@newCategoria", SqlDbType.NVarChar, 20).Value = user.Categoria;
                    cmd.Parameters.Add("@newEsValido", SqlDbType.Bit).Value = user.EsValido;
                    int result = cmd.ExecuteNonQuery();

                    conn.Close();
                    if (result != 1)
                        return false;
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool ModificarUsuario(string id, IUsuarioView user)
        {
            Int32 numeroId = Int32.Parse(id);
            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConex))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "update Autentificaciones" +
                        " set Nombre = @newNombre, PalabraPaso=@newPalabraPaso, " +
                        " Categoria = @newCategoria, EsValido = @newEsValido where Id=@newId";
                    cmd.Parameters.Add("@newId", SqlDbType.Int).Value = numeroId;
                    cmd.Parameters.Add("@newNombre", SqlDbType.NVarChar, 20).Value = user.Nombre;
                    cmd.Parameters.Add("@newPalabraPaso", SqlDbType.NVarChar, 20).Value = user.PalabraPaso;
                    cmd.Parameters.Add("@newCategoria", SqlDbType.NVarChar, 20).Value = user.Categoria;
                    cmd.Parameters.Add("@newEsValido", SqlDbType.Bit).Value = user.EsValido; ;

                    int resul = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (resul != 1)
                        return false;
                    else
                        return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public IUsuarioView ObtenerUsuario(string id)
        {
            Int32 numeroId = Int32.Parse(id);
            IUsuarioView user = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConex))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "select Id, Nombre, PalabraPaso, Categoria, EsValido "
                                + " from Autentificaciones  "
                                + " where Id=@newId";
                    cmd.Parameters.Add("@newId", SqlDbType.Int).Value = numeroId;

                    SqlDataReader resul = cmd.ExecuteReader();
                    if (resul.HasRows)
                    {
                        resul.Read();

                        string nombre = resul.GetFieldValue<string>(1);
                        string palabra = resul.GetFieldValue<string>(2);
                        string categoria = resul.GetFieldValue<string>(3);
                        bool valido = resul.GetFieldValue<bool>(4);
                        user = new UsuarioView(numeroId, nombre, palabra, categoria, valido);

                    }
                    conn.Close();
                }
            }
            catch
            { 
            }
            return user;
        }

        //Este método no hace falta hacerlo 
        public void Listado()
        {
        }

    }
}
