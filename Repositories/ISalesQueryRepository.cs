using InventoryApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Repositories
{
    public interface ISalesQueryRepository
    {
        Task<List<SalesView>> GetSalesAsync(DateTime? from, DateTime? to, int? clientId);
        Task<List<SaleDetailView>> GetSaleDetailsAsync(int saleId);
        Task<List<Client>> GetClientsForFilterAsync();
    }
}
