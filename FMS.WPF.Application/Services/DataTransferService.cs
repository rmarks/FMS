using FMS.DAL.EFCore;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Windows;

namespace FMS.WPF.Application.Services
{
    public class DataTransferService : IDataTransferService
    {
        public void TransferData()
        {
            var context = new FMSDbContext();

            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            MessageBoxResult dialogResult = MessageBox.Show("Andmed kustutatud. Kas värskendame andmed?", "Teade", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                var sqlFiles = Directory.GetFiles(@"C:\Temp\juveel\scripts", "*.sql").OrderBy(x => x);
                foreach (string file in sqlFiles)
                {
                    context.Database.ExecuteSqlCommand(File.ReadAllText(file));
                }

                MessageBox.Show("Andmed värskendatud!");
            }
        }
    }
}
