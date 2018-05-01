using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace DtCms.Common
{
    /// <summary>
    /// Template为页面模板类.
    /// </summary>
    public abstract class PageTemplate
    {
        public static Regex[] r = new Regex[1];

        static PageTemplate()
        {
            RegexOptions options = RegexOptions.None;
            r[0] = new Regex(@"<%template src=/([^\[\]\{\}\s]+)/%>", options);
        }

        /// <summary>
        /// 获得模板字符串，从设置中的模板路径来读取模板文件.
        /// </summary>
        /// <param name="sitePath">站点目录</param>
        /// <param name="skinName">模板名</param>
        /// <param name="templateName">模板文件的文件名称</param>
        /// <param name="nest">嵌套次数</param>
        /// <returns>string值,如果失败则为"",成功则为模板内容的string</returns>
        public static string GetTemplate(string sitePath, string skinName, string templateName, int nest)
        {
            StringBuilder strReturn = new StringBuilder(220000); //返回的字符
            string tempPath = sitePath + "templates";
            string pathFormatStr = "{0}\\{1}\\{2}"; //模板文件路径匹配格式
            string createFilePath; //模板文件物理路径

            //超过5次嵌套退出
            if (nest < 1)
            {
                nest = 1;
            }
            else if (nest > 5)
            {
                return "";
            }
            //检查模板文件是否存在
            if (!File.Exists(string.Format(pathFormatStr, Utils.GetMapPath(tempPath), skinName, templateName)))
            {
                return "";
            }
            //取得模板文件物理路径
            createFilePath = string.Format(pathFormatStr, Utils.GetMapPath(tempPath), skinName, templateName);

            //开始读写文件
            using (StreamReader objReader = new StreamReader(createFilePath, Encoding.UTF8))
            {
                StringBuilder textOutput = new StringBuilder(70000);
                textOutput.Append(objReader.ReadToEnd());
                objReader.Close();

                //头部声明
                if (nest == 1)
                {
                    string codebehind = templateName.Substring(0, templateName.LastIndexOf(".")) + ".aspx.cs"; //CS文件名
                    string inherits = "DtCms.Web." + templateName.Substring(0, templateName.LastIndexOf("."));
                    string headerTemplate = string.Format("<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"{0}\" Inherits=\"{1}\" ValidateRequest=\"false\" %>\r\n<%@ Import namespace=\"DtCms.Common\" %>\r\n<%@ Register TagPrefix=\"DtContorl\" Namespace=\"DtCms.Web.UI\" Assembly=\"DtCms.Web.UI\" %>\r\n", codebehind, inherits);
                    strReturn.Append(headerTemplate);
                }
                //替换标签
                strReturn.Append(ConvertTags(nest, sitePath, skinName, textOutput.ToString()));
                //写入文件
                if (nest == 1)
                {
                    strReturn.Append("\r\n<!-- 本页面代码由DTCMS模板引擎生成于 " + DateTime.Now + " -->");
                    string pageDir = Utils.GetMapPath(sitePath + "Aspx/");
                    if (!Directory.Exists(pageDir))
                        Directory.CreateDirectory(pageDir);
                    string outputPath = pageDir + templateName.Substring(0, templateName.LastIndexOf(".")) + ".aspx";
                    //using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                    //{
                    //    Byte[] info = Encoding.UTF8.GetBytes(strReturn.ToString());
                    //    fs.Write(info, 0, info.Length);
                    //    fs.Close();
                    //}
                    File.WriteAllText(outputPath, strReturn.ToString(), Encoding.UTF8);
                }
            }

            return strReturn.ToString();
        }

        /// <summary>
        /// 转换标签
        /// </summary>
        /// <param name="nest">深度</param>
        /// <param name="sitePath">站点目录</param>
        /// <param name="skinName">模板名称</param>
        /// <param name="inputStr">模板内容</param>
        /// <returns></returns>
        private static string ConvertTags(int nest, string sitePath, string skinName, string inputStr)
        {
            string strReturn = "";
            string strTemplate = inputStr;

            foreach (Match m in r[0].Matches(strTemplate))
            {
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(), "\r\n" + GetTemplate(sitePath, skinName, m.Groups[1].ToString(), nest + 1) + "\r\n");
            }

            strReturn = strTemplate;
            return strReturn;
        }

    }
}