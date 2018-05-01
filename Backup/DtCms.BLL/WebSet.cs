using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Web.Caching;
using cmsDal = DtCms.DAL;
using cmsModel = DtCms.Model;

namespace DtCms.BLL
{
    public class WebSet
    {
        private readonly cmsDal.WebSet dal = new cmsDal.WebSet();

        /// <summary>
        ///  读取配置文件
        /// </summary>
        /// <param name="configFilePath"></param>
        /// <returns></returns>
        public cmsModel.WebSet loadConfig(string configFilePath)
        {
            //从缓存中根据键读取，并使用as转换
            cmsModel.WebSet Cache_Webset = HttpContext.Current.Cache["Cache_Webset"] as cmsModel.WebSet;
            if (Cache_Webset == null)
            {
                //创建缓存依赖项
                CacheDependency dependency = new CacheDependency(configFilePath);
                //创建缓存
                HttpContext.Current.Cache.Add("Cache_Webset", dal.loadConfig(configFilePath), dependency, Cache.NoAbsoluteExpiration, new TimeSpan(0, 30, 0), CacheItemPriority.Default, null);
                Cache_Webset = HttpContext.Current.Cache["Cache_Webset"] as cmsModel.WebSet;
            }

            return Cache_Webset;
        }

        /// <summary>
        ///  保存配置文件
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="configFilePath"></param>
        /// <returns></returns>
        public cmsModel.WebSet saveConifg(cmsModel.WebSet mode, string configFilePath)
        {
            return dal.saveConifg(mode, configFilePath);
        }

    }
}
