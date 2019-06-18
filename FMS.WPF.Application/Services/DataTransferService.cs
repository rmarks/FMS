using FMS.DAL.EFCore;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace FMS.WPF.Application.Services
{
    public class DataTransferService : IDataTransferService
    {
        public void TransferData()
        {
            var context = new FMSDbContext();

            MessageBoxResult deleteDialogResult = MessageBox.Show("Kas kustutame andmed?", "Teade", MessageBoxButton.YesNo);
            if (deleteDialogResult == MessageBoxResult.Yes)
            {
                context.Database.EnsureDeleted();

                context.Database.EnsureCreated();

                MessageBoxResult refreshDialogResult = MessageBox.Show("Andmed kustutatud. Kas värskendame andmed?", "Teade", MessageBoxButton.YesNo);
                if (refreshDialogResult == MessageBoxResult.Yes)
                {
                    var sqlFiles = Directory.GetFiles(@"C:\Temp\juveel\scripts", "*.sql").OrderBy(x => x);
                    foreach (string file in sqlFiles)
                    {
                        context.Database.ExecuteSqlCommand(File.ReadAllText(file, Encoding.Default));
                    }

                    MessageBox.Show("Andmed värskendatud!");
                }
            }
        }
    }
}
