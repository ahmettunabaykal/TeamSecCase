
using CaseTeamSec.Services;
using CaseTeamSec.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IWriterService, WriterService>();
builder.Services.AddSingleton<IWriterRepository, WriterRepository>();
builder.Services.AddSingleton<IArticleRepository, ArticleRepository>();
builder.Services.AddSingleton<IArticleService, ArticleService>();

builder.Services.AddSingleton<ICommentService, CommentService>();
builder.Services.AddSingleton<ICommentRepository, CommentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
