using CitasSAPSO.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CitasSAPSO.Data
{
    public class SecurityData
    {

        private SqlConnection connection;

        public SecurityData()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);
        }

        public void AssignUserRole(UserModels user)
        {
            string sqlQuery = $"exec sp_asignar_usuario_rol " + user.Cedula +", "+ user.Role.IdRole+", '"+user.Password+"'";

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }

        }


        public List<RoleModels> GetListRoles()
        {
            List<RoleModels> role = new List<RoleModels>();
            string sqlQuery = $"exec sp_obtener_roles";
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader roleReader = command.ExecuteReader();
                while (roleReader.Read())
                {
                    RoleModels roleTemp = new RoleModels();
                    roleTemp.IdRole = Int32.Parse(roleReader["pk_id_rol"].ToString());
                    roleTemp.Name = roleReader["tc_nombre_rol"].ToString();
                   
                    role.Add(roleTemp);
                }
                connection.Close();
            }

            return role;
        }

        public List<UserModels> GetListUsersRoles()
        {
            List<UserModels> users = new List<UserModels>();
            string sqlQuery = $"exec sp_obtener_usuarios_rol";
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader userReader = command.ExecuteReader();
                while (userReader.Read())
                {
                    UserModels userTemp = new UserModels();
                    userTemp.Cedula = Int32.Parse(userReader["pk_cedula_usuario"].ToString());
                    userTemp.Name = userReader["tc_nombre"].ToString();
                    userTemp.Role.Name = userReader["tc_nombre_rol"].ToString();
                    userTemp.Role.IdRole = Int32.Parse(userReader["pk_id_rol"].ToString());

                    users.Add(userTemp);
                }
                connection.Close();
            }

            return users;
        }

        public void RegisterRole(RoleModels role)
        {
            string sqlQuery = $"exec sp_registrar_rol " + "'" + role.Name + "'";

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }

        public void ModifyRole(RoleModels role)
        {
            string sqlQuery = $"exec sp_modificar_rol '" + role.Name + "'," + role.IdRole ;

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }

        public void DeleteRole(RoleModels role)
        {
            string sqlQuery = $"exec sp_eliminar_rol " + role.IdRole;

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }
    }
}