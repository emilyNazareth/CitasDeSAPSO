using CitasSAPSO.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


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
                    appointment.FunctionaryId = Int32.Parse(responseReader["fk_id_funcionario"].ToString());
                    appointment.Date = DateTime.Parse(responseReader["tf_fecha"].ToString());
                    appointment.Hour = responseReader["tc_hora"].ToString();
                    appointment.ProfessionalId = Int32.Parse(responseReader["fk_id_profesional"].ToString());
                    appointment.Patient = responseReader["tc_paciente"].ToString();
                    appointment.State = responseReader["tc_estado"].ToString();
                    appointment.SubprocessId = responseReader["fk_id_subproceso"].ToString();
                    appointment.SubActivityId = responseReader["fk_id_subactividad"].ToString();
                    appointment.Assistance = responseReader["fk_id_asistencia"].ToString();
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
                    appointment.FunctionaryId = Int32.Parse(responseReader["fk_id_funcionario"].ToString());
                    appointment.Date = DateTime.Parse(responseReader["tf_fecha"].ToString());
                    appointment.Hour = responseReader["tc_hora"].ToString();
                    appointment.ProfessionalId = Int32.Parse(responseReader["fk_id_profesional"].ToString());
                    appointment.Patient = responseReader["tc_paciente"].ToString();
                    appointment.State = responseReader["tc_estado"].ToString();
                    appointment.SubprocessId = responseReader["fk_id_subproceso"].ToString();
                    appointment.SubActivityId = responseReader["fk_id_subactividad"].ToString();
                    appointment.Assistance = responseReader["fk_id_asistencia"].ToString();
                } // while
                connection.Close();
            }

            return appointment;
        }

        //get all appointment for admin search
        public List<AppointmentModels> GetAppointmentList()
        {
            List<AppointmentModels> appointments = new List<AppointmentModels>();
            string sqlQuery = $"exec sp_obtener_citas()";

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
                    appointment.FunctionaryId = Int32.Parse(responseReader["fk_id_funcionario"].ToString());
                    appointment.Date = DateTime.Parse(responseReader["tf_fecha"].ToString());
                    appointment.Hour = responseReader["tc_hora"].ToString();
                    appointment.ProfessionalId = Int32.Parse(responseReader["fk_id_profesional"].ToString());
                    appointment.Patient = responseReader["tc_paciente"].ToString();
                    appointment.State = responseReader["tc_estado"].ToString();
                    appointment.SubprocessId = responseReader["fk_id_subproceso"].ToString();
                    appointment.SubActivityId = responseReader["fk_id_subactividad"].ToString();
                    appointment.Assistance = responseReader["fk_id_asistencia"].ToString();

                    appointments.Add(appointment);
                } // while
                connection.Close();
            }

            return appointments;
        }


        //add new appointment
        public void SaveAppointment(AppointmentModels _appointment)
        {
            string sqlQuery = $"exec sp_registrar_cita " + _appointment.FunctionaryId + ",'" + _appointment.Date + "','"
                + _appointment.Hour + "'," + _appointment.ProfessionalId + ",'" + _appointment.Patient + "','"
                + _appointment.State + "'," + _appointment.SubprocessId + "," + _appointment.Assistance + ","
                + _appointment.SubActivityId;
            Console.WriteLine("CONSLTA BASE DATOS:"+sqlQuery);
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
            string sqlQuery = $"exec sp_guardar_cita_ (" + _appointment.FunctionaryId + ",'" + _appointment.Date + "','"
                + _appointment.Hour + "'," + _appointment.ProfessionalId + ",'" + _appointment.Patient + "','"
                + _appointment.State + "'," + _appointment.SubprocessId + "," + _appointment.Assistance + "',"
                + _appointment.SubActivityId + ")";

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
                    appointment.Functionary.Cedula = Int32.Parse(responseReader["fk_id_funcionario"].ToString());
                    appointment.Functionary.Cedula = Int32.Parse(responseReader[""].ToString());
                    appointment.Date = responseReader["tf_fecha"].ToString();
                    appointment.Hour = responseReader["tc_hora"].ToString();
                    appointment.Professional.Cedula = Int32.Parse(responseReader["fk_id_profesional"].ToString());                    
                    appointment.Professional.Cedula = Int32.Parse(responseReader["nombre_profesional"].ToString());                    
                    appointments.Add(appointment);
                } 

                connection.Close();
            }

            return appointments;
        }

    }
}