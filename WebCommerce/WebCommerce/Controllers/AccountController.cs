using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using WebCommerce.Models;

namespace WebCommerce.Controllers;

public class AccountController : Controller
{
    private readonly string _connectionString;

    public AccountController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("sqlite")!;
    }

    public ActionResult Index()
    {
        SqliteConnection connection = new SqliteConnection(_connectionString);

        string getUsersSql = "SELECT id, name, email FROM users";
        SqliteCommand getUsersCommand = new SqliteCommand(getUsersSql, connection);
        List<UserAccount> users = new List<UserAccount>();
        try
        {
            connection.Open();
            using (var reader = getUsersCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    users.Add(new UserAccount
                    {
                        Id = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        Email = reader.GetString(2)
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return BadRequest("Error retrieving users");
        }
        finally
        {
            connection.Close();
        }


        return View(users);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(AccountModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        SqliteConnection connection = new SqliteConnection(_connectionString);

        string checkExistsSql = "SELECT COUNT(*) FROM users WHERE email = @Email";
        SqliteCommand checkExistsCommand = new SqliteCommand(checkExistsSql, connection);
        checkExistsCommand.Parameters.AddWithValue("@Email", model.Email);

        try
        {
            connection.Open();
            var exists = (long)checkExistsCommand.ExecuteScalar();
            if (exists > 0)
            {
                return BadRequest("Email already exists");
            }

            string insertUserSql = "INSERT INTO users (name, email) VALUES (@name, @email)";
            SqliteCommand insertUserCommand = new SqliteCommand(insertUserSql, connection);
            insertUserCommand.Parameters.AddWithValue("@name", model.UserName);
            insertUserCommand.Parameters.AddWithValue("@email", model.Email);
            insertUserCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return BadRequest("Error registering user");
        }
        finally
        {
            connection.Close();
        }

        return View("AccountRegistered", model);
    }
}