using System.Text.RegularExpressions;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

public class OpenAPIPathTransform : IOpenApiDocumentTransformer
{
    public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
    {
        var newPaths = new OpenApiPaths();
        foreach (var path in document.Paths)
        {
            // Remove '/api/v{version}' from the path
            var newPath = Regex.Replace(path.Key, @"/api/v\{version\}", "", RegexOptions.IgnoreCase);
            var pathItem = path.Value;

            // Remove 'version' path parameter from all operations if present
            foreach (var operation in pathItem.Operations.Values)
            {
                if (operation.Parameters != null)
                {
                    operation.Parameters = operation.Parameters
                        .Where(p => !(p.In == ParameterLocation.Path && p.Name == "version"))
                        .ToList();
                }
            }

            newPaths.Add(newPath, pathItem);
        }

        document.Paths = newPaths;

        // Set the OpenAPI info.version property based on the document name
        if (!string.IsNullOrEmpty(context.DocumentName))
        {
            document.Info.Version = context.DocumentName;
        }

        // Set the servers property per version
        document.Servers.Clear();
        if (context.DocumentName == "v1")
        {
            document.Servers.Add(new OpenApiServer { Url = "/api/v1" });
        }
        else if (context.DocumentName == "v2")
        {
            document.Servers.Add(new OpenApiServer { Url = "/api/v2" });
        }

        return Task.CompletedTask;
    }
}