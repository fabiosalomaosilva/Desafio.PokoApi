using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Desafio.PokoApi.NetFramework.Api.Models.Local;

namespace Desafio.PokoApi.NetFramework.Api.Repositories
{
    public class PokemonRepository
    {
        private static readonly string _path = System.AppDomain.CurrentDomain.BaseDirectory + "App_Data\\data.db";
        private static readonly string _connectionString = $"Data source={_path}";
        private static SQLiteConnection _sqliteConnection;

        private static SQLiteConnection DbConnection()
        {
            _sqliteConnection = new SQLiteConnection(_connectionString);
            _sqliteConnection.Open();
            return _sqliteConnection;
        }

        public static void CreateBd()
        {
            try
            {
                SQLiteConnection.CreateFile(_path);
            }
            catch
            {
                throw;
            }
        }

        public static void CriarTabelaPokemonMaster()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS PokemonMasters(PokemonMasterId INTEGER PRIMARY KEY, Name TEXT, Age INTEGER, Cpf INTEGER)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CriarTabelaPokemonCaptured()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS PokemonLocal(Id INTEGER PRIMARY KEY, Name TEXT, Height INTEGER, Weight INTEGER, Evolution TEXT, SpriteBase64 TEXT, Color TEXT)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task AddPokemonMasterAsync(PokemonMaster master)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO PokemonMasters(Name, Age, Cpf) values (@name, @age, @cpf)";
                    cmd.Parameters.AddWithValue("@name", master.Name);
                    cmd.Parameters.AddWithValue("@age", master.Age);
                    cmd.Parameters.AddWithValue("@cpf", master.Cpf);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task AddPokemonCapturedAsync(PokemonLocal pokemon)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO PokemonLocal(Name, Height, Weight, Evolution, SpriteBase64, Color) values (@name, @height, @weight, @evolution, @spriteBase64, @color)";
                    cmd.Parameters.AddWithValue("@name", pokemon.Name);
                    cmd.Parameters.AddWithValue("@height", pokemon.Height);
                    cmd.Parameters.AddWithValue("@weight", pokemon.Weight);
                    cmd.Parameters.AddWithValue("@evolution", pokemon.Evolution);
                    cmd.Parameters.AddWithValue("@spriteBase64", pokemon.SpriteBase64);
                    cmd.Parameters.AddWithValue("@color", pokemon.Color);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static async Task<List<PokemonLocal>> GetAllPokemonsCapturedsAsync()
        {
            var pokemons = new List<PokemonLocal>();
            using (var cmd = DbConnection().CreateCommand())
            {

                cmd.CommandText = "select * from PokemonLocal";
                cmd.CommandType = CommandType.Text;
                var rdr = await cmd.ExecuteReaderAsync();
                while (await rdr.ReadAsync())
                {
                    var pokemon = new PokemonLocal
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        Name = rdr["Name"].ToString(),
                        Height = Convert.ToInt32(rdr["Height"]),
                        Weight = Convert.ToInt32(rdr["Weight"]),
                        Evolution = rdr["Evolution"].ToString(),
                        SpriteBase64 = rdr["SpriteBase64"].ToString(),
                        Color = rdr["Color"].ToString()
                    };
                    pokemons.Add(pokemon);
                }
            }
            return pokemons;
        }
    }
}