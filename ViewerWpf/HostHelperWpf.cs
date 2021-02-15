using System;
using System.Windows.Interop;
using System.Windows.Media;

namespace ViewerWpf
{
    public class HostHelperWpf: IDisposable
    {
        // Constant values from the "winuser.h" header file.
        internal const int WS_CHILD = 0x40000000,
                           WS_VISIBLE = 0x10000000;

        private UserControlWpf _userControlWpf;
        private bool _disposedValue;

        internal static HwndSource CreateHostHwnd(IntPtr parentHwnd, string windowClassName, int width, int height, HwndSourceHook hwndSourceHook)
        {
            // Set up the parameters for the host hwnd.
            var parameters = new HwndSourceParameters(windowClassName, width, height)
            {
                WindowStyle = WS_VISIBLE | WS_CHILD
            };
            parameters.SetPosition(0, 0);
            parameters.ParentWindow = parentHwnd;
            parameters.HwndSourceHook = hwndSourceHook;

            // Create the host hwnd for the visuals.
            var hwndSource = new HwndSource(parameters);

            // Set the hwnd background color.
            hwndSource.CompositionTarget.BackgroundColor = Colors.White;

            return hwndSource;
        }

        public void InitWpfWindow(IntPtr parentHwnd, string hwndSourceClassName, int width, int height)
        {
            if (HwndSource==null)
            {
                HwndSource = CreateHostHwnd(parentHwnd, hwndSourceClassName, width, height, WndProc);
                HwndSource.SizeToContent = System.Windows.SizeToContent.WidthAndHeight;

                _userControlWpf =new UserControlWpf();
                HwndSource.RootVisual = _userControlWpf;
            }
        }

        public void ResizeWpfWindow(int width, int height)
        {
            if (_userControlWpf!=null)
            {
                _userControlWpf.Width = width;
                _userControlWpf.Height = height;
            }
        }

        public HwndSource HwndSource { get; private set; }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            return IntPtr.Zero;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    HwndSource?.Dispose();
                }

                // Free unmanaged resources (unmanaged objects) and override finalizer
                // Set large fields to null
                _disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~HostHelperWpf()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}