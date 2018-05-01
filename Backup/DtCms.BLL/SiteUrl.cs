using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Web;
using System.Web.Caching;

namespace DtCms.BLL
{
    public class SiteUrl
    {
        private readonly DtCms.DAL.SiteUrl dal = new DtCms.DAL.SiteUrl();

        public Hashtable loadConfig(string urlFilePath)
        {
            //从缓存中根据键读取，并使用as转换
            Hashtable Cache_Siteurl = HttpContext.Current.Cache["Cache_Siteurl"] as Hashtable;
            if (Cache_Siteurl == null)
            {
                //创建缓存依赖项
                CacheDependency dependency = new CacheDependency(urlFilePath);
                //创建缓存
                HttpContext.Current.Cache.Add("Cache_Siteurl", dal.loadConfig(urlFilePath), dependency, Cache.NoAbsoluteExpiration, new TimeSpan(0, 30, 0), CacheItemPriority.Default, null);
                Cache_Siteurl = HttpContext.Current.Cache["Cache_Siteurl"] as Hashtable;
            }

            return Cache_Siteurl;
        }
    }
}
