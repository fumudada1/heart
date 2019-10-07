

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class MediaPlayerUserControl : System.Web.UI.UserControl
{

    private string _url;//資料來源
    private int _width;//控制項寬度
    private int _height;//控制項長度
    private bool _autoStart = true;//自動播放

    #region 屬性

    public int Width
    {
        get { return _width; }
        set { _width = value; }
    }

    public int Height
    {
        get { return _height; }
        set { _height = value; }
    }

    public string Url
    {
        get { return _url; }
        set { _url = value; }
    }

    public bool AutoStart
    {
        get { return _autoStart; }
        set { _autoStart = value; }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void Render(HtmlTextWriter writer)
    {
        StringBuilder sb = new StringBuilder();
        //sb.AppendFormat("<object id='MediaPlayer' height='{0}' width='{1}' classid='CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6'>", this.Height, this.Width);
        //sb.AppendFormat("<param name='URL' value='{0}' />", this.Url);
        //sb.AppendFormat("<param name='autoStart' value='{0}' />", this.AutoStart);
        //sb.Append("</object>");
        sb.AppendFormat("<embed width='{0}' height='{1}' style='border: 0px solid #000000;' type='application/x-mplayer2' showstatusbar='true' autostart='{2}' src='{3}'>", this.Width, this.Height, this.AutoStart, this.Url);
        writer.Write(sb.ToString());
    }
}
