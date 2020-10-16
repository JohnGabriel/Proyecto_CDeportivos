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
    public class SedesBL: ConeccionDB
    {
        public List<SedeModel> ListarSedes()
        {
            List<SedeModel> sedes = new List<SedeModel>();

            using (ConnectionSQL = new SqlConnection(ConnectionDB))
            {
                using (CmdSQL = new SqlCommand("Usp_obtenerSedes", ConnectionSQL))
                {
                    CmdSQL.CommandType = CommandType.StoredProcedure;
                    CmdSQL.Connection.Open();
                    AdapterSQL = new SqlDataAdapter(CmdSQL);
                    TablesSQL = new DataTable();
                    AdapterSQL.Fill(TablesSQL);

                    ReaderSQL = CmdSQL.ExecuteReader();

                    while (ReaderSQL.Read())
                    {
                        SedeModel SedeData = new SedeModel
                        {
                            SedeID = (int)ReaderSQL["Sede ID"], 
                            NombreSede = ReaderSQL["Sede"].ToString(),
                            NumeroComplejos=(int)ReaderSQL["Complejos"],
                            Presupuesto= (decimal)ReaderSQL["Presupuesto"]

                            
                        };

                        sedes.Add(SedeData);
                    }
                }
            }

            return sedes;
        }
        public int RegistrarSede(SedeModel sedeModel)
        {
            int Result = -1;

            using (ConnectionSQL = new SqlConnection(ConnectionDB))
            {
                using (CmdSQL = new SqlCommand("Usp_AgregaSede", ConnectionSQL))
                {
                    CmdSQL.CommandType = CommandType.StoredProcedure;
                    CmdSQL.Parameters.Add("@NombreSede", SqlDbType.NVarChar, 20).Value = sedeModel.NombreSede;
                    CmdSQL.Parameters.Add("@NroComplejos", SqlDbType.Int).Value = sedeModel.NumeroComplejos;
                    CmdSQL.Parameters.Add("@Presupuesto", SqlDbType.Decimal).Value = sedeModel.Presupuesto;
                    CmdSQL.Connection.Open();

                    Result = CmdSQL.ExecuteNonQuery();
                }
            }

            return Result;
        }
        public int EditarSede(SedeModel sedeModel)
        {
            int Result = -1;

            using (ConnectionSQL = new SqlConnection(ConnectionDB))
            {
                using (CmdSQL = new SqlCommand("Usp_ActualizaSede", ConnectionSQL))
                {
                    CmdSQL.CommandType = CommandType.StoredProcedure;
                    CmdSQL.Parameters.Add("@Id", SqlDbType.Int).Value = sedeModel.SedeID;
                    CmdSQL.Parameters.Add("@NombreSede", SqlDbType.NVarChar, 50).Value = sedeModel.NombreSede;
                    CmdSQL.Parameters.Add("@NumeroComplejos", SqlDbType.Int).Value = sedeModel.NumeroComplejos;
                    CmdSQL.Parameters.Add("@Presupuesto", SqlDbType.Decimal).Value = sedeModel.Presupuesto;

                    
                    CmdSQL.Connection.Open();

                    Result = CmdSQL.ExecuteNonQuery();
                }
            }

            return Result;
        }
        public int DeleteSede(int id)
        {
            int Result = -1;

            using (ConnectionSQL = new SqlConnection(ConnectionDB))
            {
                using (CmdSQL = new SqlCommand("Usp_EliminarSede", ConnectionSQL))
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