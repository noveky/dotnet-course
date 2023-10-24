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
			public static SearchEngine Google = new("Google", "https://www.google.com/search?q=");
			public static SearchEngine Bing = new("Bing", "https://www.bing.com/search?q=");
			public static SearchEngine Baidu = new("Baidu", "https://www.baidu.com/s?wd=");

			public string Name => ToString();
			public string UrlPrefix => (string)Tag!;

			public SearchEngine(string name, string urlPrefix)
			{
				Text = name;
				Tag = urlPrefix;
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

		Crawler? crawler;

		public MainForm()
		{
			InitializeComponent();

			cboSearchEngine.Items.AddRange(new[] { SearchEngine.Google, SearchEngine.Bing, SearchEngine.Baidu });
			cboPattern.Items.AddRange(new[] { Pattern.Custom, Pattern.PhoneNumber });

			cboSearchEngine.SelectedIndex = 0;
			cboPattern.SelectedIndex = 0;
		}

		async void Start()
		{
			crawler = new(CurrentEngine.UrlPrefix, txtKeywords.Text, txtRegex.Text);
			await crawler.Launch();
			btnStart.Enabled = true;
			btnStart.Text = "开始";
		}

		void UpdateLists()
		{
			lstMatches.EndUpdate();
			lstMatches.BeginUpdate();
			lstMatches.Items.Clear();
			foreach (var match in crawler!.Matches)
			{
				ListViewItem matchItem = new(match.MatchStr);
				matchItem.SubItems.Add(match.SrcUrl);
				lstMatches.Items.Add(matchItem);
			}
			lstMatches.EndUpdate();

			lstCrawledUrls.EndUpdate();
			lstCrawledUrls.BeginUpdate();
			lstCrawledUrls.Items.Clear();
			foreach (string url in crawler.CrawledUrls)
			{
				lstMatches.Items.Add(url);
			}
			lstCrawledUrls.EndUpdate();
		}

		private void cboPattern_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cboPattern.SelectedItem is Pattern pattern)
			{
				txtRegex.Text = pattern.Regex;
				txtRegex.ReadOnly = pattern != Pattern.Custom;
			}
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			btnStart.Enabled = false;
			btnStart.Text = "运行中";
			Start();
		}
	}
}