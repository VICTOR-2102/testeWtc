

using Microsoft.Data.SqlClient;

namespace WebPageWtcClub.ContextDataBase;

public class WtcContext
{
    const string connectionString = "network address=177.46.153.78,1433; password=blis@2222; user id=sa; database=wtc_prod_on_ed";
    public WtcContext()
    {
        
    }

    public string ConsultarLoginCliente(string email, string password)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string passwordForUrl = string.Empty;

                string query = $"SELECT * FROM contact where email = '{email}'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var senhaRelacionada = reader["socio_numero_text"];

                            var senhaSalvaBanco = senhaRelacionada.ToString();

                            if (senhaSalvaBanco != password)
                                throw new Exception("Senha incorreta.");

                            passwordForUrl = senhaSalvaBanco;
                        }
                    }
                } 
                connection.Close();
                
                return passwordForUrl;

            }
        }
        catch(Exception ex)
        {
            throw;
        }
    }
}
