using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Optimization;

namespace ZG.Store.Presentation.App_Code
{
    public class CoffeeCompiler : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            var coffeeEngine = new CoffeeSharp.CoffeeScriptEngine();
            var compiledCoffeeScript = new StringBuilder();

            foreach (var file in response.Files)
            {
                using (var reader = new StreamReader(file.FullName))
                {
                    compiledCoffeeScript.AppendFormat("{0}\n", coffeeEngine.Compile(reader.ReadToEnd()));
                }
            }

            response.Content = compiledCoffeeScript.ToString();
            response.ContentType = "text/javascript";
            response.Cacheability = HttpCacheability.Public;
        }
    }
}