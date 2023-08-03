using System.Collections.Generic;
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
                                Title = reader["Title"].TryParseString(),
                                Description = reader["Description"].TryParseString(),
                                Deadline = reader["Deadline"].TryParseDateTime(),
                                Priority = reader["Priority"].TryParseString(),
                                Status = reader["Status"].TryParseString(),
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

        public ToDoModel? GetItem(int taskId)
        {
            List<ToDoModel> list = new List<ToDoModel>();

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();

                    command.CommandText = @"SELECT TaskID, Title, Description, Deadline, Priority, Status, UserId FROM Tasks WHERE TaskID = @TaskId;";
                    command.Parameters.Add(this.CreateSqlParameter("@TaskId", taskId));

                    // 読み取り
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ToDoModel()
                            {
                                Id = (int)reader["TaskId"],
                                Title = reader["Title"].TryParseString(),
                                Description = reader["Description"].TryParseString(),
                                Deadline = reader["Deadline"].TryParseDateTime(),
                                Priority = reader["Priority"].TryParseString(),
                                Status = reader["Status"].TryParseString(),
                                UserId = (int)reader["UserId"]
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return list.Count > 0 ? list[0] : null;
        }

        public ToDoModel Create(ToDoModel model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();

                    command.CommandText = @"INSERT INTO Tasks (Title, Description, Deadline, Priority, Status, UserId) VALUES ( @Title, @Description, @Deadline, @Priority, @Status, @UserID )";
                    command.Parameters.Add(this.CreateSqlParameter("@Title", model.Title));
                    command.Parameters.Add(this.CreateSqlParameter("@Description", model.Description));
                    command.Parameters.Add(this.CreateSqlParameter("@Deadline", model.Deadline));
                    command.Parameters.Add(this.CreateSqlParameter("@Priority", model.Priority));
                    command.Parameters.Add(this.CreateSqlParameter("@Status", model.Status));
                    command.Parameters.Add(this.CreateSqlParameter("@UserID", model.UserId));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return model;
        }

        public bool Delete(int taskId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();

                    command.CommandText = @"DELETE FROM Tasks WHERE TaskID = @TaskId";
                    command.Parameters.Add(this.CreateSqlParameter("@TaskId", taskId));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return true;
        }

        public ToDoModel Update(ToDoModel model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();

                    command.CommandText = @"UPDATE Tasks Set Title = @Title, Description = @Description, Deadline = @Deadline, Priority = @Priority, Status = @Status, UserId = @UserId WHERE TaskId = @TaskId";
                    command.Parameters.Add(this.CreateSqlParameter("@Title", model.Title));
                    command.Parameters.Add(this.CreateSqlParameter("@Description", model.Description));
                    command.Parameters.Add(this.CreateSqlParameter("@Deadline", model.Deadline));
                    command.Parameters.Add(this.CreateSqlParameter("@Priority", model.Priority));
                    command.Parameters.Add(this.CreateSqlParameter("@Status", model.Status));
                    command.Parameters.Add(this.CreateSqlParameter("@UserID", model.UserId));
                    command.Parameters.Add(this.CreateSqlParameter("@TaskId", model.Id));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return model;
        }

        private SqlParameter CreateSqlParameter<T>(string parameterName, T value)
        {
            if(value == null)
            {
                return new SqlParameter(parameterName, DBNull.Value);
            }
            else
            {
                return new SqlParameter(parameterName, value);
            }
        }
    }
}
