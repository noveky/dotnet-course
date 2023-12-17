namespace SchoolDataSystem.Repository
{
	public class Sql
	{
		public class Row
		{
			readonly Dictionary<string, object?> dict = new();

			public object? this[string fieldName]
			{
				get => dict.TryGetValue(fieldName, out object? value) ? value : null;
				set => dict[fieldName] = value;
			}
		}

		public static int Execute(string sql, object? @params) =>
			new Dao(sql, @params).ExecuteNonQuery();
		public static IEnumerable<Row> Select(object _, object? from = null, object? where = null, object? @params = null) =>
			Dao.ForQuery(_, from, where, @params).QueryRows();
		public static Row? SelectRow(object _, object? from = null, object? where = null, object? @params = null) =>
			Dao.ForQuery(_, from, where, @params).QueryRows().FirstOrDefault();
		public static T? Select<T>(object _, object? from = null, object? where = null, object? @params = null) =>
			(T?)Dao.ForQuery(_, from, where, @params).QuerySingleValue();
		public static bool Exists(object _, object? from = null, object? where = null, object? @params = null) =>
			SelectRow(_, from, where, @params) is not null;
		public static int Update(string _, object? set, object? where, object? @params = null) =>
			Dao.ForUpdate(_, set, where, @params).ExecuteNonQuery();
		public static int Insert(string into, object? fields, object values, object? @params = null) =>
			Dao.ForInsert(into, fields, (IEnumerable<object>)(values is IEnumerable<object> ? values : new[] { values }), @params).ExecuteNonQuery();
		public static int Delete(object from, object? where, object? @params = null) =>
			Dao.ForDelete(from, where, @params).ExecuteNonQuery();
	}
}
