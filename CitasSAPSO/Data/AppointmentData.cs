using CitasSAPSO.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CitasSAPSO.Data
{
    public class AppointmentData
    {
        private SqlConnection connection;
        public AppointmentData()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);
        }

        //search appointment by id for view specific details
        public AppointmentModels GetAppointmentById(int _idAppointment)
        {

            AppointmentModels appointment = new AppointmentModels();
            string sqlQuery = $"exec sp_buscar_cita_por_id ('" + _idAppointment + "')";

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                command.CommandText = sqlQuery;
                connection.Open();
                SqlDataReader responseReader = command.ExecuteReader();
                while (responseReader.Read())
                {
                    appointment.Id = Int32.Parse(responseReader["pk_id_cita"].ToString());
                    appointment.Functionary.Cedula = Int32.Parse(responseReader["fk_id_funcionario"].ToString());
                    appointment.Date = responseReader["tf_fecha"].ToString();
                    appointment.Hour = responseReader["tc_hora"].ToString();
                    appointment.Professional.Cedula = Int32.Parse(responseReader["fk_id_profesional"].ToString());
                    appointment.Patient = responseReader["tc_paciente"].ToString();
                    appointment.State = responseReader["tc_estado"].ToString();
                    appointment.SubProcess.ID = Int32.Parse(responseReader["fk_id_subproceso"].ToString());
                    appointment.SubActivity.ID = Int32.Parse(responseReader["fk_id_subactividad"].ToString());
                    appointment.Assistance.ID = Int32.Parse(responseReader["fk_id_asistencia"].ToString());
                } 
                connection.Close();
            }

            return appointment;
        }

        //search appointment by some filter for professional calendar
        public AppointmentModels GetAppointmentsByFilters(DateTime _initDate, DateTime _endDate, int _idProcess,
            string _assistence, int _office, int _userCedula, char _gender, string _state, int _idAppointment, int _yearsOld)
        {

            AppointmentModels appointment = new AppointmentModels();
            string sqlQuery = $"exec sp_buscar_cita_por_filtro ('" + _initDate + "','" + _endDate + "','" + _idProcess + "','" + _assistence
                + "','" + _office + "','" + _userCedula + "','" + _gender + "','" + _state + "','" + _idAppointment + "','" + _yearsOld + "')";

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                command.CommandText = sqlQuery;
                connection.Open();
                SqlDataReader responseReader = command.ExecuteReader();
                while (responseReader.Read())
                {
                    appointment.Id = Int32.Parse(responseReader["pk_id_cita"].ToString());
                    appointment.Functionary.Cedula = Int32.Parse(responseReader["fk_id_funcionario"].ToString());
                    appointment.Date = responseReader["tf_fecha"].ToString();
                    appointment.Hour = responseReader["tc_hora"].ToString();
                    appointment.Professional.Cedula = Int32.Parse(responseReader["fk_id_profesional"].ToString());
                    appointment.Patient = responseReader["tc_paciente"].ToString();
                    appointment.State = responseReader["tc_estado"].ToString();
                    appointment.SubProcess.ID = Int32.Parse(responseReader["fk_id_subproceso"].ToString());
                    appointment.SubActivity.ID = Int32.Parse(responseReader["fk_id_subactividad"].ToString());
                    appointment.Assistance.ID = Int32.Parse(responseReader["fk_id_asistencia"].ToString());
                } // while
                connection.Close();
            }

            return appointment;
        }

        //get all appointment for admin search
        public List<AppointmentModels> GetAppointmentList()
        {
            List<AppointmentModels> appointments = new List<AppointmentModels>();
            string sqlQuery = $"exec sp_obtener_citas";

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                command.CommandText = sqlQuery;
                connection.Open();
                SqlDataReader responseReader = command.ExecuteReader();
                while (responseReader.Read())
                {
                    AppointmentModels appointment = new AppointmentModels();
                    appointment.Id = Int32.Parse(responseReader["pk_id_cita"].ToString());
                    appointment.Functionary.Cedula = Int32.Parse(responseReader["pk_cedula_usuario"].ToString());
                    appointment.Date = responseReader["tf_fecha"].ToString();
                    appointment.Hour = responseReader["tc_hora"].ToString();
                    appointment.Professional.Cedula = Int32.Parse(responseReader["fk_id_profesional"].ToString());
                    //appointment.Patient = responseReader["tc_paciente"].ToString();
                    //appointment.State = responseReader["tc_estado"].ToString();
                    //appointment.SubProcess.ID = Int32.Parse(responseReader["fk_id_subproceso"].ToString());
                    //appointment.SubActivity.ID = Int32.Parse(responseReader["fk_id_subactividad"].ToString());
                    //appointment.Assistance.ID = Int32.Parse(responseReader["fk_id_asistencia"].ToString());

                    appointments.Add(appointment);
                } // while
                connection.Close();
            }

            return appointments;
        }


        //add new appointment
        public void SaveAppointment(AppointmentModels _appointment)
        {
            string sqlQuery = $"exec sp_registrar_cita " + _appointment.Functionary.Cedula + ",'" + _appointment.Date + "','"
                + _appointment.Hour + "'," + _appointment.Professional.Cedula + ",'" + _appointment.Patient + "','"
                + _appointment.State + "'," + _appointment.SubProcess.ID + "," + _appointment.Assistance.ID + ","
                + _appointment.SubActivity.ID;
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }

        }
        public void UpdateAppointment(AppointmentModels _appointment)
        {
            string sqlQuery = $"exec sp_guardar_cita_ (" + _appointment.Functionary.Cedula + ",'" + _appointment.Date + "','"
                + _appointment.Hour + "'," + _appointment.Professional.Cedula + ",'" + _appointment.Patient + "','"
                + _appointment.State + "'," + _appointment.SubProcess.ID + "," + _appointment.Assistance + "',"
                + _appointment.SubActivity.ID + ")";

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                command.CommandText = sqlQuery;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }

        }

        public List<AppointmentModels> SearchAppointmentsForFunctionary( AppointmentModels _appointment)
        {

            string sqlQuery = $"exec sp_buscar_cita_para_funcionario "  +_appointment.Functionary.Cedula + ","+_appointment.Id+" ;";
            List<AppointmentModels> appointments = new List<AppointmentModels>();

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                command.CommandText = sqlQuery;
                connection.Open();
                SqlDataReader responseReader = command.ExecuteReader();
                
                while (responseReader.Read())
                {
                    AppointmentModels appointment = new AppointmentModels();
                    appointment.Id = Int32.Parse(responseReader["pk_id_cita"].ToString());
                    appointment.Functionary.Cedula = Int32.Parse(responseReader["pk_cedula_usuario"].ToString());
                    appointment.Functionary.Name = responseReader["tc_nombre"].ToString();
                    appointment.Functionary.FirstLastName = responseReader["tc_primer_apellido"].ToString();
                    appointment.Functionary.SecondLastName = responseReader["tc_segundo_apellido"].ToString();
                    appointment.Professional.Cedula = Int32.Parse(responseReader["fk_id_profesional"].ToString());                    
                    appointment.Professional.Name = responseReader["nombre_profesional"].ToString();
                    appointment.SubProcess.Name = responseReader["tc_nombre_subproceso"].ToString();
                    appointment.SubActivity.Name = responseReader["tc_nombre_subactividad"].ToString();
                    appointment.Date = responseReader["tf_fecha"].ToString();
                    appointment.Hour = responseReader["tc_hora"].ToString();

                    appointments.Add(appointment);
                } 

                connection.Close();
            }

            return appointments;
        }

        //GET LIST APPOINTMENT BY FILTERS ADMI
        public List<AppointmentModels> SearchAppointmentByFiltersAdministrator(AppointmentModels _appointment, String initialDate,
            String finalDate, int process, String appointmentStatus, int age, int professional)
        {

            string sqlQuery = $"exec sp_buscar_cita_para_funcionario_admi " + _appointment.Functionary.Cedula + "," + _appointment.Id + ",'" + initialDate + "','" +
              finalDate + "'," + process + "," + _appointment.Functionary.OfficeID + ", " + professional + ", '" + appointmentStatus + "'," + _appointment.Functionary.Assistance +
              ", '" + _appointment.Functionary.Gender + "', " + age + " ;";
            List<AppointmentModels> appointments = new List<AppointmentModels>();

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                command.CommandText = sqlQuery;
                connection.Open();
                SqlDataReader responseReader = command.ExecuteReader();
                
                while (responseReader.Read())
                {
                    AppointmentModels appointment = new AppointmentModels();
                    appointment.Id = Int32.Parse(responseReader["pk_id_cita"].ToString());
                    appointment.Functionary.Cedula = Int32.Parse(responseReader["pk_cedula_usuario"].ToString());
                    appointment.Functionary.Name = responseReader["tc_nombre"].ToString();
                    appointment.Functionary.FirstLastName = responseReader["tc_primer_apellido"].ToString();
                    appointment.Functionary.SecondLastName = responseReader["tc_segundo_apellido"].ToString();
                    appointment.Date = responseReader["tf_fecha"].ToString();
                    appointment.Hour = responseReader["tc_hora"].ToString();
                    appointment.Professional.Cedula = Int32.Parse(responseReader["fk_id_profesional"].ToString());
                    appointment.SubProcess.Name = responseReader["tc_nombre_proceso"].ToString();
                    appointment.SubActivity.Name = responseReader["tc_nombre_actividad"].ToString();
                    appointments.Add(appointment);
                }

                connection.Close();
            }

            return appointments;
        }

        public List<AppointmentModels> getAppointmentDetail(AppointmentModels _appointment)
        {

            string sqlQuery = $"exec sp_obtener_cita_funcionario " + _appointment.Functionary.Cedula + "," + _appointment.Id + " ;";

            List<AppointmentModels> appointments = new List<AppointmentModels>();

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                command.CommandText = sqlQuery;
                connection.Open();
                SqlDataReader responseReader = command.ExecuteReader();

                while (responseReader.Read())
                {
                    AppointmentModels appointment = new AppointmentModels();
                    appointment.Id = Int32.Parse(responseReader["pk_id_cita"].ToString());
                    appointment.Functionary.Cedula = Int32.Parse(responseReader["pk_cedula_usuario"].ToString());
                    appointment.Functionary.Name = responseReader["tc_nombre"].ToString();
                    appointment.Functionary.FirstLastName = responseReader["tc_primer_apellido"].ToString();
                    appointment.Functionary.SecondLastName = responseReader["tc_segundo_apellido"].ToString();
                    appointment.Date = responseReader["tf_fecha"].ToString();
                    appointment.Hour = responseReader["tc_hora"].ToString();
                    //appointment.Professional.Cedula = Int32.Parse(responseReader["fk_id_profesional"].ToString());
                   // appointment.SubProcess.Name = responseReader["tc_nombre_proceso"].ToString();
                    //appointment.SubActivity.Name = responseReader["tc_nombre_actividad"].ToString();
                    appointment.Functionary.Gender = Char.Parse(responseReader["tc_sexo"].ToString());
                    appointment.Functionary.NamePlace = responseReader["tc_nombre_puesto"].ToString();
                    appointment.Functionary.NameArea = responseReader["tc_nombre_area"].ToString();
                    appointment.Functionary.NameOffice = responseReader["tc_nombre_oficina"].ToString();
                    appointment.Functionary.PersonalPhone = responseReader["tc_telefono_personal"].ToString();
                    appointment.Functionary.Mail = responseReader["tc_correo_electronico"].ToString();
                    appointment.Date = responseReader["tf_fecha"].ToString();
                    appointment.Hour = responseReader["tc_hora"].ToString();
                    appointment.Professional.Name = responseReader["profesional"].ToString();
                    appointment.State = responseReader["tc_estado"].ToString();

                    appointments.Add(appointment);
                }

                connection.Close();
            }


            return appointments;
        }

        //GET LIST APPOINTMENT
        public List<AppointmentModels> GetAppointmentsByFilter()
        {

            string sqlQuery = $"exec sp_obtener_citas";
            List<AppointmentModels> appointments = new List<AppointmentModels>();

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                command.CommandText = sqlQuery;
                connection.Open();
                SqlDataReader responseReader = command.ExecuteReader();

                while (responseReader.Read())
                {
                    AppointmentModels appointment = new AppointmentModels();
                    appointment.Id = Int32.Parse(responseReader["pk_id_cita"].ToString());
                    appointment.Functionary.Cedula = Int32.Parse(responseReader["pk_cedula_usuario"].ToString());
                    appointment.Functionary.Name = responseReader["tc_nombre"].ToString();
                    appointment.Functionary.FirstLastName = responseReader["tc_primer_apellido"].ToString();
                    appointment.Functionary.SecondLastName = responseReader["tc_segundo_apellido"].ToString();
                    appointment.Date = responseReader["tf_fecha"].ToString();
                    appointment.Hour = responseReader["tc_hora"].ToString();
                    appointment.Professional.Cedula = Int32.Parse(responseReader["fk_id_profesional"].ToString());
                    appointment.SubProcess.Name = responseReader["tc_nombre_proceso"].ToString();
                    appointment.SubActivity.Name = responseReader["tc_nombre_actividad"].ToString();
                    appointments.Add(appointment);
                }

                connection.Close();
            }

            return appointments;

        }


        public void DeleteAppointment(AppointmentModels appointment)
        {
            string sqlQuery = $"exec sp_eliminar_cita "+appointment.Id+",'"+appointment.Justification+"';";

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                command.CommandType = CommandType.Text;

                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }

        }

        public List<AppointmentModels> SearchAppointmentsForProfesional(AppointmentModels _appointment, string initialDate, string finalDate, int age)
        {
            string sqlQuery = $"exec sp_buscar_cita_para_funcionario_admi " + _appointment.Functionary.Cedula + "," + _appointment.Id + ",'" + initialDate + "','" +
                  finalDate + "'," + _appointment.SubProcess.ID + "," + _appointment.Functionary.OfficeID + ", " + _appointment.Professional.ProfessionalId+ ", '" + _appointment.State + "'," + _appointment.Functionary.Assistance +
                  ", '" + _appointment.Functionary.Gender + "', " + age + " ;";
            List<AppointmentModels> appointments = new List<AppointmentModels>();

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                command.CommandText = sqlQuery;
                connection.Open();
                SqlDataReader responseReader = command.ExecuteReader();

                while (responseReader.Read())
                {
                    AppointmentModels appointment = new AppointmentModels();
                    appointment.Id = Int32.Parse(responseReader["pk_id_cita"].ToString());
                    appointment.Functionary.Cedula = Int32.Parse(responseReader["pk_cedula_usuario"].ToString());
                    appointment.Functionary.Name = responseReader["tc_nombre"].ToString();
                    appointment.Functionary.FirstLastName = responseReader["tc_primer_apellido"].ToString();
                    appointment.Functionary.SecondLastName = responseReader["tc_segundo_apellido"].ToString();
                    appointment.Date = responseReader["tf_fecha"].ToString();
                    appointment.Hour = responseReader["tc_hora"].ToString();
                    appointment.Professional.Cedula = Int32.Parse(responseReader["fk_id_profesional"].ToString());
                    appointment.SubProcess.Name = responseReader["tc_nombre_proceso"].ToString();
                    appointment.SubActivity.Name = responseReader["tc_nombre_actividad"].ToString();
                    appointments.Add(appointment);
                }

                connection.Close();
            }

            return appointments;
        }
    }

}
