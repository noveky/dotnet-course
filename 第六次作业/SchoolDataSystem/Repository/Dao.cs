using SchoolDataSystem.Utilities;
using System.Data.SQLite;
using System.Data;

namespace SchoolDataSystem.Repository
{
    public class Dao
	{
		private readonly SQLiteConnection connection;
		private readonly SQLiteCommand command;

		readonly bool forLogging;

		public Dao(string? sql, object? @params, bool forLogging = false)
		{
			connection = new SQLiteConnection("Data Source=school_db.db;Version=3;");
			command = connection.CreateCommand();
			command.CommandText = sql;
			IDictionary<string, object?> paramMap;
			if (@params is null)
			{
				return;
			}
			else if (@params is IDictionary<string, object?> dict)
			{
				paramMap = dict;
			}
			else
			{
				paramMap = new Dictionary<string, object?>();
				foreach (var field in @params.GetType().GetFields())
				{
					paramMap[field.Name] = field.GetValue(@params);
				}
				foreach (var prop in @params.GetType().GetProperties())
				{
					paramMap[prop.Name] = prop.GetValue(@params);
				}
			}
			paramMap.ToList().ForEach(p => command.Parameters.AddWithValue($"${p.Key}", p.Value));

			this.forLogging = forLogging;
		}

		public object? QuerySingleValue()
		{
			try
			{
				connection.Open();
				var value = command.ExecuteScalar();
				value = value is DBNull ? null : value;
				return value;
			}
			finally
			{
				LogAndClose();
			}
		}

		public IEnumerable<Sql.Row> QueryRows()
		{
			SQLiteDataReader? reader = null;
			try
			{
				connection.Open();
				reader = command.ExecuteReader();
				while (reader.Read())
				{
					var row = new Sql.Row();
					for (int i = 0; i < reader.FieldCount; ++i)
					{
						string fieldName = reader.GetName(i);
						object? fieldValue = reader.IsDBNull(i) ? null : reader[i];
						row[fieldName] = fieldValue;
					}
					yield return row;
				}
			}
			finally
			{
				reader?.Close();
				LogAndClose();
			}
		}

		public int ExecuteNonQuery()
		{
			try
			{
				connection.Open();
				int rowsAffected = command.ExecuteNonQuery();
				return rowsAffected;
			}
			finally
			{
				LogAndClose();
			}
		}

		void LogAndClose()
		{
			if (!forLogging)
			{
				new Dao("INSERT INTO log (log_operation) VALUES ($logOperation)",
					@params: new { logOperation = command.CommandText })
					.ExecuteNonQuery();
			}
			command.Dispose();
			connection.Close();
		}

		public static Dao ForQuery(object selectList, object? fromList, object? whereList, object? @params)
		{
			var sql = SqlBuilder.Join(" ", new[]
			{
				SqlBuilder.BuildSelect(selectList),
				SqlBuilder.BuildFrom(fromList),
				SqlBuilder.BuildWhere(whereList),
			});
			return new(sql, @params);
		}

		public static Dao ForUpdate(string table, object? setList, object? whereList, object? @params)
		{
			var sql = SqlBuilder.Join(" ", new[]
			{
				"UPDATE", table,
				SqlBuilder.Build("SET ", setList, ", "),
				SqlBuilder.BuildWhere(whereList),
			});
			return new(sql, @params);
		}

		public static Dao ForInsert(string table, object? fieldList, IEnumerable<object> valueLists, object? @params)
		{
			var sql = SqlBuilder.Join(" ", new[]
			{
				"INSERT INTO", table,
				SqlBuilder.Build("(", fieldList, ", ", ")"),
				SqlBuilder.Build("VALUES ", valueLists.Select(vl => SqlBuilder.Build("(", vl, ", ", ")")), ", ") ,
			});
			return new(sql, @params);
		}

		public static Dao ForDelete(object fromList, object? whereList, object? @params)
		{
			var sql = SqlBuilder.Join(" ", new[]
			{
				"DELETE",
				SqlBuilder.BuildFrom(fromList),
				SqlBuilder.BuildWhere(whereList),
			});
			return new(sql, @params);
		}
	}
}
