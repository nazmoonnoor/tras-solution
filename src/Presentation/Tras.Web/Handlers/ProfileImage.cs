using System;
using System.Data;
using System.Web;

namespace Tras.Web.Handlers
{
    public class ProfileImage : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //http://stackoverflow.com/questions/1507572/streaming-databased-images-using-httphandler
            if (context.Request.QueryString["personid"] != null)
            {
                //int personid = Convert.ToInt32(context.Request.QueryString["personid"]);

                //DataSet ds = biz.GetFeaturedImageByID(personid);
                //DataRow row = ds.Tables[0].Rows[0];
                //byte[] featureImage = (byte[]) row["Photo"];
                //context.Response.ContentType = "image/jpeg";
                //context.Response.OutputStream.Write(featureImage, 0, featureImage.Length);
            }
            else
            {
                throw new ArgumentException("No personid parameter specified");
            }
        }

        #endregion
    }
}
