<%@ WebHandler Language="C#" Class="GetNews" %>

using System;
using System.Data;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class GetNews : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        DataLayer dl = new DataLayer();
        int PageSize = 20;
        int totaleItems = dl.GetPublishListCount("N01", "", "", "","", DataLayer.SortMethed.OrderByInitDate, true);
        if (totaleItems < PageSize)
        {
            PageSize = totaleItems;
        }
        DataTable dt = dl.GetPublishList("N01", "", "", "","", DataLayer.SortMethed.OrderBylistNum, true, PageSize, 1);
        string result = JsonConvert.SerializeObject(dt  , new DataTableConverter());
        context.Request.Headers.Add("Access-Control-Allow-Origin","*");
        context.Response.Write(result);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}