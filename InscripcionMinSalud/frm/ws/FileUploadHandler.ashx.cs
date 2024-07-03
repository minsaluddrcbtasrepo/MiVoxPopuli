using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace InscripcionMinSalud.frm.ws
{
    /// <summary>
    /// Summary description for FileUploadHandler
    /// </summary>
    public class FileUploadHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if (context.Request.QueryString["upload"] != null)
                {
                    string pathrefer = context.Request.UrlReferrer.ToString();

                    var postedFile = context.Request.Files[0];
                    string tempPath = context.Server.MapPath("~/files/") ;
                 

                    string filename;

                    //For IE to get file name
                    if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
                    {
                        string[] files = postedFile.FileName.Split(new char[] { '\\' });
                        filename = files[files.Length - 1];
                    }
                    else
                    {
                        filename = postedFile.FileName;
                    }
                    //quitamos caracteres especiales 
                    filename = DateTime.Now.Ticks.ToString().Substring(12)+""+ filename.Replace("+", "").Replace("&", "");


                    postedFile.SaveAs(tempPath + @"\" + filename);
                    context.Response.AddHeader("Vary", "Accept");
                    try
                    {
                        if (context.Request["HTTP_ACCEPT"].Contains("application/json"))
                            context.Response.ContentType = "application/json";
                        else
                            context.Response.ContentType = "text/plain";
                    }
                    catch
                    {
                        context.Response.ContentType = "text/plain";
                    }
                    //agragamos a la session la url y el nombre cargado
                    string key = "ss_" + context.Request.QueryString["frm"] + "_" + context.Request.QueryString["folder"];
                    context.Session[key+"_filepath"] = "~/files/" + @"\" + filename;
                    context.Session[key + "_filename"] =  filename;
                    context.Response.Write(filename);
                    context.Response.StatusCode = 200;
                }
            }
            catch (Exception exp)
            {
                context.Response.Write(exp.Message);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}