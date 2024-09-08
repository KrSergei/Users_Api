using Autofac;
using Autofac.Extensions.DependencyInjection;
using Users_Api.Db;
using Users_Api.Dto;
using Users_Api.Repo;

internal class Program
{
    public static WebApplication BuildWebApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(typeof(MappingProfile));

        var config = new ConfigurationBuilder();
        config.AddJsonFile("appsettings.json");
        var cfg = config.Build();

        builder.Configuration.GetConnectionString("db");

        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(cb => 
        {
            cb.RegisterType<UserRepository>().As<IUserRepository>();
            cb.Register(c => new AppDbContext(cfg.GetConnectionString("db"))).InstancePerDependency();
        
        });

        return builder.Build();
    }
    private static void Main(string[] args)
    {
        var app = BuildWebApp(args);

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        app.Run();
    }
}