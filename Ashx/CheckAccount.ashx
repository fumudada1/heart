<%@ WebHandler Language="C#" Class="CheckAccount" %>

using System;
using System.Data;
using System.Web;
using TIN;

public class CheckAccount : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        
        context.Response.ContentType = "text/plain";
        
        //檢查帳號是否重複
        EasyDataProvide Customer = new EasyDataProvide("Customer");
        Customer.AddParameter("username", context.Request["username"]);
        DataRow rowCheck = Customer.GetSingleRow("username=@username");
        context.Response.Write(rowCheck != null ? "1" : "0"); //1表示已經存在,0表示不存在。
        //context.Response.Write(context.Request["username"]); //除錯用
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}