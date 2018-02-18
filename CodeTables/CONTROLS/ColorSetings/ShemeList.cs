
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSettings
{
    public static class ShemeList
    {
        public static List<ColorSheme> items = new List<ColorSheme>();


      public static ColorSheme Nature = new ColorSettings.ColorSheme(false, "Nature", new System.Drawing.Color[]
        {
    System.Drawing.ColorTranslator.FromHtml("#F9FEE7"),
    System.Drawing.ColorTranslator.FromHtml("#F7F9DB"),
    System.Drawing.ColorTranslator.FromHtml("#EAFAC5"),
    System.Drawing.ColorTranslator.FromHtml("#DEF0A6"),
    System.Drawing.ColorTranslator.FromHtml("#61AC53"),
    System.Drawing.ColorTranslator.FromHtml("#CCBAC7"),
    System.Drawing.ColorTranslator.FromHtml("#C7CCBA"),
    System.Drawing.ColorTranslator.FromHtml("#FFFFFF"),
    System.Drawing.ColorTranslator.FromHtml("#E2FFBA"),
    System.Drawing.ColorTranslator.FromHtml("#936B20")
        });
      public static ColorSheme Techno = new ColorSettings.ColorSheme(false, "Techno", new System.Drawing.Color[]
        {
    System.Drawing.ColorTranslator.FromHtml("#F3F3F3"),
    System.Drawing.ColorTranslator.FromHtml("#DBDBDB"),
    System.Drawing.ColorTranslator.FromHtml("#C7CCBA"),
    System.Drawing.ColorTranslator.FromHtml("#BAC7CC"),
    System.Drawing.ColorTranslator.FromHtml("#7BBFF2"),
    System.Drawing.ColorTranslator.FromHtml("#CCBAC7"),
    System.Drawing.ColorTranslator.FromHtml("#C7CCBA"),
    System.Drawing.ColorTranslator.FromHtml("#BAC7CC"),
    System.Drawing.ColorTranslator.FromHtml("Silver"),
    System.Drawing.ColorTranslator.FromHtml("#804000")
        });
      public static ColorSheme SunSet = new ColorSettings.ColorSheme(false, "SunSet", new System.Drawing.Color[]
        {
    System.Drawing.ColorTranslator.FromHtml("#36688D"),
    System.Drawing.ColorTranslator.FromHtml("#F3CD05"),
    System.Drawing.ColorTranslator.FromHtml("#F49F05"),
    System.Drawing.ColorTranslator.FromHtml("#F18904"),
    System.Drawing.ColorTranslator.FromHtml("#BDA589"),
    System.Drawing.ColorTranslator.FromHtml("#36688D"),
    System.Drawing.ColorTranslator.FromHtml("#F3CD05"),
    System.Drawing.ColorTranslator.FromHtml("#F49F05"),
    System.Drawing.ColorTranslator.FromHtml("#F18904"),
    System.Drawing.ColorTranslator.FromHtml("#BDA589")
        });
      public static ColorSheme Retro = new ColorSettings.ColorSheme(false, "Retro", new System.Drawing.Color[]
        {
    System.Drawing.ColorTranslator.FromHtml("#A7414A"),
    System.Drawing.ColorTranslator.FromHtml("#282726"),
    System.Drawing.ColorTranslator.FromHtml("#6A8A82"),
    System.Drawing.ColorTranslator.FromHtml("#A37C27"),
    System.Drawing.ColorTranslator.FromHtml("#563838"),
    System.Drawing.ColorTranslator.FromHtml("#A7414A"),
    System.Drawing.ColorTranslator.FromHtml("#282726"),
    System.Drawing.ColorTranslator.FromHtml("#6A8A82"),
    System.Drawing.ColorTranslator.FromHtml("#A37C27"),
    System.Drawing.ColorTranslator.FromHtml("#563838")
        });
      public static ColorSheme Shimmering = new ColorSettings.ColorSheme(false, "Shimmering", new System.Drawing.Color[]
        {
    System.Drawing.ColorTranslator.FromHtml("#0444BF"),
    System.Drawing.ColorTranslator.FromHtml("#0584F2"),
    System.Drawing.ColorTranslator.FromHtml("#0AAFF1"),
    System.Drawing.ColorTranslator.FromHtml("#EDF259"),
    System.Drawing.ColorTranslator.FromHtml("#A79674"),
    System.Drawing.ColorTranslator.FromHtml("#0444BF"),
    System.Drawing.ColorTranslator.FromHtml("#0584F2"),
    System.Drawing.ColorTranslator.FromHtml("#0AAFF1"),
    System.Drawing.ColorTranslator.FromHtml("#EDF259"),
    System.Drawing.ColorTranslator.FromHtml("#A79674")
        });
      public static ColorSheme MediterraneanDark = new ColorSettings.ColorSheme(false, "MediterraneanDark", new System.Drawing.Color[]
        {
    System.Drawing.ColorTranslator.FromHtml("#ABA6BF"),
    System.Drawing.ColorTranslator.FromHtml("#595775"),
    System.Drawing.ColorTranslator.FromHtml("#583E2E"),
    System.Drawing.ColorTranslator.FromHtml("#F1E0D6"),
    System.Drawing.ColorTranslator.FromHtml("#BF988F"),
    System.Drawing.ColorTranslator.FromHtml("#ABA6BF"),
    System.Drawing.ColorTranslator.FromHtml("#595775"),
    System.Drawing.ColorTranslator.FromHtml("#583E2E"),
    System.Drawing.ColorTranslator.FromHtml("#F1E0D6"),
    System.Drawing.ColorTranslator.FromHtml("#BF988F")
        });
      public static ColorSheme MagentasAndYelows = new ColorSettings.ColorSheme(false, "MagentasAndYelows", new System.Drawing.Color[]
        {
    System.Drawing.ColorTranslator.FromHtml("#DAA2DA"),
    System.Drawing.ColorTranslator.FromHtml("#DBB4DA"),
    System.Drawing.ColorTranslator.FromHtml("#DE8CF0"),
    System.Drawing.ColorTranslator.FromHtml("#BED905"),
    System.Drawing.ColorTranslator.FromHtml("#93A806"),
    System.Drawing.ColorTranslator.FromHtml("#DAA2DA"),
    System.Drawing.ColorTranslator.FromHtml("#DBB4DA"),
    System.Drawing.ColorTranslator.FromHtml("#DE8CF0"),
    System.Drawing.ColorTranslator.FromHtml("#BED905"),
    System.Drawing.ColorTranslator.FromHtml("#93A806")
        });
      public static ColorSheme Custom = new ColorSettings.ColorSheme(false, "Custom", new System.Drawing.Color[]
        {
    System.Drawing.ColorTranslator.FromHtml("#FF8000"),
    System.Drawing.ColorTranslator.FromHtml("#CCBAC7"),
    System.Drawing.ColorTranslator.FromHtml("#C7CCBA"),
    System.Drawing.ColorTranslator.FromHtml("#BAC7CC"),
    System.Drawing.ColorTranslator.FromHtml("#FF8000"),
    System.Drawing.ColorTranslator.FromHtml("#CCBAC7"),
    System.Drawing.ColorTranslator.FromHtml("#C7CCBA"),
    System.Drawing.ColorTranslator.FromHtml("#BAC7CC"),
    System.Drawing.ColorTranslator.FromHtml("#FF8000"),
    System.Drawing.ColorTranslator.FromHtml("#CCBAC7")
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
                for (int i = 0; i < 10; i++)
                {
                    if (sheme.color.Length > i)
                    {
                        drColorValue["Color" + i.ToString()] = System.Drawing.ColorTranslator.ToHtml(sheme.color[i]);
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
