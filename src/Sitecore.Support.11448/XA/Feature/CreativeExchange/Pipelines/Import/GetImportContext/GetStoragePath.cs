using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Configuration;
using Sitecore.DependencyInjection;
using Sitecore.XA.Feature.CreativeExchange.Models.Export;
using Sitecore.XA.Feature.CreativeExchange.Pipelines.Import.GetImportContext;
using Sitecore.XA.Feature.CreativeExchange.Services;

namespace Sitecore.Support.XA.Feature.CreativeExchange.Pipelines.Import.GetImportContext
{
  public class GetStoragePath : GetImportContextBaseProcessor
  {
    public override void Process(GetImportContextArgs args)
    {
      base.Process(args);
      string packageName = this.GetParameter("PackageName");

      #region FIX 11448
      var relativePath = Path.Combine(Settings.PackagePath, @"CreativeExchange", packageName);
      args.ImportContext.ImportOptions.Storage = ServiceLocator.ServiceProvider.GetService<IStoragePathResolver>().MapPath(relativePath, new HttpContextData(args.HttpContext));
      #endregion
    }
  }
}