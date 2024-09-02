using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DISCOSFormsApp1
{
    internal class DiscosNegocio
    {
        public List<Discos> listar() 
        {
            List<Discos> lista = new List<Discos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=(localdb)\\tinchoServer; database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Titulo, FechaLanzamiento, CantidadCanciones From DISCOS";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Discos aux = new Discos();
                    aux.Titulo = (string)lector["Titulo"];
                    aux.FechaLansamiento = (DateTime)lector["FechaLanzamiento"];
                    aux.CantidadCanciones = lector.GetInt32(0);

                    lista.Add(aux);
                }


                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
