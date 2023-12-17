using System.Text.RegularExpressions;

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
			public static List<SearchEngine> SearchEngines = new();
			public static SearchEngine Bing = new("Bing", "https://www.bing.com/search?q={0}");
			public static SearchEngine Google = new("Google", "https://www.google.com/search?q={0}");
			public static SearchEngine Baidu = new("Baidu", "https://www.baidu.com/s?wd={0}");

			public string Name => ToString();
			public string UrlFormat => (string)Tag!;

			public SearchEngine(string name, string urlPrefix)
			{
				Text = name;
				Tag = urlPrefix;
				SearchEngines.Add(this);
			}
		}

		class Pattern : ComboBoxItem
		{
			public static List<Pattern> Patterns = new();
			public static Pattern Custom = new("自定义", string.Empty);
			public static Pattern PhoneNumber = new("电话号码", @"(0\d{2,3}-\d{7,8})|(400[\d\-]{7,9})|(1[3-9]\d-\d{4}-\d{4})|(1[3-9]\d{9})");
			public static Pattern EmailAddr = new("Email 地址", @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
			public static Pattern IPv4Addr = new("IPv4 地址", @"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
			public static Pattern Date = new("有效日期", @"(([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})-(((0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)-(0[1-9]|[12][0-9]|30))|(02-(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))-02-29)");

			public string Name => ToString();
			public string Regex => (string)Tag!;

			public Pattern(string name, string regex)
			{
				Text = name;
				Tag = regex;
				Patterns.Add(this);
			}
		}

		SearchEngine CurrentEngine => (SearchEngine)cboSearchEngine.SelectedItem;

		Crawler? crawler;

		public MainForm()
		{
			InitializeComponent();

			cboSearchEngine.Items.AddRange(SearchEngine.SearchEngines.ToArray());
			cboPattern.Items.AddRange(Pattern.Patterns.ToArray());

			cboSearchEngine.SelectedIndex = 0;
			cboPattern.SelectedIndex = 0;
		}

		async Task Start()
		{
			crawler = new(CurrentEngine.UrlFormat, txtKeywords.Text, txtRegex.Text, 100, 100);
			crawler.Matched += AddMatchItem;
			crawler.CrawledUrl += AddCrawledUrlItem;
			UpdateDisplay(true, true);
			try
			{
				await crawler.Launch();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			UpdateDisplay();
			crawler = null;
			UpdateDisplay();
		}

		void AddMatchItem(string matchStr, string srcUrl)
		{
			ListViewItem matchItem = new(matchStr);
			matchItem.SubItems.Add(srcUrl);
			lstMatches.Items.Add(matchItem);
		}

		void AddCrawledUrlItem(string url)
		{
			lstCrawledUrls.Items.Add(url);
		}

		void UpdateDisplay(bool regenerateMatchItems = false, bool regenerateCrawledUrlItems = false)
		{
			btnStart.Enabled = crawler == null;
			btnStart.Text = crawler == null ? "开始" : "运行中";

			if (crawler == null) return;

			if (regenerateMatchItems)
			{
				lstMatches.EndUpdate();
				lstMatches.BeginUpdate();
				lstMatches.Items.Clear();
				foreach (var match in crawler.Matches)
				{
					ListViewItem matchItem = new(match.MatchStr);
					matchItem.SubItems.Add(match.SrcUrl);
					lstMatches.Items.Add(matchItem);
				}
				lstMatches.EndUpdate();
			}

			if (regenerateCrawledUrlItems)
			{
				lstCrawledUrls.EndUpdate();
				lstCrawledUrls.BeginUpdate();
				lstCrawledUrls.Items.Clear();
				foreach (string url in crawler.CrawledUrls)
				{
					lstCrawledUrls.Items.Add(url);
				}
				lstCrawledUrls.EndUpdate();
			}
		}

		private void cboPattern_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cboPattern.SelectedItem is Pattern pattern)
			{
				txtRegex.Text = pattern.Regex;
				txtRegex.ReadOnly = pattern != Pattern.Custom;
			}
		}

		private async void btnStart_Click(object sender, EventArgs e)
		{
			await Start();
		}
	}
}