
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




#region Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CORS_Policy",
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddRazorPages();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CORS_Policy");
app.UseAuthentication();
app.UseAuthorization();
//app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.MapControllers();
app.Run();