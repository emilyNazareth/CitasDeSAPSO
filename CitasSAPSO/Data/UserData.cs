using CitasSAPSO.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitasSAPSO.Data
{
    [AllowAnonymous]
    public class UserData
    {

        private SqlConnection connection;
        public UserData()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);
        }


        public List<UserModels> GetFunctionary(int _cedula)
        {
            List<UserModels> functionary = new List<UserModels>();
            UserModels resultFunctionary = new UserModels();

            string sqlQuery = $"exec sp_buscar_funcionario_cedula " + _cedula + "";

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader responseReader = command.ExecuteReader();
                while (responseReader.Read())
                {
                    resultFunctionary.Cedula = Int32.Parse(responseReader["pk_cedula_usuario"].ToString());
                    resultFunctionary.Name = responseReader["tc_nombre"].ToString();
                    resultFunctionary.FirstLastName = responseReader["tc_primer_apellido"].ToString();
                    resultFunctionary.SecondLastName = responseReader["tc_segundo_apellido"].ToString();
                    resultFunctionary.PersonalPhone = responseReader["tc_telefono_personal"].ToString();
                    resultFunctionary.RoomPhone = responseReader["tc_telefono_habitacion"].ToString();
                    resultFunctionary.Birthday = responseReader["tf_fecha_nacimiento"].ToString();
                    resultFunctionary.Gender = char.Parse(responseReader["tc_sexo"].ToString());
                    resultFunctionary.Scholarship = responseReader["tc_escolaridad"].ToString();
                    resultFunctionary.Province = responseReader["tc_provincia"].ToString();
                    resultFunctionary.Canton = responseReader["tc_canton"].ToString();
                    resultFunctionary.District = responseReader["tc_distrito"].ToString();
                    resultFunctionary.CivilStatus = responseReader["tc_estado_civil"].ToString();
                    resultFunctionary.Address = responseReader["tc_direccion"].ToString();
                    resultFunctionary.PlaceID = Int32.Parse(responseReader["fk_id_puesto"].ToString());
                    resultFunctionary.AreaID = Int32.Parse(responseReader["fk_id_area"].ToString());
                    resultFunctionary.OfficeID = Int32.Parse(responseReader["fk_id_oficina"].ToString());
                    resultFunctionary.NamePlace = responseReader["tc_nombre_puesto"].ToString();
                    resultFunctionary.NameArea = responseReader["tc_nombre_area"].ToString();
                    resultFunctionary.NameOffice = responseReader["tc_nombre_oficina"].ToString();
                    resultFunctionary.OficePhone = responseReader["tc_telefono_oficina"].ToString();
                    resultFunctionary.Mail = responseReader["tc_correo_electronico"].ToString();
                    resultFunctionary.IdPlaca = responseReader["tn_id_placa"].ToString();
                    resultFunctionary.PortationExpirationDay = responseReader["tf_fecha_vencimiento_portacion"].ToString();
                    resultFunctionary.AdmissionDate = responseReader["tf_fecha_ingreso"].ToString();
                    resultFunctionary.Assistance = Int32.Parse(responseReader["tc_asistencia"].ToString());

                }
                connection.Close();
            }

            functionary.Add(resultFunctionary);
            return functionary;
        }



        public void SaveFunctionary(UserModels _functionary)
        {

            string sqlQuery = $"exec sp_registrar_funcionario " + _functionary.Cedula + ",'" + _functionary.Name + "','" + _functionary.FirstLastName
                + "','" + _functionary.SecondLastName + "','" + _functionary.PersonalPhone + "','" + _functionary.RoomPhone + "','" + _functionary.Birthday
                + "','" + _functionary.Gender + "','" + _functionary.Scholarship + "','" + _functionary.Province + "','" + _functionary.Canton
                + "','" + _functionary.District + "','" + _functionary.CivilStatus + "','" + _functionary.Address + "','" + _functionary.OficePhone
                + "','" + _functionary.Mail + "','" + _functionary.IdPlaca + "','" + _functionary.PortationExpirationDay + "'," +
                _functionary.PlaceID + "," + _functionary.AreaID + "," + _functionary.OfficeID + ",'" + _functionary.AdmissionDate + "'," + _functionary.Assistance;
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader responseReader = command.ExecuteReader();
                connection.Close();
            }
        }


        public void ModifyFunctionary(UserModels _functionary)
        {

            string sqlQuery = $"exec sp_modificar_funcionario " + _functionary.Cedula + ",'" + _functionary.Name + "','" + _functionary.FirstLastName
                + "','" + _functionary.SecondLastName + "','" + _functionary.PersonalPhone + "','" + _functionary.RoomPhone + "','" + _functionary.Birthday
                + "','" + _functionary.Gender + "','" + _functionary.Scholarship + "','" + _functionary.Province + "','" + _functionary.Canton
                + "','" + _functionary.District + "','" + _functionary.CivilStatus + "','" + _functionary.Address + "','" + _functionary.OficePhone
                + "','" + _functionary.Mail + "','" + _functionary.IdPlaca + "','" + _functionary.PortationExpirationDay + "'," +
                _functionary.PlaceID + "," + _functionary.AreaID + "," + _functionary.OfficeID + ",'" + _functionary.AdmissionDate + "'," + _functionary.Assistance;
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }

        public List<UserModels> GetListProfessionals()
        {
            List<UserModels> professionals = new List<UserModels>();


            string sqlQuery = $"exec sp_obtener_profesionales";
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader responseReader = command.ExecuteReader();
                while (responseReader.Read())
                {
                    UserModels professionalTemp = new UserModels();
                    professionalTemp.ProfessionalId = Int32.Parse(responseReader["consecutivo"].ToString());
                    professionalTemp.Cedula = Int32.Parse(responseReader["cedula"].ToString());
                    professionalTemp.Name = responseReader["nombre"].ToString();
                    professionalTemp.FirstLastName = responseReader["apellido"].ToString();


                    professionals.Add(professionalTemp);
                }
                connection.Close();
            }

            return professionals;
        }

        /*
        Register a professional 
       */
        public void RegisterProfessional(UserModels _professional)
        {

            int processQuantity = _professional.Process.Length;
            string sqlQuery = $"exec sp_registrar_usuario_professional " + _professional.Cedula + ",'" + _professional.Name + "','" + _professional.FirstLastName + "','" +
                _professional.SecondLastName + "','" + _professional.PersonalPhone + "','" + _professional.RoomPhone + "','" + _professional.Birthday + "','" +
                _professional.Gender + "','" + _professional.CivilStatus + "'," + _professional.PlaceNumber + "," + _professional.Status + ",'" +
                 _professional.EmergencyContact + "'," + _professional.EmergencyContactNumber + ",'" + _professional.Scholarship + "','" +
               _professional.Specialty + "'," + _professional.SchoolCode + ",'" + _professional.Province + "','" + _professional.Canton + "','" + _professional.District + "','" +
                _professional.Address + "'," + _professional.Password;

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
            for (int i = 0; i < processQuantity; i++)
            {
                string sqlQueryProcess = $"exec sp_registrar_procesos_profesional  @cedula='{_professional.Cedula}',@proceso='{_professional.Process[i]}'";

                using (SqlCommand command = new SqlCommand(sqlQueryProcess, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteReader();
                    connection.Close();
                }
            }



        }

        /*
        Return a list of professionals  
        */
        public List<UserModels> SearchProfessional(UserModels _professional)
        {
            List<UserModels> professionales = new List<UserModels>();
            string sqlQuery = $"exec sp_buscar_profesional " + _professional.Cedula + ", '" + _professional.Name + "' , '" +
           _professional.SecondLastName + "' ;";
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader responseReader = command.ExecuteReader();
                while (responseReader.Read())
                {
                    UserModels professionalTemp = new UserModels();
                    professionalTemp.ProfessionalId = Int32.Parse(responseReader["consecutivo"].ToString());
                    professionalTemp.Cedula = Int32.Parse(responseReader["cedula"].ToString());
                    professionalTemp.Name = responseReader["nombre"].ToString();
                    professionalTemp.FirstLastName = responseReader["apellido"].ToString();

                    professionales.Add(professionalTemp);
                }
                connection.Close();
            }

            return professionales;

        }

        /*
        Return a professional acording to the identification
        */
        public List<UserModels> GetProfessionalByIdentification(UserModels _professional)
        {

            List<UserModels> professional = new List<UserModels>();



            string sqlQuery = $"exec sp_buscar_profesional_por_cedula('" + _professional.Cedula + "')";
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader catalogueReader = command.ExecuteReader();
                while (catalogueReader.Read())
                {
                    UserModels professionalTemp = new UserModels();
                    professionalTemp.Cedula = Int32.Parse(catalogueReader["pk_cedula_usuario"].ToString());
                    professionalTemp.Name = catalogueReader["tc_nombre"].ToString();
                    professionalTemp.FirstLastName = catalogueReader["tc_primer_apellido"].ToString();
                    professionalTemp.SecondLastName = catalogueReader["tc_segundo_apellido"].ToString();
                    professionalTemp.PersonalPhone = catalogueReader["tc_telefono_personal"].ToString();
                    professionalTemp.RoomPhone = catalogueReader["tc_telefono_habitacion"].ToString();
                    professionalTemp.Birthday = catalogueReader["tf_fecha_nacimiento"].ToString();
                    professionalTemp.Gender = Char.Parse(catalogueReader["tc_sexo"].ToString());
                    professionalTemp.CivilStatus = catalogueReader["tc_sexo"].ToString();
                    professionalTemp.PlaceNumber = Int32.Parse(catalogueReader["tn_numero_plaza"].ToString());
                    professionalTemp.Status = Int32.Parse(catalogueReader["tc_estado"].ToString());
                    professionalTemp.EmergencyContact = catalogueReader["tc_contacto_emergencia"].ToString();
                    professionalTemp.EmergencyContactNumber = Int32.Parse(catalogueReader["tn_contacto_emergencia"].ToString());
                    professionalTemp.Scholarship = catalogueReader["tc_escolaridad"].ToString();
                    professionalTemp.Specialty = catalogueReader["tc_especialidad"].ToString();
                    professionalTemp.SchoolCode = catalogueReader["tn_codigo_colegio"].ToString();
                    professionalTemp.Province = catalogueReader["tc_provincia"].ToString();
                    professionalTemp.Canton = catalogueReader["tc_canton"].ToString();
                    professionalTemp.District = catalogueReader["tc_distrito"].ToString();
                    professionalTemp.Address = catalogueReader["tc_direccion"].ToString();

                    professional.Add(professionalTemp);
                }
                connection.Close();
            }



            return professional;

        }

        /**
         Return a professional acording to the identification ID
         */
        public List<UserModels> GetProfessionalByIdentification(int id_professional)
        {

            List<UserModels> professional = new List<UserModels>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                string sqlQuery = $"exec sp_buscar_profesional_por_cedula " + id_professional;
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader catalogueReader = command.ExecuteReader();
                    while (catalogueReader.Read())
                    {
                        UserModels professionalTemp = new UserModels();
                        professionalTemp.Cedula = Int32.Parse(catalogueReader["pk_cedula_usuario"].ToString());
                        professionalTemp.Name = catalogueReader["tc_nombre"].ToString();
                        professionalTemp.FirstLastName = catalogueReader["tc_primer_apellido"].ToString();
                        professionalTemp.SecondLastName = catalogueReader["tc_segundo_apellido"].ToString();
                        professionalTemp.PersonalPhone = catalogueReader["tc_telefono_personal"].ToString();
                        professionalTemp.RoomPhone = catalogueReader["tc_telefono_habitacion"].ToString();
                        professionalTemp.Birthday = catalogueReader["tf_fecha_nacimiento"].ToString();
                        professionalTemp.Gender = Char.Parse(catalogueReader["tc_sexo"].ToString());
                        professionalTemp.CivilStatus = catalogueReader["tc_estado_civil"].ToString();
                        professionalTemp.PlaceNumber = Int32.Parse(catalogueReader["tn_numero_plaza"].ToString());
                        professionalTemp.Status = Int32.Parse(catalogueReader["tn_estado"].ToString());
                        professionalTemp.EmergencyContact = catalogueReader["tc_contacto_emergencia"].ToString();
                        professionalTemp.EmergencyContactNumber = Int32.Parse(catalogueReader["tn_contacto_emergencia"].ToString());
                        professionalTemp.Scholarship = catalogueReader["tc_escolaridad"].ToString();
                        professionalTemp.Specialty = catalogueReader["tc_especialidad"].ToString();
                        professionalTemp.SchoolCode = catalogueReader["tn_codigo_colegio"].ToString();
                        professionalTemp.Province = catalogueReader["tc_provincia"].ToString();
                        professionalTemp.Canton = catalogueReader["tc_canton"].ToString();
                        professionalTemp.District = catalogueReader["tc_distrito"].ToString();
                        professionalTemp.Address = catalogueReader["tc_direccion"].ToString();

                        professional.Add(professionalTemp);
                    }
                    connection.Close();
                }
            }
            return professional;

        }

        /*
        Modify a professional acording to the identification
       */
        public void ModifyProfessional(UserModels _professional)
        {
            int processQuantity = _professional.Process.Length;
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);

            string sqlQuery = $"exec sp_modificar_profesional " + _professional.Cedula + ",'" + _professional.Name + "','" + _professional.FirstLastName + "','" +
                _professional.SecondLastName + "','" + _professional.PersonalPhone + "','" + _professional.RoomPhone + "','" + _professional.Birthday + "','" +
                _professional.Gender + "','" + _professional.CivilStatus + "'," + _professional.PlaceNumber + "," + _professional.Status + ",'" +
                 _professional.EmergencyContact + "'," + _professional.EmergencyContactNumber + ",'" + _professional.Scholarship + "','" +
               _professional.Specialty + "'," + _professional.SchoolCode + ",'" + _professional.Province + "','" + _professional.Canton + "','" + _professional.District + "','" +
                _professional.Address + "'";
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }


            string sqlQueryDeleteProcess = $"exec sp_eliminar_procesos_profesional  @cedula='{_professional.Cedula}'";


            using (SqlCommand command = new SqlCommand(sqlQueryDeleteProcess, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }

            for (int i = 0; i < processQuantity; i++)
            {
                string sqlQueryProcess = $"exec sp_registrar_procesos_profesional  @cedula='{_professional.Cedula}',@proceso='{_professional.Process[i]}'";

                using (SqlCommand command = new SqlCommand(sqlQueryProcess, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteReader();
                    connection.Close();
                }
            }

        }


        /*
        Delete a professional acording to the identification
       */
        public void DeleteProfessional(int id_professional)
        {
            string sqlQuery = $"exec sp_eliminar_usuario_profesional " + id_professional;
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }

        /*
         Get a list of professional process
        */

        public List<CatalogueModels> GetListProcessProfessional(int id_professional)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);
            List<CatalogueModels> catalogueItems = new List<CatalogueModels>();

            string sqlQuery = $"exec sp_obtener_procesos_profesional @cedula='{id_professional}'";
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader catalogueReader = command.ExecuteReader();
                while (catalogueReader.Read())
                {
                    CatalogueModels catalogueTemp = new CatalogueModels();
                    catalogueTemp.ID = Int32.Parse(catalogueReader["pk_id_proceso"].ToString());
                    catalogueTemp.Name = catalogueReader["tc_nombre_proceso"].ToString();
                    catalogueItems.Add(catalogueTemp);
                }
                connection.Close();
            }


            return catalogueItems;
        }
        public List<CatalogueModels> GetProfessionalsByProcess(int id_process)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);
            List<CatalogueModels> catalogueItems = new List<CatalogueModels>();

            string sqlQuery = $"sp_obtener_profesional_por_proceso @proceso='{id_process}'";
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader catalogueReader = command.ExecuteReader();
                while (catalogueReader.Read())
                {
                    CatalogueModels catalogueTemp = new CatalogueModels();
                    catalogueTemp.ID = Int32.Parse(catalogueReader["pk_cedula_usuario"].ToString());
                    catalogueTemp.Name = catalogueReader["tc_nombre"].ToString();
                    catalogueItems.Add(catalogueTemp);
                }
                connection.Close();
            }


            return catalogueItems;
        }

        public String UserValidation(UserModels user)
        {
            string value = "0";
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);           
            string sqlQuery = $"exec sp_verify_user @cedula_usuario_ = {user.Cedula}, @contraseña_ = '{user.Password}'";
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader userReader = command.ExecuteReader();
                while (userReader.Read())
                {
                    value = userReader["value"].ToString();
                }
                connection.Close();
            }

            return value;
        }

        public String GetRol(UserModels user)
        {
            string rol = null;
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);
            string sqlQuery = $"exec sp_obtener_rol @cedula_usuario_ = {user.Cedula}";
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader userReader = command.ExecuteReader();
                while (userReader.Read())
                {
                    rol = userReader["rol"].ToString();
                }
                connection.Close();
            }

            return rol;
        }

        


    }
}