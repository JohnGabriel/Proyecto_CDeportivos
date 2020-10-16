using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppCDeportivos.Repository
{
    public class ConeccionDB
    {
        private static string ConnectionString;

        protected SqlConnection ConnectionSQL;
        protected SqlCommand CmdSQL;
        protected SqlDataReader ReaderSQL;
        protected SqlDataAdapter AdapterSQL;
        protected DataTable TablesSQL;

        public static string ConnectionDB
        {
            get
            {
                if (ConnectionString == null || ConnectionString == string.Empty)
                {
                    ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
                }

                return ConnectionString;
            }
        }
    }
}