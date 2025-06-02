using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

EnsureDatabase(app.Configuration);

app.Run();

void EnsureDatabase(IConfiguration configuration)
{
    var connectionString = configuration.GetConnectionString("sqlite");
    SqliteConnection connection = new SqliteConnection(connectionString);
    string createTableSql = "CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT, email TEXT)";

    SqliteCommand createTableCommand = new SqliteCommand(createTableSql, connection);

    try
    {
        connection.Open();
        createTableCommand.ExecuteNonQuery();
        Console.WriteLine("Table created and data inserted!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    finally
    {
        connection.Close();
    }
}