using SchoolDataSystem.Repository;

namespace SchoolDataSystem.Models
{
	public partial class School
	{
		public Guid? Id { get; set; }
		public string? Name { get; set; }

		public static School FromData(Sql.Row row)
		{
			var id = (Guid?)row["school_id"];
			var name = (string?)row["school_name"];

			return new School { Id = id, Name = name };
		}
	}

	public partial class Class
	{
		public int? Grade { get; set; }
		public int? Num { get; set; }
		public School? School { get; set; }

		public static Class FromData(Sql.Row row)
		{
			var grade = (int?)row["class_grade"];
			var num = (int?)row["class_num"];
			var school = School.FromData(row);

			return new Class { Grade = grade, Num = num, School = school };
		}
	}

	public partial class Student
	{
		public string? Id { get; set; }
		public string? Name { get; set; }
		public Class? Class { get; set; }

		public static Student FromData(Sql.Row row)
		{
			var id = (string?)row["student_id"];
			var name = (string?)row["student_name"];
			var @class = Class.FromData(row);

			return new Student { Id = id, Name = name, Class = @class };
		}
	}
}
