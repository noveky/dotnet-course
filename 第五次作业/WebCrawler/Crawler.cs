using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Policy;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace WebCrawler
{
	partial class Crawler
	{
		public event Action OnUpdate = () => { };

		public List<(string MatchStr, string SrcUrl)> Matches = new();
		public List<string> CrawledUrls = new();

		public string UrlPrefix, Keywords;
		public string RegexPattern;

		public Crawler(string urlPrefix, string keywords, string regex)
		{
			UrlPrefix = urlPrefix;
			Keywords = keywords;
			RegexPattern = regex;
		}

		public async Task Launch()
		{
			HttpClient httpClient = new();
			string html = await httpClient.GetStringAsync($"{UrlPrefix}{Keywords}");
			var urls = HtmlUrlRegex().Matches(html).Select(m => m.Value);
			foreach (string url in urls)
			{
				Crawl(url);
			}
		}

		public async void Crawl(string url)
		{
			HttpClient httpClient = new();
			string html = await httpClient.GetStringAsync(url);
			Regex.Matches(html, RegexPattern)
				.Select(m => m.Value)
				.ToList()
				.ForEach(s => Matches.Add((MatchStr: s, SrcUrl: url)));
			CrawledUrls.Add(url);
		}

		[GeneratedRegex("(?<=<a href=\").+(?=\")")]
		private static partial Regex HtmlUrlRegex();
	}
}
