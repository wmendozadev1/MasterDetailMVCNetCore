using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVCNetCore.Models
{
    public class Enum
    {
        public enum NotificationType
        {
            error,
            success,
            warning,
            info
        }


        public enum NotificationPosition
        {
            Top,
            TopStart,
            TopEnd,
            Center,
            CenterStart,
            CenterEnd,
            Bottom,
            BottomStart,
            BottomEnd
        }


    }
}
