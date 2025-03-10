using Microsoft.EntityFrameworkCore;
using WebApi.DAL;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Repository;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.Configure<EncryptionKey>(builder.Configuration.GetSection("EncryptionKey"));

builder.Services.AddTransient<Seed>();
builder.Services.AddScoped<EncryptionService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IChatGroupRepository, ChatGroupRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

if (args[0] == "seed") SeedData(app);

static void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();