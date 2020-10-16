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
    public class LoginBL: ConeccionDB
    {
        public int ValidaUsuario(UsuarioModel usuarioModel)
        {
            int Result = -1;

            using (ConnectionSQL = new SqlConnection(ConnectionDB))
            {
                using (CmdSQL = new SqlCommand("Usp_ValidaUsuario", ConnectionSQL))
                {
                    CmdSQL.CommandType = CommandType.StoredProcedure;
                    CmdSQL.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = usuarioModel.Usuario;
                    CmdSQL.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = usuarioModel.Password;
                    
                    CmdSQL.Connection.Open();

                    Result = Convert.ToInt32(CmdSQL.ExecuteScalar());
                }
            }

            return Result;
        }

    }
}