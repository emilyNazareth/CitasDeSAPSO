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
    public class CatalogueData
    {
        private SqlConnection connection;

        public CatalogueData()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);
        }


        /*
         Get a list of a specific table that is part of the catalog 
        */

        public List<CatalogueModels> GetListCatalogue(CatalogueModels _catalogue)
        {
            List<CatalogueModels> catalogueItems = new List<CatalogueModels>();
            string sqlQuery = $"exec sp_obtener_" + _catalogue.Table;
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader catalogueReader = command.ExecuteReader();
                while (catalogueReader.Read())
                {
                    CatalogueModels catalogueTemp = new CatalogueModels();
                    catalogueTemp.ID = Int32.Parse(catalogueReader["pk_id_" + _catalogue.Table].ToString());
                    catalogueTemp.Name = catalogueReader["tc_nombre_" + _catalogue.Table].ToString();
                    if (_catalogue.Table.Equals("subactividad"))
                    {
                        catalogueTemp.FatherID = Int32.Parse(catalogueReader[2].ToString());
                    }
                    if (_catalogue.Table.Equals("subproceso"))
                    {
                        catalogueTemp.FatherID = Int32.Parse(catalogueReader[2].ToString());
                    }


                    catalogueItems.Add(catalogueTemp);
                }
                connection.Close();
            }

            return catalogueItems;
        }




        /*
        Register catalogue items for a specific table 
       */

        public void RegisterCatalogueItems(CatalogueModels _catalogue)
        {
            string sqlQuery = $"exec sp_registrar_" + _catalogue.Table + " '" + _catalogue.Name + "';";
            if (_catalogue.FatherID != 0)
            {
                sqlQuery = $"exec sp_registrar_" + _catalogue.Table + " '" + _catalogue.Name + "' , " + _catalogue.FatherID + ";";
            }

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }

        }
        /*
              Modify catalogue items for a specific table 
        */
        public void ModifyCatalogueItems(CatalogueModels _catalogue)
        {
            string sqlQuery = $"exec sp_modificar_" + _catalogue.Table + " " + _catalogue.ID + " , '" + _catalogue.Name + "';";

            if (_catalogue.FatherID != 0)
            {
                sqlQuery = $"exec sp_modificar_" + _catalogue.Table + " " + _catalogue.ID + " , '" + _catalogue.Name + "' , '" + _catalogue.FatherID + "';";
            }

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }

        /*
            Delete  catalogue items for a specific table 
        */

        public void DeleteCatalogueItems(CatalogueModels _catalogue)
        {
            string sqlQuery = $"exec sp_eliminar_" + _catalogue.Table + " " + _catalogue.ID + " ;";

            if (_catalogue.FatherID != 0)
            {
                sqlQuery = $"exec sp_eliminar_" + _catalogue.Table + " " + _catalogue.ID + "' , '" + _catalogue.FatherID + "' ;";
            }

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into prueba values(11,'Luis')";
                cmd.Connection = connection;

                command.CommandType = CommandType.Text;

                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
        }
        public List<CatalogueModels> GetCatalogueFunctionary(string _catalogue)
        {
            List<CatalogueModels> catalogues = new List<CatalogueModels>();


            string sqlQuery = $"exec sp_obtener_"+_catalogue;
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader responseReader = command.ExecuteReader();
                while (responseReader.Read())
                {
                    CatalogueModels resultCatalogue = new CatalogueModels();
                    resultCatalogue.ID = Int32.Parse(responseReader["pk_id_"+_catalogue].ToString());
                    resultCatalogue.Name = responseReader["tc_nombre_"+_catalogue].ToString();
                    catalogues.Add(resultCatalogue);
                } 
                connection.Close();
            }


            return catalogues;
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

        public List<CatalogueModels> GetSubprocessListByProcess(int processId)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);
            List<CatalogueModels> catalogueItems = new List<CatalogueModels>();

            string sqlQuery = $"exec sp_obtener_subprocesos_de_proceso @proceso={processId}";
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader catalogueReader = command.ExecuteReader();
                while (catalogueReader.Read())
                {
                    CatalogueModels catalogueTemp = new CatalogueModels();
                    catalogueTemp.ID = Int32.Parse(catalogueReader["pk_id_subproceso"].ToString());
                    catalogueTemp.Name = catalogueReader["tc_nombre_subproceso"].ToString();
                    catalogueItems.Add(catalogueTemp);
                }
                connection.Close();
            }

            return catalogueItems;
        }

        public int[] GetAppointmensQuantityFirstSemester()
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString);
            int[] appointmentList = new int[6];

            string sqlQuery = $"exec sp_obtener_cantidad_citas_segundo_semestre";
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    appointmentList[0] = Int32.Parse(reader["julio"].ToString());
                    appointmentList[1] = Int32.Parse(reader["agosto"].ToString());
                    appointmentList[2] = Int32.Parse(reader["setiembre"].ToString());
                    appointmentList[3] = Int32.Parse(reader["octubre"].ToString());
                    appointmentList[4] = Int32.Parse(reader["noviembre"].ToString());
                    appointmentList[5] = Int32.Parse(reader["diciembre"].ToString());
                }
                connection.Close();
            }

            return appointmentList;
        }
    }

}


