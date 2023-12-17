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
		public event Action<string, string> Matched = (_, __) => { };
		public event Action<string> CrawledUrl = _ => { };

		public List<(string MatchStr, string SrcUrl)> Matches = new();
		public HashSet<string> MatchSet = new();
		public List<string> CrawledUrls = new();
		public HashSet<string> CrawledUrlSet = new();

		public string UrlFormat, Keywords, RegexPattern;
		public int MaxUrlCount, MaxMatchCount;

		public HttpClient httpClient = new();

		public Crawler(string urlFormat, string keywords, string regex, int maxUrlCount, int maxMatchCount)
		{
			UrlFormat = urlFormat;
			Keywords = keywords;
			RegexPattern = regex;
			MaxUrlCount = maxUrlCount;
			MaxMatchCount = maxMatchCount;

			httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Safari/537.36 Edg/119.0.0.0");
			httpClient.DefaultRequestHeaders.Add("Cookie", "_EDGE_V=1; SRCHD=AF=NOFORM; SRCHUID=V=2&GUID=DD6E8C4463104BFD859E7892EC64BAC8&dmnchg=1; SnrOvr=X=rebateson; MMCASM=ID=5A491CCBB07D41A29E089D052BD56A66; _tarLang=default=zh-Hans; _TTSS_IN=hist=WyJlbiIsImF1dG8tZGV0ZWN0Il0=&isADRU=0; _TTSS_OUT=hist=WyJ6aC1IYW5zIl0=; ANON=A=613928F5EA3A56476226C7D6FFFFFFFF&E=1cc5&W=1; PPLState=1; KievRPSSecAuth=FABSBBRaTOJILtFsMkpLVWSG6AN6C/svRwNmAAAEgAAACLXMPBEPiM2fEASNKMvbL/VqnNDGRfCQ2TTdK5dMjArjeqcG/IfQavIhXxLGQuFbc8wNUAYKR6W+rW6aXvoDjEXp9TTWv3CTRnU78fIr9xpLp6JLUpMDD4/ycg8DqKeA3y++xn5RselQXf67nfNmnz7LxDOu2njlcuys763WAWrmJtVBml5mq+WhcA8FOYwTOqJ/Jk5fhK9OVUUHNVDfn+3r+0p3yeL5BjBTmrWymJjEIFQk3twFsjLURRQBmseZTK0Zo0yT/Scpb9/HgcsqPVLG9CpMvZYzZIU5NOhCrEWejce91OM4XOTHNc9srzwcK6fJyXwky1B1cxmOY7xP7LhhZ/sSN5TkzadjtJnxxmdkO1v+odPPLqZRd0vLLrMcZQNBx4ZchczFVoQZHWVKxNI5wez32Z1oGOFx3pIB2mEUsgSULsaQqQCXRwLWtk7Gmbrb8f8+42kRET6Uh/86GEOr38ypeG4ff+edwtiktzmyhC7e1xK1Ax06dS4bu2B0N0Jl6jEQ4mtl7iBREK05J/cJPOSK6svu4F9L0gxmKgDmElHmIbKlFc2bWsEfmSPWEZkjImhr+x0sHastWEPjbAdii6E4e/bRfQcTLoiR5kum8E4bQURaptX/Sm+oF/i/L0Cpon2UdKxVu8ZdqguReNMso9hFwXjUVVLC5I3MDUK5v6fyIE/e5gkVk2i3//2D2HJdZWsubjlxrbVl8Tw2/hWYYM4pV1bUMfp7zzXQwDJ70UaztnijA7gK+1Ph7jRJAzTZJ4Wr4vCMR1zJiKvQVuSXnt+w3O7ujnU/sAOBAuJy3apxnYzBn67r9z3Ysmi6oleztdLu5sGkcxgrGAixfw1/iiJSLUvrBX50YTR9xkfewChcjL4YIrcB98a6dRk6AwvKp9TNF3bPoAKYCkKIUqoBk1CAlELxfSD3mtUwmyxZHONDxO4Kxf3akYfGO2rdb970hD3CGpfUtXhOr2qtZoaTcG6gUZjmlG/f0Y407izKRLfTKNglmTFmvZDnmyhvwR673fecVSxd50qe0i2p632PWAIXWSwwtjCGG7MJ09/Ezq35LrWdmWKrNlTJ9QmvKWqB9X0Hs1K6nebu1kSKfknaVQPboCxU+EP4TxFXjXvceeK+W95UGrAzxLHH1UvcDF5E1qV/Hr6x4vu+xOk98WX2wuHpYohzUjgl321KsiGUs43b7HKhjY8det5aPT1rFZ7eotoWmRbvfIxloEqUTqL68fyxmV8UeRsZLsaLTXBeOO4OKyyk7SyAk2AM9Xyi8HjJqcrV+/Mh8+6s2mdK0Fey193Lu3LYmtv90QN5NW/d5FK7W0k5MsFe6iLV3739GuKDlX53k8ADJ65jsb9g2OYWZVDN+BhpTBLUHcKCf4+k8Z1fX2PQ6bqrAhQAhhEkBXUehEI3QjtaSsbI2Z1jOac=; ANIMIA=FRE=1; WLS=C=10263a0f01628d7a&N=%e9%a9%80; SRCHS=PC=DCTS; _Rwho=u=d; _SS=SID=3AA46F001045688B3B977C9211066938&PC=DCTS&R=1459&RB=1459&GB=0&RG=0&RP=1459; _UR=QS=0&TQS=0; ABDEF=V=13&ABDV=13&MRB=0&MRNB=1697539330367; SNRHOP=I=&TS=; BFPRResults=FirstPageUrls=22E8CBB1C2514240B7CBF97E193E9210%2C953EB43C227200E0605A4A1E04239B74%2C93C3B103C715ACCCDA0EC6439E587CD8%2C7C60E5B768807235BF04ABF2E034232C%2C4A780B1853CAF546BC935C78D8809851%2C079D6B72D323B684D9DB99F41C176709%2CDDBAE26D02FE22E8F57470F643C58428%2CD9A79F6B24754C8BC9282CC9B543A815%2CE2E17E02EC73DE488200D4739B6B66F3%2CBC3ABDE305FD642D94F93CB91F7A7F42&FPIG=75AD580A0F1B4311B079EBE5F84C8530; MUID=0864B9B4BFEE6F340300AA04BE9B6EE6; MUIDB=0864B9B4BFEE6F340300AA04BE9B6EE6; USRLOC=HS=1&ELOC=LAT=30.524023056030273|LON=114.34675598144531|N=%E6%B4%AA%E5%B1%B1%E5%8C%BA%EF%BC%8C%E6%B9%96%E5%8C%97%E7%9C%81|ELT=2|&CLOC=LAT=30.524023166823238|LON=114.34675762567021|A=733.4464586120832|TS=231019141501|SRC=W; _HPVN=CS=eyJQbiI6eyJDbiI6NywiU3QiOjAsIlFzIjowLCJQcm9kIjoiUCJ9LCJTYyI6eyJDbiI6NywiU3QiOjAsIlFzIjowLCJQcm9kIjoiSCJ9LCJReiI6eyJDbiI6NywiU3QiOjAsIlFzIjowLCJQcm9kIjoiVCJ9LCJBcCI6dHJ1ZSwiTXV0ZSI6dHJ1ZSwiTGFkIjoiMjAyMy0xMC0yMFQwMDowMDowMFoiLCJJb3RkIjowLCJHd2IiOjAsIkRmdCI6bnVsbCwiTXZzIjowLCJGbHQiOjAsIkltcCI6MTd9; _EDGE_S=SID=3AA46F001045688B3B977C9211066938&mkt=zh-cn; ipv6=hit=1697787941821&t=4; _U=1HHb2zlTMs0FbnjFM8cI3Kunu8Vsej7vvM-JjRVnU_sKA6jzWlG0BrHvLyYVb7ERuhxP_rgtiQCq_HoGQqHRnK7USTjTdFtp2kCng74ttfd3ogy7u4KjA3DDREUR6e5nYhkRrpIqsTKw2yrQRPsjTpgJ3B9nJbq3WyX3erA1dr-WRgYzwn6Uq-HkEYkyk0u0ex6wfPClyvZBlyCB90eXkQg; SRCHUSR=DOB=20230716&T=1697788160000; _RwBf=r=1&mta=0&rc=1459&rb=1459&gb=0&rg=0&pc=1459&mtu=0&rbb=0.0&g=0&cid=&clo=0&v=1&l=2023-10-20T07:00:00.0000000Z&lft=0001-01-01T00:00:00.0000000&aof=0&o=0&p=BINGCOPILOTWAITLIST&c=MR000T&t=3991&s=2023-03-11T10:30:16.1288195+00:00&ts=2023-10-20T07:49:24.9438227+00:00&rwred=0&wls=1&lka=0&lkt=0&TH=&dci=0&e=m2qxEiUYdd-WOxufX_Ofas_0xSCWVf9TJfVix9xV2SfRHB_eCw6sdf8dpoqSn42G6ZiOfEpH3-f7TdSaZ3wn2Q&A=&wlb=2&aad=0; SRCHHPGUSR=SRCHLANG=zh-Hans&PV=15.0.0&BZA=0&HV=1697788166&BRW=NOTP&BRH=M&CW=866&CH=791&SCW=1164&SCH=1802&DPR=1.3&UTC=480&DM=1&EXLTT=31&PRVCW=1482&PRVCH=791&IG=C0281479B7D74102B3AF6249A9E4DB4B&DESKDMOPTINTS=1695198511735&DESKDMOPTINCT=1");
		}

		public async Task Launch()
		{
			string html = await httpClient.GetStringAsync(string.Format(UrlFormat, Keywords));
			var urls = HtmlUrlRegex().Matches(html).Select(m => m.Value);
			List<Task> tasks = new();
			foreach (string url in urls)
			{
				if (tasks.Count >= MaxUrlCount || Matches.Count >= MaxMatchCount) break;
				tasks.Add(Crawl(url));
			}
			await Task.WhenAll(tasks);
		}

		public async Task Crawl(string url)
		{
			if (CrawledUrlSet.Contains(url)) return;
			try
			{
				HttpClient httpClient = new();
				string html = await httpClient.GetStringAsync(url);
				Parse(html, url);

				bool flag = false;
				lock (CrawledUrlSet)
				{
					if (!CrawledUrlSet.Contains(url))
					{
						CrawledUrls.Add(url);
						CrawledUrlSet.Add(url);
						flag = true;
					}
				}
				if (flag) CrawledUrl.Invoke(url);
			}
			catch { }
		}

		public void Parse(string html, string srcUrl)
		{
			Regex.Matches(html, RegexPattern)
				.Select(m => m.Value)
				.ToList()
				.ForEach(s =>
				{
					bool flag = false;
					lock (MatchSet)
					{
						if (Matches.Count < MaxMatchCount && !MatchSet.Contains(s))
						{
							Matches.Add((MatchStr: s, SrcUrl: srcUrl));
							MatchSet.Add(s);
							flag = true;
						}
					}
					if (flag) Matched.Invoke(s, srcUrl);
				});
		}

		[GeneratedRegex("(?<=(href|HREF)=\")[^\"]+")]
		private static partial Regex HtmlUrlRegex();
	}
}
