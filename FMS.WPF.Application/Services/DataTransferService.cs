using FMS.DAL.EFCore;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Text;

namespace FMS.WPF.Application.Services
{
    public class DataTransferService : IDataTransferService
    {
        public void  ClearDatabase()
        {
            var context = new FMSDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        public bool TransferData()
        {
            try
            {
                var context = new FMSDbContext();

                var sqlFiles = Directory.GetFiles(@"C:\Temp\juveel\scripts", "*.sql").OrderBy(x => x);
                foreach (string file in sqlFiles)
                {
                    context.Database.ExecuteSqlCommand(File.ReadAllText(file, Encoding.Default));
                }
            }
            catch (IOException e)
            {
                return false;
            }

            return true;
        }
    }
}
