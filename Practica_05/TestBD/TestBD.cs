using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Data;
using System;
using PSS.pgr866.Practica_05;

namespace TestBD
{
    [TestClass]
    public class TestBD
    {
        [TestMethod]
        public void SqlServerFile_ProbarConexion()
        {
           string connectionString = @"data source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\WORKSPACES\2022-pss-pgr866\Practica_05\XMLAppConsola\AutentificacionDB.mdf;Integrated Security=True";
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new AutentificacionExcepcion(ex.ToString(), CodigoAutentificacion.ErrorDatos);
            }
        }

        [TestMethod()]
        public void SqlServerFile_SqlInsertar()
        {
            int result;
            string connectionString = @"data source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\WORKSPACES\2022-pss-pgr866\Practica_05\XMLAppConsola\AutentificacionDB.mdf;Integrated Security=True"; try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string nombre = "N_" + Guid.NewGuid().ToString();

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Insert INTO Autentificaciones (Nombre, PalabraPaso, Categoria,EsValido) " + " values (@newNombre , @newPalabraPaso,  @newCategoria , @newEsValido)";
                    cmd.Parameters.Add("@newNombre", SqlDbType.NVarChar, 20).Value = nombre;
                    cmd.Parameters.Add("@newPalabraPaso", SqlDbType.NVarChar, 20).Value = "PalabraPaso";
                    cmd.Parameters.Add("@newCategoria", SqlDbType.NVarChar, 20).Value = "Categoria";
                    cmd.Parameters.Add("@newEsValido", SqlDbType.Bit).Value = true;
                    result = cmd.ExecuteNonQuery();
                    if (result != 1) throw new Exception("Error al insertar un nuevo registro. ");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("No se esperaba la excepcion: " + ex.Message);
            }
        }

        [TestMethod()]
        public void SqlServerFile_SqlEliminarInsertado()
        {
            string connectionString = @"data source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\WORKSPACES\2022-pss-pgr866\Practica_05\XMLAppConsola\AutentificacionDB.mdf;Integrated Security=True";
            try
            {
                int MaxId = 0;
                int result = 0;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Insert INTO Autentificaciones (Nombre, PalabraPaso, Categoria, 			EsValido) " + " values (@newNombre , @newPalabraPaso,  @newCategoria , @newEsValido)";
                    cmd.Parameters.Add("@newNombre", SqlDbType.NVarChar, 20).Value = "Nombre";
                    cmd.Parameters.Add("@newPalabraPaso", SqlDbType.NVarChar, 20).Value = "PalabraPaso";
                    cmd.Parameters.Add("@newCategoria", SqlDbType.NVarChar, 20).Value = "Categoria";
                    cmd.Parameters.Add("@newEsValido", SqlDbType.Bit).Value = true;

                    result = cmd.ExecuteNonQuery();
                    if (result != 1) throw new Exception("Error al insertar un nuevo registro. ");

                    SqlCommand cmdId = conn.CreateCommand();
                    cmdId.CommandText = @"SELECT @@IDENTITY";
                    var objId = cmdId.ExecuteScalar();
                    MaxId = 1;
                    if (!Convert.IsDBNull(objId)) MaxId = Int32.Parse(objId.ToString());


                    SqlCommand cmdDel = conn.CreateCommand();
                    cmdDel.CommandText = "Delete Autentificaciones where Id = @IdUsuario ";
                    cmdDel.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = MaxId;
                    result = cmdDel.ExecuteNonQuery();
                    if (result != 1) throw new Exception("Error al Eliminar un nuevo registro. ");


                }
            }

            catch (Exception ex)
            {
                Assert.Fail("No se esperaba la excepcion: " + ex.Message);
            }
        }

        [TestMethod()]
        public void SqlServerFile_SqlModificarInsertado()
        {
            string connectionString = @"data source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\WORKSPACES\2022-pss-pgr866\Practica_05\XMLAppConsola\AutentificacionDB.mdf;Integrated Security=True";
            try
            {
                int MaxId = 0;
                int result = 0;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string nombre = "N_" + Guid.NewGuid().ToString();

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Insert INTO Autentificaciones (Nombre, PalabraPaso, Categoria, 			EsValido) " + " values (@newNombre , @newPalabraPaso,  @newCategoria , @newEsValido)";
                    cmd.Parameters.Add("@newNombre", SqlDbType.NVarChar, 20).Value = nombre;
                    cmd.Parameters.Add("@newPalabraPaso", SqlDbType.NVarChar, 20).Value = "PalabraPaso";
                    cmd.Parameters.Add("@newCategoria", SqlDbType.NVarChar, 20).Value = "Categoria";
                    cmd.Parameters.Add("@newEsValido", SqlDbType.Bit).Value = true;
                    result = cmd.ExecuteNonQuery();
                    if (result != 1) throw new Exception("Error al insertar un registro. ");

                    SqlCommand cmdId = conn.CreateCommand();
                    cmdId.CommandText = @"SELECT @@IDENTITY";
                    var objId = cmdId.ExecuteScalar();
                    MaxId = 1;
                    if (!Convert.IsDBNull(objId)) MaxId = Int32.Parse(objId.ToString());

                    string nombreMod = "N_" + Guid.NewGuid().ToString();
                    SqlCommand cmdMod = conn.CreateCommand();
                    cmdMod.CommandText = "Update Autentificaciones set Nombre = @newNombre ,PalabraPaso = @newPalabraPaso,  Categoria = @newCategoria , EsValido = @newEsValido WHERE Id=@IdUsuario ";
                    cmdMod.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = MaxId;
                    cmdMod.Parameters.Add("@newNombre", SqlDbType.NVarChar, 20).Value = nombreMod;
                    cmdMod.Parameters.Add("@newPalabraPaso", SqlDbType.NVarChar, 20).Value = "PalabraPasoMod";
                    cmdMod.Parameters.Add("@newCategoria", SqlDbType.NVarChar, 20).Value = "CategoriaMod";
                    cmdMod.Parameters.Add("@newEsValido", SqlDbType.Bit).Value = false;
                    result = cmdMod.ExecuteNonQuery();
                    if (result != 1) throw new Exception("Error al Modificar  un registro. ");

                }
            }

            catch (Exception ex)
            {
                Assert.Fail("No se esperaba la excepcion: " + ex.Message);
            }
        }



    }
}