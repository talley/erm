// See https://aka.ms/new-console-template for more information




static class Program
{

    public static void Main(string[] args)
    {
        var connString = "Host=192.168.1.227;Username=app_user;Password=Iamsmart27@;Database=northwind";

        var user1 = new User
        {
            created_at=DateTime.Now.ToString(),created_by=Environment.MachineName,
            first_name="Abibou",last_name="Ouro", user_name="Ourota",updated_at=null,
            updated_by=null
        };
        InsertUser(user1);
        using (IDbConnection pgcon = new NpgsqlConnection(connString))
        {
            var users = pgcon.Query<User>("SELECT * FROM Users");
            if (users.Any())
            {
                users.ToList().ForEach(x =>
                {
                    Console.WriteLine(x);
                });
            }
        }
    }
    public static void InsertUser2(User user)
    {

    }
      public static void InsertUser(User user)
    {
        var connString = "Host=192.168.1.227;Username=app_user;Password=Iamsmart27@;Database=northwind";
        using (IDbConnection pgcon = new NpgsqlConnection(connString))
        {
            pgcon.Insert<User>(user);
        }
    }
}