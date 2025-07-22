//using App.Applicacion.Interfaces;
//using App.Dominio.Entities;
//using App.Infraestructura.Data;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.Infraestructura.Services
//{
//    public class PersoService1 : IPersoService
//    {
//        private readonly AppDbContext _context;

//        public PersoService1(AppDbContext context)
//        {
//            _context = context;
//        }
//        public async Task<IEnumerable<Perso>> GetAllAsync()
//        {
//            return await _context.Perso.ToListAsync();
//        }

//        public async Task<string> GenerarTxtAsync()
//        {
//            var lista = await GetAllAsync();
//            var sb = new StringBuilder();

//            foreach (var item in lista)
//            {
//                sb.AppendLine($"{item.id}\t{item.bin_id}\t{item.cliente}");
//            }

//            var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
//            var filename = $"perso_export_{timestamp}.txt";
//            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
//            await File.WriteAllTextAsync(path, sb.ToString());

//            return path;
//        }
//    }
//}
