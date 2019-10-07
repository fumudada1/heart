<%@ WebHandler Language="C#" Class="GetProducts" %>

using System;
using System.Data;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class GetProducts : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        DataLayer dl = new DataLayer();
        DataTable dt = dl.GetMasterProductsList("P01", "", "", true, DataLayer.SortMethed.OrderByInitDate, 40,1);
        string result = JsonConvert.SerializeObject(dt, new DataTableConverter());
        context.Response.Write(result);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}