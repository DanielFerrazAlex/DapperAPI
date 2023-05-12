using DapperAPI.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;

namespace DapperAPI.Data
{
    public class HeroContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DbSet<Entity> Hero { get; set; }

        public HeroContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Database");
        }

        public IDbConnection CreateConnection()
            => new MySqlConnection(_connectionString);
    }
}
