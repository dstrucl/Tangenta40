
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using DBTypes;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using LanguageControl;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace StaticLib
{
    //public class e3pImage
    //{
    //    public string Name;
    //    public Image Image;
    //}


    //public class ImageStore
    //{
    //    const string const_IMAGE_STORE_ = "IMAGE_STORE_";
    //    public List<e3pImage> items = new List<e3pImage>();

    //    public string Insert(Image xImage)
    //    {
    //        string newname = UniqueNames.GetName(this, const_IMAGE_STORE_);
    //        e3pImage e3pi = new e3pImage();
    //        e3pi.Name = newname;
    //        e3pi.Image = xImage;
    //        items.Add(e3pi);
    //        return newname;
    //    }

    //    public Image Get(string xName)
    //    {
    //        int i = 0;
    //        int iCount;
    //        iCount = items.Count;
    //        for (i = 0; i < iCount; i++)
    //        {
    //            e3pImage e3pi = items[i];
    //            if (e3pi.Name.Equals(xName))
    //            {
    //                Image Img = (Image)e3pi.Image.Clone();
    //                items.RemoveAt(i);
    //                return Img;
    //            }
    //        }
    //        return null;
    //    }


    //    public bool IsName(string Value)
    //    {
    //        if (Value.Contains(const_IMAGE_STORE_))
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //}

    public static class Func
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern uint RegisterWindowMessage(string lpProcName);

        public static uint WM_USER_REDRAW_FORM;
        public static uint WM_USER_GENERATE_RANDOM_INPUT;
        public static uint WM_USER_GENERATE_RANDOM_INPUT_OK;
        public static uint WM_USER_GENERATE_RANDOM_INPUT_DONE;

        public static bool bRANDOM_PARAM_SETTINGS_DIALOG_IS_RUNNING;
        public static uint WM_DO_RANDOM_PARAM_SETTINGS_DIALOG;
        public static uint WM_RANDOM_PARAM_SETTINGS_DIALOG_CLOSED;



        public const string ImageStoreName = "Func.ImageStore";
        public static ImageStore ImageStore = new ImageStore();

        public static void Set_WM_USER_REDRAW_FORM()
        {
            WM_USER_REDRAW_FORM = RegisterWindowMessage("CodeTables WM_USER_REDRAW_FORM");
        }

        public static void Set_WM_USER_GENERATE_RANDOM_INPUT()
        {
            WM_USER_GENERATE_RANDOM_INPUT = RegisterWindowMessage("CodeTables WM_USER_GENERATE_RANDOM_INPUT");
        }

        public static void Set_WM_USER_GENERATE_RANDOM_INPUT_OK()
        {
            WM_USER_GENERATE_RANDOM_INPUT_OK = RegisterWindowMessage("CodeTables WM_USER_GENERATE_RANDOM_INPUT_OK");
        }

        public static void Set_WM_DO_RANDOM_PARAM_SETTINGS_DIALOG()
        {
            bRANDOM_PARAM_SETTINGS_DIALOG_IS_RUNNING = false;
            WM_DO_RANDOM_PARAM_SETTINGS_DIALOG = RegisterWindowMessage("CodeTables WM_DO_RANDOM_PARAM_SETTINGS_DIALOG");
        }


        public static void Set_WM_RANDOM_PARAM_SETTINGS_DIALOG_CLOSED()
        {
            WM_RANDOM_PARAM_SETTINGS_DIALOG_CLOSED = RegisterWindowMessage("CodeTables WM_RANDOM_PARAM_SETTINGS_DIALOG_CLOSED");
        }

        public static void Set_WM_USER_GENERATE_RANDOM_INPUT_DONE()
        {
            WM_USER_GENERATE_RANDOM_INPUT_DONE = RegisterWindowMessage("CodeTables  WM_USER_GENERATE_RANDOM_INPUT_DONE");
        }

        public static string GetNameFromObjectType(Object obj)
        {
            string str;
            str = obj.GetType().ToString();
            int i = str.LastIndexOf('.');
            str = str.Substring(i + 1);
            return str;
        }

        public static string GetNameFromType(Type mytype)
        {
            string str;
            str = mytype.ToString();
            int i = str.LastIndexOf('.');
            str = str.Substring(i + 1);
            return str;
        }


        public static object GetMemberValue(MemberInfo member, object target)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)member).GetValue(target);
                case MemberTypes.Property:
                    try
                    {
                        return ((PropertyInfo)member).GetValue(target, null);
                    }
                    catch (TargetParameterCountException e)
                    {
                        throw new ArgumentException("MemberInfo has index parameters", "member", e);
                    }
                default:
                    throw new ArgumentException("MemberInfo is not of type FieldInfo or PropertyInfo", "member");
            }
        }

        public static decimal TotalDiscount(decimal Discount, decimal ExtraDiscount,int decimal_places)
        {
            return decimal.Round(1 - (1 - Discount) * (1 - ExtraDiscount), decimal_places);
        }


        public static int GetMaxStringLength(Type myType)
        {
            DBtypes DBtypes = new DBtypes();
            Type myDBTypes = DBtypes.GetType();

            if (myType != null)
            {
                FieldInfo[] DBTypesInfo = myDBTypes.GetFields();
                int i;
                int iCount = DBTypesInfo.Count();
                for (i = 0; i < iCount; i++)
                {
                    if (DBTypesInfo[i].FieldType == myType)
                    {
                        if (myType == typeof(DB_Int32))
                        {
                            return 0;
                        }
                        else if (myType == typeof(DB_Int64))
                        {
                            return 0;
                        }
                        else if (myType == typeof(DB_smallInt))
                        {
                            return 0;
                        }
                        else if (myType == typeof(DB_bit))
                        {
                            return 0;
                        }
                        else if (myType == typeof(DB_DateTime))
                        {
                            return 0;
                        }
                        else if (myType == typeof(DBTypes.DB_varbinary_max))
                        {
                            return 0;
                        }
                        else if (myType == typeof(DB_varchar_250))
                        {
                            return 250;
                        }
                        else if (myType == typeof(DB_varchar_50))
                        {
                            return 50;
                        }
                        else if (myType == typeof(DB_varchar_64))
                        {
                            return 64;
                        }
                        else if (myType == typeof(DB_varchar_45))
                        {
                            return 45;
                        }
                        else if (myType == typeof(DB_varchar_32))
                        {
                            return 32;
                        }
                        else if (myType == typeof(DB_varchar_25))
                        {
                            return 25;
                        }
                        else if (myType == typeof(DB_varchar_10))
                        {
                            return 10;
                        }
                        else if (myType == typeof(DB_varchar_5))
                        {
                            return 5;
                        }
                        else if (myType == typeof(DB_varchar_2000))
                        {
                            return 2000;
                        }
                        else if (myType == typeof(DB_varchar_max))
                        {
                            return 2147483647;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }


        public static Byte[] SerializeMessage<T>(T msg) where T : struct
        {
            int objsize = Marshal.SizeOf(typeof(T));
            Byte[] ret = new Byte[objsize];
            IntPtr buff = Marshal.AllocHGlobal(objsize);
            Marshal.StructureToPtr(msg, buff, true);
            Marshal.Copy(buff, ret, 0, objsize);
            Marshal.FreeHGlobal(buff);
            return ret;
        }

        public static object ByteArrayToStruct(byte[] array, int offset, Type structType)
        {
            if (structType.StructLayoutAttribute.Value != LayoutKind.Sequential)
                throw new ArgumentException("structType ist keine Struktur oder nicht Sequentiell.");

            int size = Marshal.SizeOf(structType);
            if (array.Length < (offset + size))
                throw new ArgumentException("Byte-Array hat die falsche Länge.");

            byte[] tmp = new byte[size];
            Array.Copy(array, offset, tmp, 0, size);

            GCHandle structHandle = GCHandle.Alloc(tmp, GCHandleType.Pinned);
            object structure = Marshal.PtrToStructure(structHandle.AddrOfPinnedObject(), structType);
            structHandle.Free();

            return structure;
        }        


        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static Image resizeImage(Image imgToResize, Size size, System.Drawing.Imaging.ImageFormat destformat)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);

            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            Image img = (Image)b;

            byte[] bin = DBTypes.DBtypesFunc.imageToByteArray(img, destformat);
            //byte[] bin = DBTypes.DBtypesFunc.imageToByteArray(img);
            ImageConverter ic = new ImageConverter();
            return (Image)ic.ConvertFrom(bin);

        }

        public static Image resizeImage(Image imgToResize, Size size, System.Drawing.Imaging.ImageFormat destformat,PixelFormat pixel_format)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(size.Width, size.Height,PixelFormat.Format1bppIndexed);

            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.Bicubic;

            g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
            g.Dispose();

            Image img = (Image)b;

            byte[] bin = DBTypes.DBtypesFunc.imageToByteArray(img, destformat);
            //byte[] bin = DBTypes.DBtypesFunc.imageToByteArray(img);
            ImageConverter ic = new ImageConverter();
            return (Image)ic.ConvertFrom(bin);

        }


        public static Image PutImageInBoundaries(Image OrgImage, int MAX_PICTURE_WIDTH, int MAX_PICTURE_HEIGHT, System.Drawing.Imaging.ImageFormat destformat)
        {
            int myWidth;
            int myHeight;
            if (OrgImage.Width > OrgImage.Height)
            {
                if (OrgImage.Width > MAX_PICTURE_WIDTH)
                {
                    myWidth = MAX_PICTURE_WIDTH;
                    myHeight = (MAX_PICTURE_WIDTH * OrgImage.Height) / OrgImage.Size.Width;
                    Size size = new Size(myWidth,myHeight);
                    return resizeImage(OrgImage, size, destformat);
                }
                else
                {
                    return OrgImage;
                }
            }
            else
            {
                if (OrgImage.Height > MAX_PICTURE_HEIGHT)
                {
                    myHeight = MAX_PICTURE_HEIGHT;
                    myWidth = (MAX_PICTURE_HEIGHT * OrgImage.Width) / OrgImage.Size.Height;
                    Size size = new Size(myWidth, myHeight);
                    return resizeImage(OrgImage, size, destformat);
                }
                else
                {
                    return OrgImage;
                }
            }


        }

        public static List<string> GetImageDecoders()
        {
            List<string> ImageDecoderList = new List<string>();
            // Get an array of available decoders.
            ImageCodecInfo[] myCodecs;
            myCodecs = ImageCodecInfo.GetImageDecoders();
            int numCodecs = myCodecs.GetLength(0);


            // Check to determine whether any codecs were found. 
            if (numCodecs > 0)
            {
                // Set up an array to hold codec information. There are 9 
                // information elements plus 1 space for each codec, so 10 times 
                // the number of codecs found is allocated. 
                string[] myCodecInfo = new string[numCodecs * 10];
                int i;

                // Write all the codec information to the array. 
                for (i = 0; i < numCodecs; i++)
                {
                    myCodecInfo[i * 10] = "Codec Name = " + myCodecs[i].CodecName;
                    myCodecInfo[(i * 10) + 1] = "Class ID = " +
                        myCodecs[i].Clsid.ToString();
                    myCodecInfo[(i * 10) + 2] = "DLL Name = " + myCodecs[i].DllName;
                    myCodecInfo[(i * 10) + 3] = "Filename Ext. = " +
                        myCodecs[i].FilenameExtension;
                    myCodecInfo[(i * 10) + 4] = "Flags = " +
                        myCodecs[i].Flags.ToString();
                    myCodecInfo[(i * 10) + 5] = "Format Descrip. = " +
                        myCodecs[i].FormatDescription;
                    myCodecInfo[(i * 10) + 6] = "Format ID = " +
                        myCodecs[i].FormatID.ToString();
                    myCodecInfo[(i * 10) + 7] = "MimeType = " + myCodecs[i].MimeType;
                    myCodecInfo[(i * 10) + 8] = "Version = " +
                        myCodecs[i].Version.ToString();
                    myCodecInfo[(i * 10) + 9] = " ";
                }
                int numMyCodecInfo = myCodecInfo.GetLength(0);

                // Render all of the information to the screen. 
                for (i = 0; i < numMyCodecInfo; i++)
                {
                    ImageDecoderList.Add(myCodecInfo[i]);
                }
            }
            return ImageDecoderList;
        }

        public static string GetImageFormatName(Image img)
        {

            if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Bmp.Guid)
                return "Bmp";
            else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Emf.Guid)
                return "Emf";
            else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Exif.Guid)
                return "Exif";
            else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid)
                return "Gif";
            else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Icon.Guid)
                return "Icon";
            else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid)
                return "Jpeg";
            else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.MemoryBmp.Guid)
                return "MemoryBmp";
            else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid)
                return "Png";
            else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Tiff.Guid)
                return "Tiff";
            else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Wmf.Guid)
                return "Wmf";
            else
                return "Unknown Image Format!";
        }

        public static void CalculatePrice(decimal RetailPricePerUnit, decimal dQuantity, decimal Discount, decimal ExtraDiscount, decimal Taxation_Rate, ref decimal RetailPriceWithDiscount, ref decimal TaxPrice, ref decimal RetailPriceWithDiscount_WithoutTax, int decimal_places)
        {
            decimal RetailPrice = RetailPricePerUnit * dQuantity;
            decimal xRetailPricePerUnit = decimal.Round(RetailPrice - RetailPrice * Discount, decimal_places);

            RetailPriceWithDiscount = decimal.Round(xRetailPricePerUnit - xRetailPricePerUnit * ExtraDiscount, decimal_places);

            TaxPrice = decimal.Round(RetailPriceWithDiscount * ((Taxation_Rate) / (1 + Taxation_Rate)), decimal_places);

            RetailPriceWithDiscount_WithoutTax = RetailPriceWithDiscount - TaxPrice;

        }

    }
}
