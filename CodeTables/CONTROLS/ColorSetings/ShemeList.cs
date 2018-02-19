
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
                  ColorTranslator.FromHtml("#F9FEE7")),
    new ColorPair(ColorTranslator.FromHtml("#000000"),
                  ColorTranslator.FromHtml("#F7F9DB")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#EAFAC5")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#DEF0A6")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#61AC53")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#CCBAC7")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#C7CCBA")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#FFFFFF")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#E2FFBA")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#936B20")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#936B20")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#936B20")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#936B20")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#936B20")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#936B20")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#936B20"))
        });

      public static ColorSheme Techno = new ColorSettings.ColorSheme(false, "Techno", new ColorPair[]
        {
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F3F3F3")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#DBDBDB")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#C7CCBA")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#BAC7CC")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#7BBFF2")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#CCBAC7")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#C7CCBA")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#BAC7CC")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("Silver")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#804000")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#BAC7CC")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#BAC7CC")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#BAC7CC")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#BAC7CC")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#BAC7CC")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#BAC7CC"))
        });
      public static ColorSheme SunSet = new ColorSettings.ColorSheme(false, "SunSet", new ColorPair[]
        {
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#36688D")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F3CD05")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F49F05")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#BDA589")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#36688D")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F3CD05")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F49F05")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#BDA589")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904"))
					
        });
      public static ColorSheme Retro = new ColorSettings.ColorSheme(false, "Retro", new ColorPair[]
        {
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#A7414A")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#282726")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#6A8A82")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#A37C27")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#563838")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#A7414A")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#282726")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#6A8A82")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#A37C27")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#563838")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904"))
					
        });
      public static ColorSheme Shimmering = new ColorSettings.ColorSheme(false, "Shimmering", new ColorPair[]
        {
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#0444BF")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#0584F2")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#0AAFF1")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#EDF259")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#A79674")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#0444BF")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#0584F2")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#0AAFF1")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#EDF259")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#A79674")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904"))
					
        });
      public static ColorSheme MediterraneanDark = new ColorSettings.ColorSheme(false, "MediterraneanDark", new ColorPair[]
        {
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#ABA6BF")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#595775")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#583E2E")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F1E0D6")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#BF988F")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#ABA6BF")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#595775")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#583E2E")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F1E0D6")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#BF988F")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904"))
        });
      public static ColorSheme MagentasAndYelows = new ColorSettings.ColorSheme(false, "MagentasAndYelows", new ColorPair[]
        {
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#DAA2DA")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#DBB4DA")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#DE8CF0")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#BED905")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#93A806")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#DAA2DA")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#DBB4DA")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#DE8CF0")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#BED905")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#93A806")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904"))
					
        });
      public static ColorSheme Custom = new ColorSettings.ColorSheme(false, "Custom", new ColorPair[]
        {
			
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#FF8000")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#CCBAC7")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#C7CCBA")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#BAC7CC")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#FF8000")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#CCBAC7")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#C7CCBA")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#BAC7CC")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#FF8000")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#CCBAC7")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904")),
	new ColorPair(ColorTranslator.FromHtml("#000000"),
					ColorTranslator.FromHtml("#F18904"))

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
