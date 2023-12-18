using SchoolDataSystem.Repository;
using System.Dynamic;

namespace SchoolDataSystem.Models
{
	public partial class Student
	{
		public static Student? GetEntity(string? studentId)
			=> studentId is null ? null : Query(studentId, null, null).FirstOrDefault();

		public static IEnumerable<Student> Query(string? studentId = null, int? classGrade = null, int? classNum = null)
		{
			List<string> selectList = new() { "student.*", "student_class.*" },
				fromList = new()
				{
					"student",
					"LEFT OUTER JOIN student student_class ON student.student_class_grade = student_class.class_grade AND student.student_class_num = student_class.class_num",
				},
				whereList = new() { };
			dynamic @params = new ExpandoObject();

			if (studentId is not null)
			{
				whereList.Add("student.student_id = $studentId");
				@params.studentId = studentId;
			}
			if (classGrade is not null)
			{
				whereList.Add("student.student_class_grade = $classGrade");
				@params.classGrade = classGrade;
			}
			if (classNum is not null)
			{
				whereList.Add("student.student_class_num = $classNum");
				@params.classNum = classNum;
			}

			return (Sql.Select(selectList, from: fromList, where: whereList, @params: @params)
				as IEnumerable<Sql.Row>)!
				.Select(FromData);
		}

		public static void Add(string studentId, string studentName, int studentClassGrade, int studentClassNum) =>
			Sql.Insert(into: "student",
				fields: "student_id, student_name, student_class_grade, student_class_num",
				values: "$studentId, $studentName, $studentClassGrade, $studentClassNum",
				@params: new { studentId, studentName, studentClassGrade, studentClassNum });

		public static void Remove(string studentId) =>
			Sql.Delete(from: "student",
				where: "student.student_id = $studentId",
				@params: new { studentId });
	}
}
