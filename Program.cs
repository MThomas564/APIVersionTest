using Asp.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
})
.AddMvc()
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = false;
});

// Register document transformer for each OpenAPI document
builder.Services.AddOpenApi("v1", options =>
{
    options.AddDocumentTransformer<OpenAPIPathTransform>();
});
builder.Services.AddOpenApi("v2", options =>
{
    options.AddDocumentTransformer<OpenAPIPathTransform>();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "API Version 1");
        options.SwaggerEndpoint("/openapi/v2.json", "API Version 2");
        options.RoutePrefix = string.Empty; // Serve Swagger at the app's root
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
