using Dapper;
using DapperAPI.Data;

namespace DapperAPI.Models
{
    public class RepositoryBase : IRepositoryBase<Entity>
    {
        private readonly HeroContext _context;
        public RepositoryBase(HeroContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Entity>> GetAll()
        {
            var query = "SELECT * FROM Heros";

            using var conn = _context.CreateConnection();
            var resultado = await conn.QueryAsync<Entity>(query);
            return resultado.ToList();
        }

        public async Task<Entity> GetById(int id)
        {
            var query = "SELECT * FROM Heros WHERE Id = @Id;";

            using var conn = _context.CreateConnection();
            var resultado = await conn.QueryFirstOrDefaultAsync<Entity>(query, new { id });
            return resultado;
        }

        public async Task<Entity> GetByName(string name)
        {
            var query = "SELECT * FROM Heros WHERE Name = @Name;";

            using var conn = _context.CreateConnection();
            var resultado = await conn.QueryFirstOrDefaultAsync<Entity>(query, new { name });
            return resultado;
        }

        public async Task CreateAsync(Entity entity)
        {
            var query = "INSERT INTO Heros(Name, Attribute, Complexity, Biography, Image) VALUES (@Name, @Attribute, @Complexity, @Biography, @Image);";

            using var conn = _context.CreateConnection();
            await conn.ExecuteAsync(query, entity);
        }

        public async Task UpdateAsync(Entity entity, int id)
        {
            var query = "UPDATE Heros SET Name = @Name, Attribute = @Attribute, Complexity = @Complexity, Biography = @Biography, Image = @Image WHERE Id =" + id;

            var parameters = new DynamicParameters();
            parameters.Add("@Id", entity.Id);
            parameters.Add("@Name", entity.Name);
            parameters.Add("@Attribute", entity.Attribute);
            parameters.Add("@Complexity", entity.Complexity);
            parameters.Add("@Biography", entity.Biography);
            parameters.Add("@Image", entity.Image);

            using var conn = _context.CreateConnection();
            await conn.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            var query = "DELETE FROM Heros WHERE Id = @Id";

            using var conn = _context.CreateConnection();
            await conn.ExecuteAsync(query, new { id });
        }
    }
}
