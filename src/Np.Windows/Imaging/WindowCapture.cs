using Np.Windows.DllImports;
using Np.Windows.Structures;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Np.Windows.Imaging
{
    /// <summary>
    /// Contains methods to capture screenshots of windows.
    /// </summary>
    public class WindowCapture
    {
        /// <summary>
        /// Creates an Image object containing a screenshot of the entire desktop.
        /// </summary>
        /// <returns></returns>
        public static Image CaptureEntireDesktop()
        {
            IntPtr desktopWindowHandle = Window.GetDesktopWindow();

            Rect rect = new Rect();
            Window.GetWindowRect(desktopWindowHandle, ref rect);

            return CaptureWindow(desktopWindowHandle, rect.ToRectangle());
        }

        /// <summary>
        /// Creates an Image containing a screenshot of a part of the desktop.
        /// </summary>
        /// <param name="rect">The part of the desktop to capture.</param>
        /// <returns></returns>
        public static Image CaptureDesktop(Rectangle rect)
        {
            IntPtr desktopWindowHandle = Window.GetDesktopWindow();

            return CaptureWindow(desktopWindowHandle, rect);
        }

        /// <summary>
        /// Creates an Image containing a screenshot of a specific window.
        /// </summary>
        /// <param name="handle">The handle to the window.</param>
        /// <param name="relativeCoordinates">Treat the rectangle's coordiantes as relative, if true, or absolute otherwise.</param>
        /// <returns>The image containing a screenshot of the window.</returns>
        public static Image CaptureWindow(IntPtr handle, Rectangle rect, bool relativeCoordinates = true)
        {
            int width = rect.Width;
            int height = rect.Height;

            IntPtr hdcSrc = DeviceContext.GetWindowDC(handle);

            // TODO create a dictionary of handles that has compatible DCs as the values
            // dispose everything inside the dictionary when the ScreenCapture instance is reused
            IntPtr hdcDest = Gdi32.CreateCompatibleDC(hdcSrc);

            IntPtr hBitmap = Gdi32.CreateCompatibleBitmap(hdcSrc, width, height);

            IntPtr hOld = Gdi32.SelectObject(hdcDest, hBitmap);

            if (relativeCoordinates)
                Gdi32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, TernaryRasterOperations.SRCCOPY);
            else
                Gdi32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, rect.Left, rect.Top, TernaryRasterOperations.SRCCOPY);

            Gdi32.SelectObject(hdcDest, hOld);

            Gdi32.DeleteDC(hdcDest);
            DeviceContext.ReleaseDC(handle, hdcSrc);

            Image img = Image.FromHbitmap(hBitmap);

            Gdi32.DeleteObject(hBitmap);
            return img;
        }

        /// <summary>
        /// Captures a screenshot of a specific window, and saves it to a file.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="filename"></param>
        /// <param name="format"></param>
        public static void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format)
        {
            Rect rect = new Rect();
            Window.GetWindowRect(handle, ref rect);

            using Image img = CaptureWindow(handle, rect.ToRectangle());
            img.Save(filename, format);
        }

        /// <summary>
        /// Captures a screenshot of the entire desktop, and saves it to a file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="format"></param>
        public static void CaptureScreenToFile(string filename, ImageFormat format)
        {
            using Image img = CaptureEntireDesktop();
            img.Save(filename, format);
        }

    }
}