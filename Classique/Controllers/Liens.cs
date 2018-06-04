using System;
using System.Web;
using System.Web.Mvc;

public static class HtmlExtensions
{
    public static MvcHtmlString Image(this HtmlHelper html, byte[] image)
    {
        if (image != null)
        {
            var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
            return new MvcHtmlString("<img src='" + img + "' />");
        }
        return null;
    }

    public static MvcHtmlString Music(this HtmlHelper html, byte[] music)
    {
        if (music != null)
        {
            var msc = String.Format("data:audio/mp3;base64,{0}", Convert.ToBase64String(music));
            return new MvcHtmlString("<audio controls src='" + msc + "' /></audio>");
        }
        return null;
    }
}