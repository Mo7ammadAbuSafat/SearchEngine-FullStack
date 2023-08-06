using SearchApi.Repositories.Implementations;
using SearchApi.Repositories.Interfaces;
using SearchApi.Services.Implementations;
using SearchApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDocumentRepository, DocumentRepository>();
builder.Services.AddSingleton<IIndexRepository, IndexRepository>();
builder.Services.AddScoped<IIndexService, IndexService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ISearchService, SearchService>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(c =>
{
    c.AddDefaultPolicy(options =>
    options.WithOrigins("http://localhost:3000")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
