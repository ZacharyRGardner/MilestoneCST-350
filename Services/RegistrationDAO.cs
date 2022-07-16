using MilestoneCST_350.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneCST_350.Services
{
    public class RegistrationDAO
    {

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Minesweeper;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool RegisterUser(UserModel user)
        {
            bool success = false;
            // uses prepared statements for security @username @password are defined below
            string sqlQuery = "SELECT * FROM dbo.Users WHERE username = @username and password = @password"; 
            string sqlStatement = "INSERT INTO dbo.Users(username, password)VALUES (@username, @password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand queryCommand = new SqlCommand(sqlQuery, connection);

                queryCommand.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar, 50).Value = user.username;
                queryCommand.Parameters.Add("@PASSWORD", System.Data.SqlDbType.VarChar, 50).Value = user.password;

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // define the values of the two placeholders in the sqlStatement string
                command.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar, 50).Value = user.username;
                command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.VarChar, 50).Value = user.password;
                try
                {
                    connection.Open();
                    SqlDataReader reader = queryCommand.ExecuteReader();
                    if (reader.HasRows != true)
                    {
                        success = true;
                        reader.Close();
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        command.Cancel();
                        success = false;
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
                return success;
            }
        }
    }
}
