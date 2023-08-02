using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ToDoRepository
    {
        private IConfiguration _configuration;

        private string ConnectionString;

        public ToDoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("MSSQLDB") ?? string.Empty;
        }

        public List<ToDoModel> GetList(int userId)
        {
            List<ToDoModel> list = new List<ToDoModel>();

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = connection.CreateCommand())
            {

                try
                {
                    // データベース接続
                    connection.Open();

                    // SQL文準備
                    command.CommandText = @"SELECT TaskId, Title, Description, Deadline, Priority, Status FROM Tasks WHERE UserId = @UserId";
                    command.Parameters.Add(new SqlParameter("@UserId", userId));

                    // 読み取り
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ToDoModel()
                            {
                                Id = (int)reader["TaskId"],
                                Title = (string)reader["Title"],
                                Description = (string)reader["Description"],
                                Deadline = (DateTime)reader["Deadline"],
                                Priority = (string)reader["Priority"],
                                Status = (string)reader["Status"],
                                UserId = userId
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
                finally
                {
                    // データベース切断
                    connection.Close();
                }
            }

            return list;
        }

        public ToDoModel? GetItem(int userId, int taskId)
        {
            throw new NotImplementedException();
        }
    }
}
