using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Logueo
{
    internal class Mantenimiento
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private string cadena = "Data Source=ServerName;Initial Catalog=NombreDataBase;Integrated Security= True";
        private void Conectar()
        {
            conexion = new SqlConnection(cadena);
        }
        public void Alta(Usuario user)
        {
            Conectar();
            comando = new SqlCommand("insert into usuarios (nombre,clave) values (@nombre,@clave)", conexion);           
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@clave", SqlDbType.VarChar);            
            comando.Parameters["@nombre"].Value = user.nombre;
            comando.Parameters["@clave"].Value = user.clave;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public Usuario Leer(string nombre)
        {
            Conectar();
            comando = new SqlCommand("select nombre,clave from usuarios where nombre=@nombre", conexion);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = nombre;
            conexion.Open();
            SqlDataReader registro = comando.ExecuteReader();
            Usuario user = new Usuario();
            if (registro.Read())
            {
                user.nombre = registro["nombre"].ToString();
                user.clave = registro["clave"].ToString();                
            }
            conexion.Close();
            return user;
        }
    }
}
