using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace WorkImage
{
    public class WorkImage
    {
        public static async Task<Bitmap> CropImageAsync(Image upload, int height, int width)
        {
            Bitmap tmp = new Bitmap(upload, height, width);
            return await Task.FromResult<Bitmap>(tmp);
        }
        public static async Task<Bitmap> CropImageAsync(HttpPostedFileBase upload, int maxHeight, int maxWidth)
        {
            return CropImage(upload, maxHeight, maxWidth);
        }

        public static Bitmap MakeBitmap(HttpPostedFileBase upload)
        {
            using(Bitmap tmp = new Bitmap(upload.InputStream, true))
            {
                return tmp;
            }
        }

        public static Bitmap CropImage(HttpPostedFileBase upload, int maxHeight, int maxWidth)
        {
            if (upload != null && upload.ContentLength > 0 && upload.ContentLength <= 10000000)
            {
                try
                {

                    using (Bitmap tmp = new Bitmap(upload.InputStream, true))
                    {
                        int width = tmp.Width;
                        int height = tmp.Height;
                        int widthDiff = (width - maxWidth);
                        int heightDiff = (height - maxHeight);

                        bool doWidthResize = (maxWidth > 0 && width > maxWidth && widthDiff > -1 && widthDiff > heightDiff);
                        bool doHeightResize = (maxHeight > 0 && height > maxHeight && heightDiff > -1 && heightDiff > widthDiff);

                        if (doHeightResize || doWidthResize || (width.Equals(height) && widthDiff.Equals(heightDiff)))
                        {
                            int iStart;
                            Decimal divider;
                            if (doWidthResize)
                            {
                                iStart = width;
                                divider = Math.Abs((Decimal)iStart / maxWidth);
                                width = maxWidth;
                                height = (int)Math.Round((height / divider));
                            }
                            else
                            {
                                iStart = height;
                                divider = Math.Abs((Decimal)iStart / maxHeight);
                                height = maxHeight;
                                width = (int)Math.Round((width / divider));
                            }
                        }
                        using (Bitmap outImage = new Bitmap(width, height, PixelFormat.Format16bppRgb555))
                        {
                            using (Graphics oGraphics = Graphics.FromImage(outImage))
                            {
                                oGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                                oGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                oGraphics.DrawImage(tmp, 0, 0, width, height);
                                //oGraphics.DrawString("Lorem", new Font("Arial", 14), new SolidBrush(Color.Aqua), new Point(50, 70));
                                return new Bitmap(outImage);
                            }
                        }
                    }
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        public static void DeleteImages(string path, List<string> images)
        {
            try
            {
                foreach (var i in images)
                {
                    System.IO.File.Delete(String.Format("{0}{1}", path, i));
                }
            }
            catch(Exception e)
            {

            }
        }

    }
}
