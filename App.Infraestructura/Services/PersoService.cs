using App.Applicacion.Interfaces;
using App.Dominio;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infraestructura.Services
{
    public class PersoService : IPersoService
    {
        private readonly string _connectionString;

        public PersoService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Perso>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();
            var result = await connection.QueryAsync<Perso>("WITH datos_filtrados AS (\r\n  SELECT id, bin_id, cliente, fecha\r\n  FROM perso\r\n  WHERE fecha IS NOT NULL\r\n)\r\nSELECT *\r\nFROM datos_filtrados\r\nORDER BY fecha DESC;\r\n");
            return result;
        }

        public async Task<string> GenerarTxtAsync()
        {
            var lista = await GetAllAsync();
            var sb = new StringBuilder();

            foreach (var item in lista)
            {
                sb.AppendLine($"{item.id}\t{item.bin_id}\t{item.cliente}\t{item.fecha}");
            }

            //var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "perso_export.txt");
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            var filename = $"perso_export_{timestamp}.txt";
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
            await File.WriteAllTextAsync(path, sb.ToString());

            return path;
        }
    }
}
