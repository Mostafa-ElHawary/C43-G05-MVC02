namespace MVC01G02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews(); // Register Built-in MVC services
            var app = builder.Build();
            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            app.Run();
        }

        public static string User(string username)
        {
            return $" Helloo {username}";
        }
    }
}
