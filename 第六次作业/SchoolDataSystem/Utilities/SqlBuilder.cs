namespace SchoolDataSystem.Utilities
{
	public static class SqlBuilder
	{
		public static string? Join(string? separator, IEnumerable<string?>? list) =>
			list is null ? null : string.Join(separator, list.Where(s => s is not null));
		public static string? Join(string? separator, params string?[]? list) =>
			Join(separator, (IEnumerable<string?>?)list);

		public static string? Build(string? start, IEnumerable<string?>? list, string? separator = null, string? end = null) =>
			list is null || !list.Any() ? null : $"{start}{Join(separator, list)}{end}";
		public static string? Build(string? start, string? list, string? separator = null, string? end = null) =>
			Build(start, list is null ? null : new[] { list }, separator, end);
		public static string? Build(string? start, object? list, string? separator = null, string? end = null) =>
			list is null
				? Build(start, (IEnumerable<string?>?)null, separator, end)
				: list is IEnumerable<string?> strs
					? Build(start, strs, separator, end)
					: list is string str
						? Build(start, str, separator, end)
						: throw new InvalidCastException();

		public static string? BuildSelect(object? selectList) =>
			Build("SELECT ", selectList, ", ");
		public static string? BuildFrom(object? fromList) =>
			Build("FROM ", fromList, " ");
		public static string? BuildWhere(object? whereList) =>
			Build("WHERE ", whereList, " AND ");
		public static string? BuildTuple(object? valueList) =>
			Build("(", valueList, ", ", ")");
	}
}
