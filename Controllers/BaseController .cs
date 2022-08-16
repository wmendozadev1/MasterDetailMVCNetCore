using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TestMVCNetCore.Models.Enum;

namespace TestMVCNetCore.Controllers
{
    public class BaseController : Controller
    {

        #region "Forma 1"
        //public void ShowAlert(string message, NotificationType notificationType)
        //{
        //    var msg = "<script language='javascript'>Swal.fire('" + notificationType.ToString().ToUpper() + "', '" + message + "','" + notificationType + "')" + "</script>";
        //    //var msg = "<script language='javascript'>Swal.fire({title:'',text: '" + message + "',type:'" + notificationType + "',allowOutsideClick: false,allowEscapeKey: false,allowEnterKey: false})" + "</script>";
        //    TempData["notification"] = msg;
        //}

       
        public void Message(string message, NotificationType notifyType)
        {
            TempData["Notification2"] = message;

            switch (notifyType)
            {
                case NotificationType.success:
                    TempData["NotificationCSS"] = "alert-box success";
                    break;
                case NotificationType.error:
                    TempData["NotificationCSS"] = "alert-box errors";
                    break;
                case NotificationType.warning:
                    TempData["NotificationCSS"] = "alert-box warning";
                    break;

                case NotificationType.info:
                    TempData["NotificationCSS"] = "alert-box notice";
                    break;
            }
        }

        #endregion

        #region "Forma 2"

        string pos = "";

        public void showAlertMessage(string msj, NotificationType type, string title = "")
        {
            TempData["notification"] = $"Swal.fire('{title}','{msj}', '{type.ToString().ToLower()}')";
        }

        // el parametro de timer con valor 0 se deshabilita
        public void CustomNotification(string msj, NotificationType type, NotificationPosition position, string title = "", bool showConfirmButton = false, int timer = 2000, bool toast = true)
        {
            SetPosition(position.ToString());

            //TempData["notification"] = "Swal.fire({customClass:{confirmButton:'btn btn-primary',cancelButton:'btn btn-danger'},position:'" + pos + "',type:'" + type.ToString().ToLower() +
            //    "',title:'" + title + "',text: '" + msj + "',showConfirmButton: " + showConfirmButton.ToString().ToLower() + ",confirmButtonColor: '#4F0DA2',toast: "
            //    + toast.ToString().ToLower() + ",timer: " + timer + "}); ";

            TempData["notification"] = "Swal.fire({customClass:{cancelButton:'btn btn-danger',confirmButton:'btn btn-primary'},buttons: true,showCancelButton:true,position:'" + pos + "',type:'" + type.ToString().ToLower() +
             "',title:'" + title + "',text: '" + msj + "',showConfirmButton: " + showConfirmButton.ToString().ToLower() + ",confirmButtonColor: '#4F0DA2',toast: "
             + toast.ToString().ToLower() + ",timer: " + timer + "}); ";

        }


        #region Methods

        private void SetPosition(string position)
        {
            if (position == "Top") pos = "top";
            if (position == "TopStart") pos = "top-start";
            if (position == "TopEnd") pos = "top-end";
            if (position == "Center") pos = "center";
            if (position == "CenterStart") pos = "center-start";
            if (position == "CenterEnd") pos = "center-end";
            if (position == "Bottom") pos = "bottom";
            if (position == "BottomStart") pos = "bottom-start";
            if (position == "BottomEnd") pos = "bottom-end";
        }


        #endregion

        #endregion

    }
}
