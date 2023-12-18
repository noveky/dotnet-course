using SchoolDataSystem.Repository;
using System.Dynamic;

namespace SchoolDataSystem.Models
{
	public partial class Class
	{
		public static Class? GetEntity(int? classGrade, int? classNum)
			=> classGrade is null || classNum is null ? null : Query(classGrade, classNum, null).FirstOrDefault();

		public static IEnumerable<Class> Query(int? classGrade = null, int? classNum = null, Guid? schoolId = null)
		{
			List<string> selectList = new() { "class.*", "class_school.*" },
				fromList = new()
				{
					"class",
					"LEFT OUTER JOIN school class_school ON class.class_school_id = class_school.school_id",
				},
				whereList = new() { };
			dynamic @params = new ExpandoObject();

			if (classGrade is not null)
			{
				whereList.Add("class.class_grade = $classGrade");
				@params.classGrade = classGrade;
			}
			if (classNum is not null)
			{
				whereList.Add("class.class_num = $classNum");
				@params.classNum = classNum;
			}
			if (schoolId is not null)
			{
				whereList.Add("class.class_school_id = $schoolId");
				@params.schoolId = schoolId;
			}

			return (Sql.Select(selectList, from: fromList, where: whereList, @params: @params)
				as IEnumerable<Sql.Row>)!
				.Select(FromData);
		}

		public static IEnumerable<Student> GetStudents(int classGrade, int classNum) =>
			Sql.Select("student.*, student_class.*",
				from: "student " +
				"LEFT OUTER JOIN class student_class ON student.student_class_grade = student_class.class_grade AND student.student_class_num = student_class.class_num AND student_class.class_grade = $classGrade AND student_class.class_num = $classNum",
				@params: new { classGrade, classNum })
			.Select(Student.FromData);

		public static void Add(int classGrade, int classNum, Guid? classSchoolId) =>
			Sql.Insert(into: "class",
				fields: "class_grade, class_num, class_school_id",
				values: "$classGrade, $classNum, $classSchoolId",
				@params: new { classGrade, classNum, classSchoolId });

		public static void Remove(int classGrade, int classNum) =>
			Sql.Delete(from: "class",
				where: "class.class_grade = $classGrade AND class.class_num = $classNum",
				@params: new { classGrade, classNum });
	}
}
