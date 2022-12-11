using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/{id:guid}/search_NOT_using_WithOpenApi", ([FromRoute(Name = "id")] Guid searchId,
    [FromQuery(Name = "q")] string searchText, [FromHeader(Name = "x-version")] string version) =>
{
    return TypedResults.NoContent();
});

app.MapGet("/api/{id:guid}/search_using_WithOpenApi", ([FromRoute(Name = "id")] Guid searchId,
    [FromQuery(Name = "q")] string searchText, [FromHeader(Name = "x-version")] string version) =>
{
    return TypedResults.NoContent();
})
// If I use "WithOpenApi", then route, query and header parameter names are ignored.
.WithOpenApi();

app.Run();
