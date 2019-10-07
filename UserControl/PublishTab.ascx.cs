using System;
using System.Text;
using System.Web.UI;

public partial class UserControl_PublishTab : UserControl
{
    private int _Tab;
    public int tab
    {
        get
        {
            return _Tab;
        }
        set
        {
            _Tab = value;
        }
    }
    private string _FunctionName;
    public string FunctionName
    {
        get
        {
            return _FunctionName;
        }
        set
        {
            _FunctionName = value;
        }
    }
    private bool _IsCloseFileTab;
    public bool isCloseFileTab
    {
        get
        {
            return _IsCloseFileTab;
        }
        set
        {
            _IsCloseFileTab = value;
        }
    }
    private bool _IsCloseLinkTab;
    public bool isCloseLinkTab
    {
        get
        {
            return _IsCloseLinkTab;
        }
        set
        {
            _IsCloseLinkTab = value;
        }
    }
    private bool _IsCloseImageTab;
    public bool isCloseImageTab
    {
        get
        {
            return _IsCloseImageTab;
        }
        set
        {
            _IsCloseImageTab = value;
        }
    }
    private bool _IsCloseArticleTab;
    public bool isCloseArticleTab
    {
        get
        {
            return _IsCloseArticleTab;
        }
        set
        {
            _IsCloseArticleTab = value;
        }
    }

    private string _BaseTabName;
    public string BaseTabName
    {
        get
        {
            return _BaseTabName;
        }
        set
        {
            _BaseTabName = value;
        }
    }
    private string _FileTabName;
    public string FileTabName
    {
        get
        {
            return _FileTabName;
        }
        set
        {
            _FileTabName = value;
        }
    }
    private string _LinkTabName;
    public string LinkTabName
    {
        get
        {
            return _LinkTabName;
        }
        set
        {
            _LinkTabName = value;
        }
    }
    private string _ImageTabName;
    public string ImageTabName
    {
        get
        {
            return _ImageTabName;
        }
        set
        {
            _ImageTabName = value;
        }
    }
    private string _ArticTableName;
    public string ArticTableName
    {
        get
        {
            return _ArticTableName;
        }
        set
        {
            _ArticTableName = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //FunctionName 的預設值
            if (FunctionName == null)
            {
                FunctionName = "Publish";
            }

            StringBuilder tabStringBuilder = new StringBuilder("<ul id=\"menu\">");

            if (tab == 1)
            {
                tabStringBuilder.Append(string.Format("<li id=\"single\"><a href=\"{0}\"><b>{1}</b></a></li>", String.Format("{0}_Edit.aspx?ModuleID={1}&ID={2}&page={3}", FunctionName, Request["ModuleID"], Request["ID"],Request["page"]),
                                           BaseTabName ?? "基本資料"));
            }
            else
            {
                tabStringBuilder.Append(string.Format("<li><a href=\"{0}\"><b>{1}</b></a></li>", String.Format("{0}_Edit.aspx?ModuleID={1}&ID={2}&page={3}", FunctionName, Request["ModuleID"], Request["ID"],Request["page"]),
                                           BaseTabName ?? "基本資料"));
            }

            if (!isCloseFileTab)
            {
                if (tab == 2)
                {
                    tabStringBuilder.Append(string.Format("<li id=\"single\"><a href=\"{0}\"><b>{1}</b></a></li>",
                                               String.Format("_{0}_Files.aspx?ModuleID={1}&ID={2}&page={3}", FunctionName, Request["ModuleID"], Request["ID"],Request["page"]), FileTabName ?? "附加檔案"));
                }
                else
                {
                    tabStringBuilder.Append(string.Format("<li><a href=\"{0}\"><b>{1}</b></a></li>", String.Format("_{0}_Files.aspx?ModuleID={1}&ID={2}&page={3}", FunctionName, Request["ModuleID"], Request["ID"],Request["page"]),
                                               FileTabName ?? "附加檔案"));
                }
            }


            if (!isCloseLinkTab)
            {
            
                if (tab == 3)
                {
                    tabStringBuilder.Append(string.Format("<li id=\"single\"><a href=\"{0}\"><b>{1}</b></a></li>",
                                               String.Format("_{0}_Links.aspx?ModuleID={1}&ID={2}&page={3}", FunctionName, Request["ModuleID"], Request["ID"],Request["page"]), LinkTabName ?? "附加連結"));
                }
                else
                {
                    tabStringBuilder.Append(string.Format("<li><a href=\"{0}\"><b>{1}</b></a></li>", String.Format("_{0}_Links.aspx?ModuleID={1}&ID={2}&page={3}", FunctionName, Request["ModuleID"], Request["ID"],Request["page"]),
                                               LinkTabName ?? "附加連結"));
                }
            }
            if (!isCloseImageTab)
            {
           
                if (tab == 4)
                {
                    tabStringBuilder.Append(string.Format("<li id=\"single\"><a href=\"{0}\"><b>{1}</b></a></li>",
                                               String.Format("_{0}_Pictures.aspx?ModuleID={1}&ID={2}&page={3}", FunctionName, Request["ModuleID"], Request["ID"],Request["page"]), ImageTabName ?? "附加圖片"));
                }
                else
                {
                    tabStringBuilder.Append(string.Format("<li><a href=\"{0}\"><b>{1}</b></a></li>", String.Format("_{0}_Pictures.aspx?ModuleID={1}&ID={2}&page={3}", FunctionName, Request["ModuleID"], Request["ID"], Request["page"]),
                                               ImageTabName ?? "附加圖片"));
                }
            }
            if (!isCloseArticleTab)
            {

                if (tab == 5)
                {
                    tabStringBuilder.Append(string.Format("<li id=\"single\"><a href=\"{0}\"><b>{1}</b></a></li>",
                                               String.Format("_{0}_Articles.aspx?ModuleID={1}&ID={2}&page={3}", FunctionName, Request["ModuleID"], Request["ID"], Request["page"]), ImageTabName ?? "回覆資訊"));
                }
                else
                {
                    tabStringBuilder.Append(string.Format("<li><a href=\"{0}\"><b>{1}</b></a></li>", String.Format("_{0}_Articles.aspx?ModuleID={1}&ID={2}&page={3}", FunctionName, Request["ModuleID"], Request["ID"], Request["page"]),
                                               ImageTabName ?? "回覆資訊"));
                }
            }

            tabStringBuilder.Append("</ul>");
            Literal1.Text = tabStringBuilder.ToString();
        }
    }
}