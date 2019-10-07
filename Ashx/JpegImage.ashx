<%@ WebHandler Language="C#" Class="JpegImage" %>

using System;
using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;

public class JpegImage : IHttpHandler, IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {
        // Create a CAPTCHA image using the text stored in the Session object.
        CaptchaImage.CaptchaImage ci = new CaptchaImage.CaptchaImage(HttpContext.Current.Session["Captcha"].ToString(), 110, 40, "HANZEEXR");
        // Change the response headers to output a JPEG image.
        context.Response.Clear();
        context.Response.ContentType = "image/jpeg";

        // Write the image to the response stream in JPEG format.
        ci.Image.Save(context.Response.OutputStream, ImageFormat.Jpeg);

        // Dispose of the CAPTCHA image object.
        ci.Dispose();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}