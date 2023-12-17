using SchoolDataSystem.Repository;
using System.Dynamic;

namespace SchoolDataSystem.Models
{
	public partial class School
	{
		public static School? GetEntity(Guid? schoolId)
			=> schoolId is null ? null : Query(schoolId).FirstOrDefault();

		public static IEnumerable<School> Query(Guid? schoolId)
		{
			List<string> selectList = new() { "school.*" },
				fromList = new() { "school" },
				whereList = new() { };
			dynamic @params = new ExpandoObject();

			if (schoolId is not null)
			{
				whereList.Add("school.school_id = $schoolId");
				@params.schoolId = schoolId;
			}

			return (Sql.Select(selectList, from: fromList, where: whereList, @params: @params)
				as IEnumerable<Sql.Row>)!
				.Select(FromData);
		}

		public static IEnumerable<Class> GetClasses(Guid schoolId) =>
			Sql.Select("class.*, class_school.*",
				from: "class " +
				"LEFT OUTER JOIN school class_school ON class.class_school_id = school.school_id AND school.school_id = $schoolId",
				@params: new { schoolId })
			.Select(Class.FromData);

		public static void Add(string schoolName) =>
			Sql.Insert(into: "school",
				fields: "school_id, school_name",
				values: "$schoolId, $schoolName",
				@params: new { schoolId = Guid.NewGuid(), schoolName });

		public static void Remove(Guid schoolId) =>
			Sql.Delete(from: "school",
				where: "school.school_id = $schoolId",
				@params: new { schoolId });
	}
}
