using Microsoft.EntityFrameworkCore;
using RecruitmentApp.Infrastructure.Data;
using MediatR;
using RecruitmentApp.Domain.Interfaces;
using RecruitmentApp.Infrastructure.Repositories;
using RecruitmentApp.Frontend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("RecruitmentAppDb"));

builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();

builder.Services.AddRazorPages(options =>
{
    options.RootDirectory = "/Frontend/Pages";
});


builder.Services.AddHttpClient<CandidateApiClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5276");
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.Run();
