using Microsoft.EntityFrameworkCore;
using MovieStoreBackend.DataAccess.EFCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreBackend.Utils
{
    public class ConnectionDB
    {
        public async Task<List<T>> RawSqlQuery<T>(string query, MovieStoreDataContext context, Func<DbDataReader, T> map)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                await context.Database.OpenConnectionAsync();
                using (var result = await command.ExecuteReaderAsync())
                {
                    var entities = new List<T>();
                    while (await result.ReadAsync())
                    {
                        entities.Add(map(result));
                    }
                    return entities;
                }
            }
        }
    }
}
