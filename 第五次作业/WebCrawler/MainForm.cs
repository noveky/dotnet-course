namespace WebCrawler
{
	public partial class MainForm : Form
	{
		class ComboBoxItem
		{
			public string? Text { get; set; }
			public object? Tag { get; set; }

			public ComboBoxItem(string? text = null, object? tag = null)
			{
				Text = text;
				Tag = tag;
			}

			public override string ToString() => Text ?? string.Empty;
		}

		class SearchEngine : ComboBoxItem
		{
			public static SearchEngine Google = new("Google", "https://www.google.com/");
			public static SearchEngine Bing = new("Bing", "https://www.bing.com/");
			public static SearchEngine Baidu = new("Baidu", "https://www.baidu.com/");

			public string Name => ToString();
			public string Url => (string)Tag!;

			public SearchEngine(string name, string url)
			{
				Text = name;
				Tag = url;
			}
		}

		class Pattern : ComboBoxItem
		{
			public static Pattern Custom = new("自定义", string.Empty);
			public static Pattern PhoneNumber = new("电话号码", @"/^(?:((0\d{2,3}-)|(400))?\d{7,8}|1[3-9]\d{9})$/");

			public string Name => ToString();
			public string Regex => (string)Tag!;

			public Pattern(string name, string regex)
			{
				Text = name;
				Tag = regex;
			}
		}

		SearchEngine CurrentEngine => (SearchEngine)cboSearchEngine.SelectedItem;

		public MainForm()
		{
			InitializeComponent();

			cboSearchEngine.Items.AddRange(new[] { SearchEngine.Google, SearchEngine.Bing, SearchEngine.Baidu });
			cboPattern.Items.AddRange(new[] { Pattern.Custom, Pattern.PhoneNumber });

			cboSearchEngine.SelectedIndex = 0;
			cboPattern.SelectedIndex = 0;
		}

		private void cboPattern_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cboPattern.SelectedItem is Pattern pattern)
			{
				txtRegex.Text = pattern.Regex;
				txtRegex.ReadOnly = pattern != Pattern.Custom;
			}
		}
	}
}