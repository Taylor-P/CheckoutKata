using System.IO;
using System.Reflection;
using System.Text;
using BusinessCore.Areas.DataImport.Repositories;

namespace Infrastructure.Areas.Repositories
{
    public class ProductFileRepository : IProductFileRepository
    {
        public string[] ProductFile()
        {
            return File.ReadAllLines(
                Path.Combine(
                    Path.GetDirectoryName(
                        Assembly.GetExecutingAssembly().Location), 
                    @"..\..\..\..\Infrastructure\Areas\Data\ProductFile.txt"), 
                Encoding.UTF8);

        }
    }
}
