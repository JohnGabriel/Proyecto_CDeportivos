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
    public class TipoComplejoBL: ConeccionDB
    {
        public List<TipoComplejoModel> ListarTComplejo()
        {
            List<TipoComplejoModel> tiposCompl = new List<TipoComplejoModel>();

            using (ConnectionSQL = new SqlConnection(ConnectionDB))
            {
                using (CmdSQL = new SqlCommand("Usp_obtenerTipoComplejos", ConnectionSQL))
                {
                    CmdSQL.CommandType = CommandType.StoredProcedure;
                    CmdSQL.Connection.Open();
                    AdapterSQL = new SqlDataAdapter(CmdSQL);
                    TablesSQL = new DataTable();
                    AdapterSQL.Fill(TablesSQL);

                    ReaderSQL = CmdSQL.ExecuteReader();

                    while (ReaderSQL.Read())
                    {
                        TipoComplejoModel tipoc = new TipoComplejoModel
                        {
                            TipoID= (int)ReaderSQL["Tipo Id"],
                            NombreTipo = ReaderSQL["Tipo Complejo"].ToString()
                        };

                        tiposCompl.Add(tipoc);
                    }
                }
            }

            return tiposCompl;
        }
    }
}