using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWPF.Crawler
{
    public class CrawlerServices
    {
        public string getCrawlerParameter(CrawlerObject crawlerObject)
        {
            StringBuilder getData = new StringBuilder("/");
            getData.Append("searchType=NORMAL");
            getData.Append("&lang=vt");
            return getData.ToString();
        }
    }
}
