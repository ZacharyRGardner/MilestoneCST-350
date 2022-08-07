using MilestoneCST_350.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneCST_350.Services
{
    public class SecurityDAO
    {
        string connectionString = @"Server=tcp:minesweeper-sql-server.database.windows.net,1433;Initial Catalog=userDB;Persist Security Info=False;User ID=madmin;Password=Minesweeper-350;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public bool FindUserByNameAndPassword(LoginModel login)
        {
            // if nothing is found
            bool success = false;

            // uses prepared statements for security @username @password are defined below
            string sqlStatement = "SELECT * FROM dbo.Users WHERE username = @username and password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // define the values of the two placeholders in the sqlStatement string
                command.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar, 50).Value = login.username;
                command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.VarChar, 50).Value = login.password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                        success = true;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                };
            }
            return success;
        }
    }
}
