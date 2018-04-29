

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ColorSettings
{
    public static class ShemeList
    {

        public static readonly int ColorPairsCount = 16;

        public static List<ColorSheme> items = new List<ColorSheme>();


        public static ColorSheme Nature = new ColorSettings.ColorSheme(false, "Nature", new ColorPair[]
          {
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F9FEE7")),  // Color0
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F7F9DB")),  // Color1
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#EAFAC5")),  // Color2
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#DEF0A6")),  // Color3
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#61AC53")),  // Color4
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#CCBAC7")),  // Color5
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#C7CCBA")),  // Color6
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#FFFFFF")),  // Color7
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#E2FFBA")),  // Color8
 new ColorPair(ColorTranslator.FromHtml("#936B20"),
                 ColorTranslator.FromHtml("#FFFFFF")),  // Color9
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F5F7D4")),  // Color10
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#FFFFFF")),  // Color11
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F2F2F2")),  // Color12
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#EAFAC5")),  // Color13
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#DEF0A6")),  // Color14
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#EAFAC5"))  // Color15
          });
        public static ColorSheme Techno = new ColorSettings.ColorSheme(false, "Techno", new ColorPair[]
          {
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F3F3F3")),  // Color0
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#DBDBDB")),  // Color1
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#C7CCBA")),  // Color2
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#BAC7CC")),  // Color3
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#7BBFF2")),  // Color4
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#CCBAC7")),  // Color5
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#C7CCBA")),  // Color6
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#BAC7CC")),  // Color7
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("Silver")),  // Color8
 new ColorPair(ColorTranslator.FromHtml("#936B20"),
                 ColorTranslator.FromHtml("#FFFFFF")),  // Color9
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#BAC7CC")),  // Color10
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#CDD5D9")),  // Color11
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#BAC7CC")),  // Color12
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#BAC7CC")),  // Color13
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#C7CCBA")),  // Color14
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#BAC7CC"))  // Color15
          });
        public static ColorSheme SunSet = new ColorSettings.ColorSheme(false, "SunSet", new ColorPair[]
          {
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#36688D")),  // Color0
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F3CD05")),  // Color1
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F49F05")),  // Color2
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F18904")),  // Color3
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#BDA589")),  // Color4
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#36688D")),  // Color5
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F3CD05")),  // Color6
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F49F05")),  // Color7
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F18904")),  // Color8
 new ColorPair(ColorTranslator.FromHtml("#936B20"),
                 ColorTranslator.FromHtml("#FFFFFF")),  // Color9
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F18904")),  // Color10
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#FECFB8")),  // Color11
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#FDDFAE")),  // Color12
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F18904")),  // Color13
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F49F05")),  // Color14
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F18904"))  // Color15
          });
        public static ColorSheme Retro = new ColorSettings.ColorSheme(false, "Retro", new ColorPair[]
          {
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#C87884")),  // Color0
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#A8A79D")),  // Color1
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#B3C0BF")),  // Color2
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#A37C27")),  // Color3
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#563838")),  // Color4
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#A7414A")),  // Color5
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#282726")),  // Color6
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#6A8A82")),  // Color7
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#A37C27")),  // Color8
 new ColorPair(ColorTranslator.FromHtml("#936B20"),
                 ColorTranslator.FromHtml("#FFFFFF")),  // Color9
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F18904")),  // Color10
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#FCE5CE")),  // Color11
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#EEFDA9")),  // Color12
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F18904")),  // Color13
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#6A8A82")),  // Color14
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#A37C27"))  // Color15
          });
        public static ColorSheme Shimmering = new ColorSettings.ColorSheme(false, "Shimmering", new ColorPair[]
          {
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#0444BF")),  // Color0
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#0584F2")),  // Color1
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#0AAFF1")),  // Color2
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#EDF259")),  // Color3
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#A79674")),  // Color4
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#0444BF")),  // Color5
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#0584F2")),  // Color6
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#0AAFF1")),  // Color7
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#EDF259")),  // Color8
 new ColorPair(ColorTranslator.FromHtml("#936B20"),
                 ColorTranslator.FromHtml("#FFFFFF")),  // Color9
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F18904")),  // Color10
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F6EF92")),  // Color11
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#FED58A")),  // Color12
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F18904")),  // Color13
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#0AAFF1")),  // Color14
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#EDF259"))  // Color15
          });
        public static ColorSheme MediterraneanDark = new ColorSettings.ColorSheme(false, "MediterraneanDark", new ColorPair[]
          {
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#ABA6BF")),  // Color0
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#595775")),  // Color1
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#583E2E")),  // Color2
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F1E0D6")),  // Color3
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#BF988F")),  // Color4
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#ABA6BF")),  // Color5
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#595775")),  // Color6
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#583E2E")),  // Color7
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F1E0D6")),  // Color8
 new ColorPair(ColorTranslator.FromHtml("#936B20"),
                 ColorTranslator.FromHtml("#FFFFFF")),  // Color9
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F18904")),  // Color10
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F18904")),  // Color11
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F18904")),  // Color12
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F18904")),  // Color13
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#583E2E")),  // Color14
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F1E0D6"))  // Color15
          });
        public static ColorSheme MagentasAndYelows = new ColorSettings.ColorSheme(false, "MagentasAndYelows", new ColorPair[]
          {
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#DAA2DA")),  // Color0
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#DBB4DA")),  // Color1
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#DE8CF0")),  // Color2
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#BED905")),  // Color3
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#93A806")),  // Color4
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#DAA2DA")),  // Color5
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#DBB4DA")),  // Color6
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#DE8CF0")),  // Color7
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#BED905")),  // Color8
 new ColorPair(ColorTranslator.FromHtml("#936B20"),
                 ColorTranslator.FromHtml("#FFFFFF")),  // Color9
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F18904")),  // Color10
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F18904")),  // Color11
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F18904")),  // Color12
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F18904")),  // Color13
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#DE8CF0")),  // Color14
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#BED905"))  // Color15
          });
        public static ColorSheme Custom = new ColorSettings.ColorSheme(false, "Custom", new ColorPair[]
          {
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#FF8000")),  // Color0
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#CCBAC7")),  // Color1
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#C7CCBA")),  // Color2
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#BAC7CC")),  // Color3
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#FF8000")),  // Color4
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#CCBAC7")),  // Color5
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#C7CCBA")),  // Color6
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#BAC7CC")),  // Color7
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#FF8000")),  // Color8
 new ColorPair(ColorTranslator.FromHtml("#936B20"),
                 ColorTranslator.FromHtml("#FFFFFF")),  // Color9
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F18904")),  // Color10
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#FBCFA1")),  // Color11
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#D9F7FB")),  // Color12
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#F18904")),  // Color13
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#C7CCBA")),  // Color14
 new ColorPair(ColorTranslator.FromHtml("#000000"),
                 ColorTranslator.FromHtml("#BAC7CC"))  // Color15
          });

        internal static void SetDefault()
        {
            items.Clear();
            items.Add(Nature);
            items.Add(Techno);
            items.Add(SunSet);
            items.Add(Retro);
            items.Add(Shimmering);
            items.Add(MediterraneanDark);
            items.Add(MagentasAndYelows);
            items.Add(Custom);
            foreach (ColorSheme sheme in items)
            {
                CreateSheme(sheme, false);
            }
        }

        private static void CreateSheme(ColorSheme sheme, bool read_only)
        {
            DataTable Sheme = ColorSettings.Sheme.dsColorSheme.Tables["Sheme"];
            DataRow drColorSheme = Sheme.NewRow();
            drColorSheme["Name"] = sheme.Name;
            drColorSheme["ReadOnly"] = read_only;
            int id = (int)drColorSheme["ID"];
            Sheme.Rows.Add(drColorSheme);
            DataTable Colors = ColorSettings.Sheme.dsColorSheme.Tables["Colors"];

            DataRow drColorValue = Colors.NewRow();
            drColorValue["Sheme_ID"] = id;
            drColorValue["Type"] = "fore";
            for (int i = 0; i < ColorPairsCount; i++)
            {
                if (sheme.Colorpair.Length > i)
                {
                    drColorValue["Color" + i.ToString()] = System.Drawing.ColorTranslator.ToHtml(sheme.Colorpair[i].ForeColor);
                }
                else
                {
                    int grv = (i * 20) % 256;
                    drColorValue["Color" + i.ToString()] = System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.FromArgb(grv, grv, grv));
                }
            }
            Colors.Rows.Add(drColorValue);

            drColorValue = Colors.NewRow();
            drColorValue["Sheme_ID"] = id;
            drColorValue["Type"] = "back";
            for (int i = 0; i < ColorPairsCount; i++)
            {
                if (sheme.Colorpair.Length > i)
                {
                    drColorValue["Color" + i.ToString()] = System.Drawing.ColorTranslator.ToHtml(sheme.Colorpair[i].BackColor);
                }
                else
                {
                    int grv = (i * 20) % 256;
                    drColorValue["Color" + i.ToString()] = System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.FromArgb(grv, grv, grv));
                }
            }
            Colors.Rows.Add(drColorValue);

        }

        internal static void SetShemeList()
        {
            items.Clear();
            DataTable dtSheme = ColorSettings.Sheme.dsColorSheme.Tables["Sheme"];
            foreach (DataRow drsheme in dtSheme.Rows)
            {
                string name = (string)drsheme["Name"];
                ColorSheme colorsheme = ColorSettings.Sheme.Get(name, true);
                if (colorsheme != null)
                {
                    items.Add(colorsheme);
                }
            }
        }
    }
}
