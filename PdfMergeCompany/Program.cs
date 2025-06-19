var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles(); // Important for serving merged PDFs
app.MapControllers();
app.Run();
