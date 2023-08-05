using SearchApi.Repositories.Implementations;
using SearchApi.Repositories.Interfaces;
using SearchApi.Services.Implementations;
using SearchApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDocumentRepository, DocumentRepository>();
builder.Services.AddSingleton<IIndexRepository, IndexRepository>();
builder.Services.AddSingleton<IIndexService, IndexService>();
builder.Services.AddSingleton<IFileService, FileService>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
