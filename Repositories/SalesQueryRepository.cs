using InventoryApp.Domain;
using InventoryApp.Infrastructure;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Repositories
{
    public class SalesQueryRepository : ISalesQueryRepository
    {
        public async Task<List<Client>> GetClientsForFilterAsync()
        {
            var list = new List<Client>();
            using var con = DbConnectionFactory.Instance.CreateOpen();
            using var cmd = new MySqlCommand(
                "SELECT id, nombre FROM cliente ORDER BY nombre", con);
            using var rd = await cmd.ExecuteReaderAsync();
            while (await rd.ReadAsync())
                list.Add(new Client { Id = rd.GetInt32("id"), Nombre = rd.GetString("nombre") });
            return list;
        }
    


        public async Task<List<SalesView>> GetSalesAsync(DateTime? from, DateTime? to, int? clientId)
        {
            var list = new List<SalesView>();
            using var con = DbConnectionFactory.Instance.CreateOpen();

            var sql = @"SELECT v.id, v.fecha, v.cliente_id, c.nombre AS cliente, COALESCE(v.total, SUM(d.subtotal)) AS total FROM venta v
                            JOIN cliente c ON c.id = v.cliente_id LEFT JOIN detalle_venta d ON d.venta_id = v.id WHERE 1=1 /**from**/ /**to**/ /**client**/
                            GROUP BY v.id, v.fecha, v.cliente_id, c.nombre, v.total ORDER BY v.fecha DESC, v.id DESC;";

            if (from.HasValue) sql = sql.Replace("/**from**/", "AND v.fecha >= @from");
            else sql = sql.Replace("/**from**/", "");
            if (to.HasValue) sql = sql.Replace("/**to**/", "AND v.fecha <  @to");
            else sql = sql.Replace("/**to**/", "");
            if (clientId.HasValue) sql = sql.Replace("/**client**/", "AND v.cliente_id = @cid");
            else sql = sql.Replace("/**client**/", "");

            using var cmd = new MySqlCommand(sql, con);
            if (from.HasValue) cmd.Parameters.AddWithValue("@from", from.Value);
            if (to.HasValue) cmd.Parameters.AddWithValue("@to", to.Value);
            if (clientId.HasValue) cmd.Parameters.AddWithValue("@cid", clientId.Value);

            using var rd = await cmd.ExecuteReaderAsync();
            while (await rd.ReadAsync())
            {
                list.Add(new SalesView
                {
                    Id = rd.GetInt32("id"),
                    Fecha = rd.GetDateTime("fecha"),
                    ClienteId = rd.GetInt32("cliente_id"),
                    ClienteNombre = rd.GetString("cliente"),
                    Total = rd["total"] == DBNull.Value ? 0m : rd.GetDecimal("total")
                });
            }
            return list;
        }



        public async Task<List<SaleDetailView>> GetSaleDetailsAsync(int saleId)
        {
            var list = new List<SaleDetailView>();
            using var con = DbConnectionFactory.Instance.CreateOpen();
            using var cmd = new MySqlCommand(@" SELECT d.venta_id, p.id AS producto_id, p.nombre AS producto, d.cantidad, d.precio_unit AS precio, d.subtotal
                                                FROM detalle_venta d JOIN producto p ON p.id = d.producto_id WHERE d.venta_id = @id ORDER BY p.nombre;", con);
            cmd.Parameters.AddWithValue("@id", saleId);

            using var rd = await cmd.ExecuteReaderAsync();
            while (await rd.ReadAsync())
            {
                list.Add(new SaleDetailView
                {
                    VentaId = rd.GetInt32("venta_id"),
                    ProductoId = rd.GetInt32("producto_id"),
                    ProductoNombre = rd.GetString("producto"),
                    Cantidad = rd.GetInt32("cantidad"),
                    Precio = rd.GetDecimal("precio"),
                    Subtotal = rd.GetDecimal("subtotal")
                });
            }
            return list;
        }


    }
}
