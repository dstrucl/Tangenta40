#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangenta
{
    public class EscPos_Star_TSP100
    {
        public enum eEmphasizedMode : int {ON,OFF};
        public enum eCharacterSet : int { USA, France, Germany, UK, Denmark1, Sweden, Italy, Spain, Japan, Norway, Denmark2, Spain2, LatinAmerica, Korea, Slovenia_Croatia, China };
        public enum eCodeTable : int {
                                      Normal,
                                      CP437_USA_Standard_Europe,
                                      Katakana,
                                      Codepage_858_Multilingual,
                                      Codepage_1250
                                      };

            public const char ESC = '\x1B';
            public const char GS = '\x1D';
            public string LF = "\x0a"; //LineFeed
            public string CR = "\x0d"; //CarriageReturn
            public string HT = "\x09"; //CarriageReturn
            public string cRealtimeStatusTransmission = "\x10\x04";
            public string pRealtimeStatusTransmission_ParamRange = "";
            public string cRealtimeRequestToPrinter = "\x10\x05";
            public string pRealtimeRequestToPrinter = "";
            public string cGeneratePulseAtRealtime = "\x10\x14";
            public string pGeneratePulseAtRealtime = "";
            public string cSetRightSideCharacterSpacing = "\x1B\x20"; //ASCII DLE DC4 n m t
            public string pSetRightSideCharacterSpacing = ""; // n=1; m=0,1; 1<=t<=8
            //public string cSetRightSideCharacterSpacing = "\x1B\x20"; //ASCII ESC SP n
            //public string pSetRightSideCharacterSpacing = ""; //0 <= n <=255

            public string cSelectPrintMode = "\x1B\x21";  //ASCII ESC ! n
            public string pSelectPrintMode = "";  //ASCII ESC ! n
                    //Bit     Off/On     Hex    Decimal       Function
                    //0        Off        00      0           Character Font A (12×24).
                    //         On         01      1           Character Font B (9×17).
                    //1       -           -       -           Undefined.
                    //2       -           -       -           Undefined.
                    //3       Off         00      0           Emphasized mode not selected.
                    //        On          08      8           Emphasized mode selected.
                    //4       Off         00      0           Double-height mode not selected.
                    //        On          10      16          Double-height mode selected.
                    //5       Off         00      0           Double-width mode not selected.
                    //        On          20      32          Double-width mode selected.
                    //6       -           -       -           Undefined.
                    //7       Off         00      0           Underline mode not selected.
                    //        On          80      128         Underline mode selected
            public string cSetAbsolutePrintPosition = "\x1B\x24";  //ASCII ESC $ nL nH
            public string pSetAbsolutePrintPosition = "";  //0 <= nL <= 255 ; 0 <= nH <= 255 The distance from the beginning of the line to the print position is [(nL + nH¬256)¬0.125 mm].


            public string cSelectOrCancelUuserDefinedCharacterSet = "\x1B\x24"; //ASCII ESC % n
            public string pSelectOrCancelUuserDefinedCharacterSet = ""; //0 <= n <= 255
            //When the LSB of n is 0, the user-defined character set is canceled.
            //When the LSB of n is 1, the user-defined character set is selected.
            //When the user-defined character set is canceled, the built-in character set is automatically selected. 
            //n is available only for the least significant bit.
            public string cSelectOrCancelUserDefinedCharacterSet = "\x1B\x25"; //ASCII ESC % n
            public string pSelectOrCancelUserDefinedCharacterSet = ""; //0 <= n <= 255
            //Selects or cancels the user-defined character set. 
            //    When the LSB of n is 0, the user-defined character set is canceled. 
            //    When the LSB of n is 1, the user-defined character set is selected.

            public string cTurnUnderlineModeOnOrOff = "\x1B\x2D"; //ASCII ESC - n
            public string pTurnUnderlineModeOnOrOff = ""; //0 <= n <= 2, 48 <= n <= 50
            //n       Function
            //0, 48   Turns off underline mode
            //1, 49   Turns on underline mode (1 dot thick)
            //2, 50   Turns on underline mode (2 dots thick)

            public string cSelectDefaultLineSpacing = "\x1B\x32"; //ASCII ESC 2

            public string cSetLineSpacing = "\x1B\x32"; //ASCII ESC 3 n 
            public string pSetLineSpacing = ""; // 0 <= n <= 255 Sets the line spacing to [n x 0.125 mm]. [Default] n = 30

            public string cCancelUserDefinedCharacters = ESC + "?"; //ASCII ESC ? n
            public string pCancelUserDefinedCharacters = ""; //32 <= n <= 126

            public string cInitializePrinter = ESC + "@"; //ASCII ESC @ n
            public string InitializePrinter()
            {
                return cInitializePrinter;
            }




            public string cTurnEmphasizedModeOnOff = ESC + "E";
            public string TurnEmphasizedModeOnOff(eEmphasizedMode xeEmphasizedMode)
            {
                if (xeEmphasizedMode== eEmphasizedMode.ON)
                {
                    return cTurnEmphasizedModeOnOff+'\xFF';
                }
                else
                {
                    return cTurnEmphasizedModeOnOff+'\x00';
                }
            }

            public string cSelectAnInternationalCharacterSet = ESC + "R";
            public string nSelectAnInternationalCharacterSet = ESC + "R";
            public string SelectAnInternationalCharacterSet(eCharacterSet eSet)
            {
                try
                {
                char ch = Convert.ToChar((int)eSet);
                return cSelectAnInternationalCharacterSet + ch;
                }
                catch (Exception ex)
                {
                    LogFile.Error.Show("ERROR:EscPos:SelectAnInternationalCharacterSet:Exception = " + ex.Message);

                }
                return null;
            }

            public string cPrintAndFeed_n_lines = ESC + "d"; //ASCII ESC d n
            public string PrintAndFeed_n_lines(int n)
            {
                try
                {
                    char ch = Convert.ToChar(n);
                    return cPrintAndFeed_n_lines + ch;
                }
                catch (Exception ex)
                {
                    LogFile.Error.Show("ERROR:EscPos:PrintAndFeed_n_lines:Exception = " + ex.Message);

                }
                return null;
                
            }

            public string cSelectCharacterCodeTable  = ESC + GS + "t"; //ASCII ESC t n
            public string SelectCharacterCodeTable(eCodeTable eCodeTable)
            {
                try
                {
                    char ch = '\0';
                    switch (eCodeTable)
                    {
                        case EscPos_Star_TSP100.eCodeTable.CP437_USA_Standard_Europe:
                            ch = '\x1';
                            break;

                        case EscPos_Star_TSP100.eCodeTable.Katakana:
                            ch = '\x2';
                            break;

                        case EscPos_Star_TSP100.eCodeTable.Codepage_1250:
                            ch = '\x21';
                            break;
                    }
                    if (ch != '\0')
                    {
                        return "";//cSelectCharacterCodeTable + ch;
                    }
                }
                catch (Exception ex)
                {
                    LogFile.Error.Show("ERROR:EscPos:SelectCharacterCodeTable:Exception = " + ex.Message);

                }
                return null;
            }

            public string cSetHorizontalTabPositions = ESC + "D"; //ASCII ESC D n1...nk NUL
            public string SetHorizontalTabPositions(byte[] b)
            {
                string scmd = cSetHorizontalTabPositions;
                if (b != null)
                {
                    int iCount = b.Count();
                    int i;
                    for (i = 0; i < iCount; i++)
                    {
                        if (i < 32)
                        {
                            scmd += Convert.ToChar(b[i]);
                        }
                    }
                    scmd += '\0';
                    return scmd;
                }
                else
                {
                    return "";
                }
            }

            public string cCutPaper =  GS + "V0"; //ASCII ESC t n
            public string CutPaper()
            {
                return cCutPaper;
            }

            public string cPartialCutPaper = "\x1d\x56\x01"; //"\x1b\x64\x02"; //ASCII ESC t n
            public string PartialCutPaper()
            {
                return cPartialCutPaper;
            }

            public string GetBitmapString(byte[] ImageData)
            {
                if (ImageData==null)
                {
                    return "";
                }
                string logo = "";

                BitmapData data = GetBitmapData(ImageData);
                BitArray dots = data.Dots;
                byte[] width = BitConverter.GetBytes(data.Width);

                int offset = 0;
                MemoryStream stream = new MemoryStream();
                BinaryWriter bw = new BinaryWriter(stream);
                

                bw.Write((char)0x1B);
                bw.Write('@');

                bw.Write((char)0x1B);
                bw.Write('3');
                bw.Write((byte)24);

                while (offset < data.Height)
                {
                    bw.Write((char)0x1B);
                    bw.Write('*');         // bit-image mode
                    bw.Write((byte)33);    // 24-dot double-density
                    bw.Write(width[0]);  // width low byte
                    bw.Write(width[1]);  // width high byte

                    for (int x = 0; x < data.Width; ++x)
                    {
                        for (int k = 0; k < 3; ++k)
                        {
                            byte slice = 0;
                            for (int b = 0; b < 8; ++b)
                            {
                                int y = (((offset / 8) + k) * 8) + b;
                                // Calculate the location of the pixel we want in the bit array.
                                // It'll be at (y * width) + x.
                                int i = (y * data.Width) + x;

                                // If the image is shorter than 24 dots, pad with zero.
                                bool v = false;
                                if (i < dots.Length)
                                {
                                    v = dots[i];
                                }
                                slice |= (byte)((v ? 1 : 0) << (7 - b));
                            }

                            bw.Write(slice);
                        }
                    }
                    offset += 24;
                    bw.Write((char)0x0A);
                }
                // Restore the line spacing to the default of 30 dots.
                bw.Write((char)0x1B);
                bw.Write('3');
                bw.Write((byte)30);

                bw.Flush();
                byte[] bytes = stream.ToArray();
                return logo + Encoding.Default.GetString(bytes);
            }

            public BitmapData GetBitmapData(byte[] ImageData)
            {
                MemoryStream ms = new MemoryStream(ImageData);
                using (var bitmap = (Bitmap)Bitmap.FromStream(ms))
                {
                    var threshold = 127;
                    var index = 0;
                    double multiplier = 570; // this depends on your printer model. for Beiyang you should use 1000
                    double scale = (double)(multiplier / (double)bitmap.Width);
                    int xheight = (int)(bitmap.Height * scale);
                    int xwidth = (int)(bitmap.Width * scale);
                    var dimensions = xwidth * xheight;
                    var dots = new BitArray(dimensions);

                    for (var y = 0; y < xheight; y++)
                    {
                        for (var x = 0; x < xwidth; x++)
                        {
                            var _x = (int)(x / scale);
                            var _y = (int)(y / scale);
                            var color = bitmap.GetPixel(_x, _y);
                            var luminance = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                            dots[index] = (luminance < threshold);
                            index++;
                        }
                    }

                    return new BitmapData()
                    {
                        Dots = dots,
                        Height = (int)(bitmap.Height * scale),
                        Width = (int)(bitmap.Width * scale)
                    };
                }
            }

            public class BitmapData
            {
                public BitArray Dots
                {
                    get;
                    set;
                }

                public int Height
                {
                    get;
                    set;
                }

                public int Width
                {
                    get;
                    set;
                }
            }
    }
}
