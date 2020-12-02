using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using BootStrap01.Middleware;

namespace BootStrap01.Middleware
{
    public static class applicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder applicationBuilder, string root)
        {
            var path = Path.Combine(root, "node_modules");
            var fileProvider = new PhysicalFileProvider(path);

            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
            options.FileProvider = fileProvider;

            applicationBuilder.UseStaticFiles(options);
            return applicationBuilder;
        }
    }
}