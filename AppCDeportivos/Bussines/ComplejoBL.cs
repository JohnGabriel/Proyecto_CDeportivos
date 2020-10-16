using AppCDeportivos.Models;
using AppCDeportivos.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppCDeportivos.Bussines
{
    public class ComplejoBL : ConeccionDB
    {
        public List<ComplejoModel> ListarComplejos()
        {
            List<ComplejoModel> complejos = new List<ComplejoModel>();

            using (ConnectionSQL = new SqlConnection(ConnectionDB))
            {
                using (CmdSQL = new SqlCommand("Usp_obtenerComplejos", ConnectionSQL))
                {
                    CmdSQL.CommandType = CommandType.StoredProcedure;
                    CmdSQL.Connection.Open();
                    AdapterSQL = new SqlDataAdapter(CmdSQL);
                    TablesSQL = new DataTable();
                    AdapterSQL.Fill(TablesSQL);

                    ReaderSQL = CmdSQL.ExecuteReader();

                    while (ReaderSQL.Read())
                    {
                        ComplejoModel complejoData = new ComplejoModel
                        {
                            ComplejoID= (int)ReaderSQL["Complejo ID"],
                            NombreComplejo = ReaderSQL["Complejo"].ToString(),
                            NombreTipo= ReaderSQL["Tipo Complejo"].ToString(),
                            NombreSede= ReaderSQL["Sede"].ToString(),
                            Localizacion=ReaderSQL["Localizacion"].ToString(),
                            AreaTotal= (int)ReaderSQL["Area Total"]

                        };

                        complejos.Add(complejoData);
                    }
                }
            }

            return complejos;
        }
        public int RegistrarComplejo(ComplejoModel complejoModel)
        {
            int Result = -1;

            using (ConnectionSQL = new SqlConnection(ConnectionDB))
            {
                using (CmdSQL = new SqlCommand("Usp_AgregaComplejo", ConnectionSQL))
                {
                    CmdSQL.CommandType = CommandType.StoredProcedure;
                    CmdSQL.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = complejoModel.NombreComplejo;
                    CmdSQL.Parameters.Add("@TipoComplejoID", SqlDbType.Int).Value = complejoModel.TipoComplejoID;
                    CmdSQL.Parameters.Add("@SedeID", SqlDbType.Int).Value = complejoModel.SedeID;
                    CmdSQL.Parameters.Add("@Localizacion", SqlDbType.NVarChar, 50).Value = complejoModel.Localizacion;
                    CmdSQL.Parameters.Add("@AreaTotal", SqlDbType.Int).Value = complejoModel.AreaTotal;
                    CmdSQL.Connection.Open();

                    Result = CmdSQL.ExecuteNonQuery();
                }
            }

            return Result;
        }
        public int EditarComplejo(ComplejoModel complejoModel)
        {
            int Result = -1;

            using (ConnectionSQL = new SqlConnection(ConnectionDB))
            {
                using (CmdSQL = new SqlCommand("Usp_ActualizaComplejo", ConnectionSQL))
                {
                    CmdSQL.CommandType = CommandType.StoredProcedure;
                    CmdSQL.Parameters.Add("@ComplejoID", SqlDbType.Int).Value = complejoModel.ComplejoID;
                    CmdSQL.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50).Value = complejoModel.NombreComplejo;
                    CmdSQL.Parameters.Add("@TipoComplejoID", SqlDbType.Decimal).Value = complejoModel.TipoComplejoID;
                    CmdSQL.Parameters.Add("@SedeID", SqlDbType.Decimal).Value = complejoModel.SedeID;
                    CmdSQL.Parameters.Add("@Localizacion", SqlDbType.NVarChar, 50).Value = complejoModel.Localizacion;
                    CmdSQL.Parameters.Add("@AreaTotal", SqlDbType.Int).Value = complejoModel.AreaTotal;


                    CmdSQL.Connection.Open();

                    Result = CmdSQL.ExecuteNonQuery();
                }
            }

            return Result;
        }
        public int DeleteComplejo(int id)
        {
            int Result = -1;

            using (ConnectionSQL = new SqlConnection(ConnectionDB))
            {
                using (CmdSQL = new SqlCommand("Usp_EliminarComplejo", ConnectionSQL))
                {
                    CmdSQL.CommandType = CommandType.StoredProcedure;
                    CmdSQL.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    CmdSQL.Connection.Open();

                    Result = CmdSQL.ExecuteNonQuery();
                }
            }

            return Result;
        }
    }
}