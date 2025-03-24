using FlagExplorer.Application.MappingProfiles;
using FlagExplorer.Infrastructure.DependencyInjection;


var app = CreateWebApplication(args);
app.Run();

public partial class Program
{
    public static WebApplication CreateWebApplication(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAutoMapper(typeof(CountryProfile).Assembly);
        builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<CountryProfile>());
        builder.Services.AddInfrastructureServices();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new() { Title = "Country API", Version = "v1" });
        });


        var app = builder.Build();

// Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        return app;
    }
}
