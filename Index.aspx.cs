using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Data;
using Newtonsoft.Json;

namespace WebAppPaises
{
    public partial class Index : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
             if(tbxBuscar.Text == "")
            {
                Response.Write("<script>alert('Ingrese un nombre')</script>");
            }
        }


    }
}