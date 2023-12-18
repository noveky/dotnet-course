using SchoolDataSystem.Models;

namespace SchoolDataSystem
{
	public partial class MainForm : Form
	{
		IEnumerable<School>? schools;
		IEnumerable<Class>? classes;
		IEnumerable<Student>? students;

		School? school;
		Class? @class;

		public MainForm()
		{
			InitializeComponent();

			cboSchools.DataSource = schools;
			cboSchools.SelectedValueChanged += (_, _) =>
			{
				school = cboSchools.SelectedValue as School;
				UpdateClasses();
			};

			lstClasses.MultiSelect = false;
			lstClasses.SelectedIndexChanged += (_, _) =>
			{
				@class = ((IEnumerable<ListViewItem>)lstClasses.SelectedItems).FirstOrDefault()?.Tag as Class;
				UpdateStudents();
			};

			lstStudents.MultiSelect = false;
		}

		void UpdateClasses()
		{
			if (school is not null)
			{
				classes = Class.Query(null, null, school.Id);
			}
			lstClasses.Items.Clear();
			lstClasses.Items.AddRange(classes?.Select(c => new ListViewItem(c.ToString()) { Tag = c }).ToArray());

			UpdateStudents();
		}

		void UpdateStudents()
		{
			if (@class is not null)
			{
				students = Student.Query(null, @class.Grade, @class.Num);
			}
			lstStudents.Items.Clear();
			lstStudents.Items.AddRange(students?.Select(s => new ListViewItem(s.ToString())).ToArray());
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			schools = School.Query();
		}
	}
}