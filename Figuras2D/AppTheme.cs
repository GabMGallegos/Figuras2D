using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Figuras2D
{
    public static class AppTheme
    {
        public static Color BgMain = Color.FromArgb(26, 26, 46);
        public static Color BgPanel = Color.FromArgb(22, 33, 62);
        public static Color BgSidebar = Color.FromArgb(15, 52, 96);
        public static Color Accent = Color.FromArgb(83, 74, 183);
        public static Color AccentSub = Color.FromArgb(175, 169, 236);
        public static Color TextPri = Color.FromArgb(238, 237, 254);
        public static Color TextSec = Color.FromArgb(136, 136, 187);
        public static Color Separator = Color.FromArgb(42, 42, 74);
        public static Color alert = Color.FromArgb(255, 0, 0);

        public static Font FontMenu = new Font("Segoe UI", 9.5f);
        public static Font FontGroup = new Font("Segoe UI", 7.5f, FontStyle.Bold);
        public static Font FontMono = new Font("Consolas", 9f);
    }
}
