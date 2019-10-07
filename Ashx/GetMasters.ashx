<%@ WebHandler Language="C#" Class="GetMasters" %>

using System;
using System.Data;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TIN;

public class GetMasters : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        TIN.EasyDataProvide Masters = new EasyDataProvide("Masters");
        DataTable dt = Masters.GetAllData("order by listNum");
        string result = JsonConvert.SerializeObject(dt, new DataTableConverter());
        context.Response.Write(result);
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}