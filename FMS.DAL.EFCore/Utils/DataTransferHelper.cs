using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Text;

namespace FMS.DAL.EFCore.Utils
{
    public class DataTransferHelper
    {
        public static void ClearDatabase()
        {
            var context = new SQLServerDbContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        public static bool TransferData()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            try
            {
                var context = new SQLServerDbContext();
                context.Database.SetCommandTimeout(5 * 60);

                var sqlFiles = Directory.GetFiles(@"C:\Temp\juveel\scripts", "*.sql").OrderBy(x => x);

                foreach (string file in sqlFiles)
                {
                    context.Database.ExecuteSqlCommand(File.ReadAllText(file, Encoding.GetEncoding(1257))); //Encoding.Default
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
