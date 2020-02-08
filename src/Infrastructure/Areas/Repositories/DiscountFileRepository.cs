using System.IO;
using System.Reflection;
using System.Text;
using BusinessCore.Areas.DataImport.Repositories;

namespace Infrastructure.Areas.Repositories
{
    public class DiscountFileRepository : IDiscountFileRepository
    {
        public string[] DiscountFile()
        {
            return File.ReadAllLines(
                Path.Combine(
                    Path.GetDirectoryName(
                        Assembly.GetExecutingAssembly().Location),
                    @"..\..\..\..\Infrastructure\Areas\Data\DiscountFile.txt"),
                Encoding.UTF8);
        }
    }
}
