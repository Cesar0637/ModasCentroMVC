using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using static TransportesMVC.Models.Enum;

namespace TransportesMVC.Utilidades
{
    public class SweetAlert
    {
        public static string Sweet_Alert(string title, string msg, NotificationType nt)
        {

            var script = "<script languaje='javascript'>" +
                    "Swal.fire({" +
                    "title: '" + title + "'," +
                    "text: '" + msg + "'," +
                    "icon: '" + nt + "'" +
                    "});" +
                    "</script>";
            return script;
        }
    }
}