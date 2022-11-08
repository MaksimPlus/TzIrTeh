using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using server.DAL;
using server.DAL.Repository;
using server.DAL.Repository.Interface;
using System;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IQuestionnaireRepository, QuestionnaireRepository>();
builder.Services.AddTransient<IQuestionRepository, QuestionRepository>();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataDbContext>(options => options.UseSqlServer(connection));

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();