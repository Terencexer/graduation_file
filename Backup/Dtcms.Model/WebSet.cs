using System;
using System.Collections.Generic;
using System.Text;

namespace DtCms.Model
{
    public class WebSet
    {
        private string _webname = "";
        private string _weburl = "";
        private string _webtel = "";
        private string _webfax = "";
        private string _webemail = "";
        private string _webcrod = "";
        private string _webkeywords = "";
        private string _webdescription = "";
        private string _webcopyright = "";

        private string _webpath = "";
        private string _webmanagepath = "";
        private string _webfilepath = "";
        private string _webfiletype = "";
        private int _webfilesize = 0;
        private int _weblogstatus = 0;
        private string _webkillkeywords = "";
        private int _isurlrewrite = 0;
        private int _ischeckfeedback = 0;
        private int _ischeckcomment = 0;

        private int _articlepagenum = 15;
        private int _picturepagenum = 14;
        private int _downpagenum = 15;
        private int _contentpagenum = 15;
        private int _feedbackpagenum = 15;
        private int _linkpagenum = 15;
        private int _commentpagenum = 10;
        private int _adpagenum = 15;
        private int _logpagenum = 15;
        private int _managepagenum = 15;
        private int _articlepagenum_client = 20;
        private int _picturepagenum_client = 20;
        private int _downpagenum_client = 20;
        private int _feedbackpagenum_client = 20;
        private int _commentpagenum_client = 20;

        private int _isthumbnail = 0;
        private int _prowidth = 0;
        private int _prohight = 0;
        private int _iswatermark = 0;
        private int _watermarkstatus = 0;
        private int _imgquality = 80;
        private string _imgwaterpath = "";
        private int _imgwatertransparency = 0;
        private string _watertext = "";
        private string _waterfont = "";
        private int _fontsize = 12;

        private string _templateskin = "default";

        /// <summary>
        ///  网站名称
        /// </summary>
        public string WebName
        {
            set { _webname = value; }
            get { return _webname; }
        }

        /// <summary>
        ///  网站地址
        /// </summary>
        public string WebUrl
        {
            set { _weburl = value; }
            get { return _weburl; }
        }

        /// <summary>
        ///  联系电话
        /// </summary>
        public string WebTel
        {
            set { _webtel = value; }
            get { return _webtel; }
        }

        /// <summary>
        ///  传真地址
        /// </summary>
        public string WebFax
        {
            set { _webfax = value; }
            get { return _webfax; }
        }

        /// <summary>
        ///  联系邮箱
        /// </summary>
        public string WebEmail
        {
            set { _webemail = value; }
            get { return _webemail; }
        }

        /// <summary>
        ///  ICP备案
        /// </summary>
        public string WebCrod
        {
            set { _webcrod = value; }
            get { return _webcrod; }
        }

        /// <summary>
        /// 网站关健字
        /// </summary>
        public string WebKeywords
        {
            set { _webkeywords = value; }
            get { return _webkeywords; }
        }

        /// <summary>
        ///  网站描述
        /// </summary>
        public string WebDescription
        {
            set { _webdescription = value; }
            get { return _webdescription; }
        }

        /// <summary>
        ///  公司版权
        /// </summary>
        public string WebCopyright
        {
            set { _webcopyright = value; }
            get { return _webcopyright; }
        }

        //=========================================================================

        /// <summary>
        ///  网站路径
        /// </summary>
        public string WebPath
        {
            set { _webpath = value; }
            get { return _webpath; }
        }

        /// <summary>
        ///  管理目录
        /// </summary>
        public string WebManagePath
        {
            set { _webmanagepath = value; }
            get { return _webmanagepath; }
        }

        /// <summary>
        /// 文件上传目录
        /// </summary>
        public string WebFilePath
        {
            set { _webfilepath = value; }
            get { return _webfilepath; }
        }

        /// <summary>
        /// 允许文件上传类型
        /// </summary>
        public string WebFileType
        {
            set { _webfiletype = value; }
            get { return _webfiletype; }
        }

        /// <summary>
        /// 允许文件上传大小
        /// </summary>
        public int WebFileSize
        {
            set { _webfilesize = value; }
            get { return _webfilesize; }
        }

        /// <summary>
        /// 管理日志状态
        /// </summary>
        public int WebLogStatus
        {
            set { _weblogstatus = value; }
            get { return _weblogstatus; }
        }

        /// <summary>
        ///  SQL注入过滤
        /// </summary>
        public string WebKillKeywords
        {
            set { _webkillkeywords = value; }
            get { return _webkillkeywords; }
        }

        /// <summary>
        /// 是否开户伪静态
        /// </summary>
        public int IsUrlRewrite
        {
            get { return _isurlrewrite; }
            set { _isurlrewrite = value; }
        }

        /// <summary>
        /// 留言是否需要审核
        /// </summary>
        public int IsCheckFeedback
        {
            get { return _ischeckfeedback; }
            set { _ischeckfeedback = value; }
        }

        /// <summary>
        /// 评论是否需要审核
        /// </summary>
        public int IsCheckComment
        {
            get { return _ischeckcomment; }
            set { _ischeckcomment = value; }
        }

        //==================================================================================

        /// <summary>
        /// 资讯分页数量
        /// </summary>
        public int ArticlePageNum
        {
            set { _articlepagenum = value; }
            get { return _articlepagenum; }
        }

        /// <summary>
        /// 图文分页数量
        /// </summary>
        public int PicturePageNum
        {
            set { _picturepagenum = value; }
            get { return _picturepagenum; }
        }

        /// <summary>
        /// 下载分页数量
        /// </summary>
        public int DownPageNum
        {
            set { _downpagenum = value; }
            get { return _downpagenum; }
        }

        /// <summary>
        /// 内容分页数量
        /// </summary>
        public int ContentPageNum
        {
            set { _contentpagenum = value; }
            get { return _contentpagenum; }
        }

        /// <summary>
        /// 留言分页数量
        /// </summary>
        public int FeedbackPageNum
        {
            set { _feedbackpagenum = value; }
            get { return _feedbackpagenum; }
        }

        /// <summary>
        /// 链接分页数量
        /// </summary>
        public int LinkPageNum
        {
            set { _linkpagenum = value; }
            get { return _linkpagenum; }
        }

        /// <summary>
        /// 评论分页数量
        /// </summary>
        public int CommentPageNum
        {
            set { _commentpagenum = value; }
            get { return _commentpagenum; }
        }

        /// <summary>
        /// 广告分页数量
        /// </summary>
        public int AdPageNum
        {
            set { _adpagenum = value; }
            get { return _adpagenum; }
        }

        /// <summary>
        /// 日志分页数量
        /// </summary>
        public int LogPageNum
        {
            set { _logpagenum = value; }
            get { return _logpagenum; }
        }

        /// <summary>
        /// 管理员分页数量
        /// </summary>
        public int ManagePageNum
        {
            set { _managepagenum = value; }
            get { return _managepagenum; }
        }

        /// <summary>
        /// 前台资讯分页数量
        /// </summary>
        public int ArticlePageNum_Client
        {
            set { _articlepagenum_client = value; }
            get { return _articlepagenum_client; }
        }

        /// <summary>
        /// 前台图文分页数量
        /// </summary>
        public int PicturePageNum_Client
        {
            set { _picturepagenum_client = value; }
            get { return _picturepagenum_client; }
        }

        /// <summary>
        /// 前台下载分页数量
        /// </summary>
        public int DownPageNum_Client
        {
            set { _downpagenum_client = value; }
            get { return _downpagenum_client; }
        }

        /// <summary>
        /// 前台留言分页数量
        /// </summary>
        public int FeedbackPageNum_Client
        {
            set { _feedbackpagenum_client = value; }
            get { return _feedbackpagenum_client; }
        }

        /// <summary>
        /// 前台评论分页数量
        /// </summary>
        public int CommentPageNum_Client
        {
            set { _commentpagenum_client = value; }
            get { return _commentpagenum_client; }
        }

        //===================================================================================

        /// <summary>
        /// 是否生成图文缩略图
        /// </summary>
        public int IsThumbnail
        {
            set { _isthumbnail = value; }
            get { return _isthumbnail; }
        }

        /// <summary>
        /// 图文缩略图宽
        /// </summary>
        public int ProWidth
        {
            set { _prowidth = value; }
            get { return _prowidth; }
        }

        /// <summary>
        /// 图文缩略图高
        /// </summary>
        public int ProHight
        {
            set { _prohight = value; }
            get { return _prohight; }
        }

        /// <summary>
        /// 是否开启图片水印
        /// </summary>
        public int IsWatermark
        {
            set { _iswatermark = value; }
            get { return _iswatermark; }
        }

        /// <summary>
        /// 图片水印位置
        /// </summary>
        public int WatermarkStatus
        {
            set { _watermarkstatus = value; }
            get { return _watermarkstatus; }
        }

        /// <summary>
        /// 图片生成质量
        /// </summary>
        public int ImgQuality
        {
            set { _imgquality = value; }
            get { return _imgquality; }
        }

        /// <summary>
        /// 图片型水印文件
        /// </summary>
        public string ImgWaterPath
        {
            set { _imgwaterpath = value; }
            get { return _imgwaterpath; }
        }

        /// <summary>
        /// 图片水印透明度
        /// </summary>
        public int ImgWaterTransparency
        {
            set { _imgwatertransparency = value; }
            get { return _imgwatertransparency; }
        }

        /// <summary>
        /// 文字水印内容
        /// </summary>
        public string WaterText
        {
            set { _watertext = value; }
            get { return _watertext; }
        }

        /// <summary>
        /// 文字水印字体
        /// </summary>
        public string WaterFont
        {
            set { _waterfont = value; }
            get { return _waterfont; }
        }

        /// <summary>
        /// 文字水印字体大小
        /// </summary>
        public int FontSize
        {
            set { _fontsize = value; }
            get { return _fontsize; }
        }

        //================================================================================

        /// <summary>
        /// 当前模板（较特殊）
        /// </summary>
        public string TemplateSkin
        {
            get { return _templateskin; }
            set { _templateskin = value; }
        }

    }
}
