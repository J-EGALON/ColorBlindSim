using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ColorBlindSim.Properties;

namespace ColorBlindSim
{
    public partial class Form1 : Form
    {
        public enum DisplayMode : short
        {
            Hidden = 0,
            Windowed = 1,
            FullScreen = 2,
            ActiveFilter = 4,
            ScreenShotOK = 5, 
            Align = 6,
            StopFilter = 7,
            Null = -1

        }
        public enum CheckboxEnum : short
        {
            Hidden = -1,
            Unchecked = 0,
            Checked = 1,
            VisibleNochange = 2 

        }

        Bitmap[] AllBlindnessImage= new Bitmap[8];
        private DisplayMode mode;
        int memo_x;
        int memo_y;
        int memo_w;
        int memo_h;
        public Bitmap Screenshot;
        private Timer timer; // pour clignoter
        private Timer timerResize; // pour clignoter
        private bool ready=false;
        private int offsetx;
        private int offsety;

        private CheckboxEnum checkBox;
        public Form1()

        {
            InitializeComponent();
        }

        private void WindowsPositionMemorize()
        {
            memo_x = this.Left;
            memo_y = this.Top;
            memo_w = this.Width;
            memo_h = this.Height;

        }
        private void ChangeMode(DisplayMode  newVal) //ne gère que l'affichage, pas le comportement ni l'état a valider.
        {
            if (mode != newVal)
            {
                switch (newVal)
                 {
                    case DisplayMode.FullScreen: // je passe en plein écran
                        mode = newVal;
                        WindowsPositionMemorize();
                        this.Left = SystemInformation.VirtualScreen.Left;
                        this.Top = SystemInformation.VirtualScreen.Top;
                        this.Width = SystemInformation.VirtualScreen.Width;
                        this.Height = SystemInformation.VirtualScreen.Height;
                        pictureBox_maximise.Visible = false;
                        pictureBox_reduce.Visible = true;

                        break;
                    
                    case DisplayMode.ScreenShotOK: // j'ai fait un screenshot et il est affiché
                        mode = newVal;
                        comboBox1.Visible = true;
                        if (checkBox == CheckboxEnum.Checked)
                            checkBoxMgr(CheckboxEnum.Checked);
                        else
                            checkBoxMgr(CheckboxEnum.VisibleNochange);

                        //pictureBox_background.BackColor = Color.DarkRed;

                        pictureBox_Align_R.Hide();
                        pictureBox_Align_L.Hide();
                        pictureBox_Align_D.Hide();
                        pictureBox_Align_U.Hide();
                        pictureBox_camera.Show();
                        this.Opacity = 100;


                        break;

                    case DisplayMode.Null: // j'affiche le minimum, c comme un init
                        mode = newVal;
                        comboBox1.Visible = false;
                        pictureBox_Align_R.Hide();
                        pictureBox_Align_L.Hide();
                        pictureBox_Align_D.Hide();
                        pictureBox_Align_U.Hide();
                        this.Opacity = 100;
                        checkBoxMgr(CheckboxEnum.Hidden);
                        break;

                    case DisplayMode.Windowed:  //je repasse en fenetre
                        mode = newVal;
                        this.Left = memo_x;
                        this.Top = memo_y;
                        this.Width = memo_w;
                        this.Height = memo_h;
                        pictureBox_maximise.Visible = true;
                        pictureBox_reduce.Visible = false;
                        
                        timer.Stop();
                        pictureBox_background.BackColor = Color.FromArgb(45, 45, 48);
                        break;

                    case DisplayMode.ActiveFilter: // on active le fitre de la combobox
                        mode = newVal;
                        comboBox1.Show();
                        checkBoxMgr( CheckboxEnum.Checked);
                        break;
                    case DisplayMode.StopFilter: // on active le fitre de la combobox
                        mode = newVal;
                        comboBox1.Show();
                        checkBoxMgr(CheckboxEnum.Unchecked);
                        break;

                    case DisplayMode.Align: // on passe a l'alignement
                        mode = newVal;
                        pictureBox_Align_R.Show();
                        pictureBox_Align_L.Show();
                        pictureBox_Align_D.Show();
                        pictureBox_Align_U.Show();
                        this.Opacity = 85;
                        comboBox1.Hide();
                        checkBoxMgr(CheckboxEnum.Hidden);
                        pictureBox_camera.Hide();
                        break;



                }             
            }
        }



        void timerResize_Tick(object sender, EventArgs e)
        {
            Try_Apply_ComboSelection();
            timerResize.Stop();
        }


        void timer_Tick(object sender, EventArgs e)
        {
            if (pictureBox_background.BackColor == Color.FromArgb(45, 45, 48))
                pictureBox_background.BackColor = Color.DarkRed;
            else
                pictureBox_background.BackColor = Color.FromArgb(45, 45, 48);
        }




        public void MakeScreenshot()
        {
            
            this.Hide();
            int screenLeft = SystemInformation.VirtualScreen.Left;
            int screenTop = SystemInformation.VirtualScreen.Top;
            int screenWidth = SystemInformation.VirtualScreen.Width;
            int screenHeight = SystemInformation.VirtualScreen.Height;
            if (Screenshot != null) Screenshot.Dispose();
            Screenshot =null;
            Screenshot = new Bitmap(screenWidth, screenHeight);

            // Draw the screenshot into our bitmap.
            using (Graphics g = Graphics.FromImage(Screenshot))
            {
                g.CopyFromScreen(screenLeft, screenTop, 0, 0, Screenshot.Size);
            }
          
            for (int i = 0; i < AllBlindnessImage.Length; i++)
            {
               if (AllBlindnessImage[i] != null) AllBlindnessImage[i].Dispose();
                AllBlindnessImage[i] = null;
            }
            this.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            
            comboBox1.Items.Add("Protanopia");
            comboBox1.Items.Add("Protanomaly");
            comboBox1.Items.Add("Deuteranopia");
            comboBox1.Items.Add("Deuteranomaly");
            comboBox1.Items.Add("Tritanopia");
            comboBox1.Items.Add("Tritanomaly");
            comboBox1.Items.Add("Achromatopsia");
            comboBox1.Items.Add("Achromatomaly");
                       
            pictureBox_Align_R.Hide();
            pictureBox_Align_L.Hide();
            pictureBox_Align_D.Hide();
            pictureBox_Align_U.Hide();
            offsetx = (int)Settings.Default["Align_X"];
            offsety = (int)Settings.Default["Align_Y"];


            timer = new Timer();
            timer.Interval = 500;
            timer.Enabled = false;
            timer.Tick += new EventHandler(timer_Tick);

            timerResize = new Timer();
            timerResize.Interval = 250;
            timerResize.Enabled = false;
            timerResize.Tick += new EventHandler(timerResize_Tick);

            mode = DisplayMode.Windowed;
            WindowsPositionMemorize();
            ChangeMode(DisplayMode.Null);
            pictureBox_Close.Visible = true;
            comboBox1.Visible = false;
            checkBoxMgr( CheckboxEnum.Hidden);
            ready = true;

        }
                

        private void FitimageInBackground(Bitmap bm)
        {
            int posX, posY, W, h;
            posX = this.Left + offsetx;
            posY = this.Top + offsety;
            W = this.Width;
            h= this.Height;

            posX = (posX >= 0) ? posX: 0;
            posY = (posY >= 0) ? posY : 0;
            W = (W >=( bm.Width- posX)) ? bm.Width - posX : W;
            h = (h >= (bm.Height-posY)) ? bm.Height - posY : h;


            this.BackgroundImage = bm.Clone(new Rectangle(posX, posY, W, h), PixelFormat.Format24bppRgb);
        }


        private void ApplyFilter(int index) //-1 apply none transformation
        {
            Console.WriteLine("ApplyFilter" + index.ToString());

            if ((index >= 0) && (Screenshot !=null))
            {
                if (AllBlindnessImage[index] != null)
                {
                    FitimageInBackground(AllBlindnessImage[index]);                    
                }
                else //build it
                {
                    AllBlindnessImage[index] = ColorBlindMgr.SetColorBlindImage(Screenshot,(ColorBlindMgr.BlindNessType)index);
                    FitimageInBackground(AllBlindnessImage[index]);

                }
            }
            else
            {
                if ((index == -1) && (Screenshot !=null))
                {
                    FitimageInBackground(Screenshot);
                }
                else
                {
                    // on ne devrait jamais arriver ici.
                    this.BackgroundImage = null;
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_reduce_Click(object sender, EventArgs e)
        {
            //  ChangeMode(0);
            // this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            pictureBox_maximise.Show();
            pictureBox_reduce.Hide();
            Try_Apply_ComboSelection();

        }
        #region imports pour screenshots
        public Image CaptureWindow(IntPtr handle)
        {
            // get te hDC of the target window
            IntPtr hdcSrc = User32.GetWindowDC(handle);
            // get the size
            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);
            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;
            // create a device context we can copy to
            IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
            // select the bitmap object
            IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
            // bitblt over
            GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY);
            // restore selection
            GDI32.SelectObject(hdcDest, hOld);
            // clean up 
            GDI32.DeleteDC(hdcDest);
            User32.ReleaseDC(handle, hdcSrc);
            // get a .NET image object for it
            Image img = Image.FromHbitmap(hBitmap);
            // free up the Bitmap object
            GDI32.DeleteObject(hBitmap);
            return img;
        }




        private class GDI32
        {

            public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter
            [DllImport("gdi32.dll")]
            public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
                int nWidth, int nHeight, IntPtr hObjectSource,
                int nXSrc, int nYSrc, int dwRop);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
                int nHeight);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);
            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        }

        private class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }
            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowDC(IntPtr hWnd);
            [DllImport("user32.dll")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
        }
        #endregion

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_MOUSEMOVE = 0x200;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);

                    if ((int)m.Result == HTCLIENT)
                        m.Result = (IntPtr)HTCAPTION;
                    return;

            }

               base.WndProc(ref m);

        }
      

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox == CheckboxEnum.Checked)
                Try_Apply_ComboSelection();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox == CheckboxEnum.Checked)
            {
                if (comboBox1.SelectedItem.ToString().Length > 5)
                    ApplyFilter(comboBox1.SelectedIndex);
            }
            else
            {
            }
        }

        private void pictureBox_camera_Click(object sender, EventArgs e) // faire une capture d'écran et l'afficher
        {
            MakeScreenshot();
            ApplyFilter(-1);
            ChangeMode(DisplayMode.ScreenShotOK);
            checkBoxMgr(CheckboxEnum.VisibleNochange);
        }

        private void pictureBox_checked_Click(object sender, EventArgs e)
        {
            checkBoxMgr( CheckboxEnum.Unchecked);
            ApplyFilter(-1);
            //timer.Stop();
        }

        private void pictureBox_unchecked_Click(object sender, EventArgs e)
        {
            checkBoxMgr(  CheckboxEnum.Checked);
            //timer.Start();
            Try_Apply_ComboSelection();
        }

        private void checkBoxMgr(CheckboxEnum state) // -1 invisible; 0 decoché; 1 coché; 2 visible sans cgt;
        {
            switch (state)
            {
                case CheckboxEnum.Hidden: // invisible
                    pictureBox_checked.Visible = false;
                    pictureBox_unchecked.Visible = false; 
                    break;
                case CheckboxEnum.Unchecked: // visible et false
                    pictureBox_checked.Visible =  false;
                    pictureBox_unchecked.Visible = true;
                    checkBox = state;
                    break;
                case  CheckboxEnum.Checked: // visible et true
                    pictureBox_checked.Visible = true;
                    pictureBox_unchecked.Visible = false;
                    checkBox = state;
                    break;
                case CheckboxEnum.VisibleNochange: // visible 
                    pictureBox_checked.Visible = (checkBox ==CheckboxEnum.Checked);
                    pictureBox_unchecked.Visible = (checkBox != CheckboxEnum.Checked);
                    break;
            }
        }
      
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string message = "We give no warranties of any kind concerning this Freeware.\n\r" +
                "You can use and redistribute free.\n\r Hope this tool helps.\n\r" +
                "\n\r    Version  :  " + Application.ProductVersion.ToString()+ "\n\r" + 
                "\n\r    Author   :   Julien EGALON (France)";
            DialogResult result = MessageBox.Show(message, "About ColorBlindSim", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void Try_Apply_ComboSelection()
        {
            if (ready)
            {
              if (checkBox == CheckboxEnum.Checked)
                    {
                        if (comboBox1.SelectedItem != null)
                        {
                         
                            ApplyFilter(comboBox1.SelectedIndex);
                        }
                        else    ApplyFilter(-1);

                }
                else ApplyFilter(-1);
            }
        }




        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form1_ResizeEnd");
            bool GoOn = true;
            int offset = 0;
            if (this.Left < 0) { this.Left = 0; GoOn = false; }
            if (this.Top < 0)  { this.Top = 0; GoOn = false; }
            if (this.Left + this.Width > SystemInformation.VirtualScreen.Width)
            {
                offset = this.Left + this.Width - SystemInformation.VirtualScreen.Width;
                if (this.Width - offset >= this.MinimumSize.Width) //je reste plus grand que la taille min : je peux réduire
                    this.Width = this.Width - offset;
                else
                { //je reduis au max: je décale 
                    this.Left = SystemInformation.VirtualScreen.Width - this.MinimumSize.Width;
                    this.Width = this.MinimumSize.Width;
                }
                GoOn = false;
            }
            if (this.Top + this.Height > SystemInformation.VirtualScreen.Height)
            {
                offset = this.Top + this.Height - SystemInformation.VirtualScreen.Height;
                if (this.Height - offset >= this.MinimumSize.Height) //je reste plus grand que la taille min : je peux réduire
                    this.Height = this.Height - offset;
                else
                { //je reduis au max: je décale 
                    this.Top = SystemInformation.VirtualScreen.Height - this.MinimumSize.Height;
                    this.Height = this.MinimumSize.Height;
                }
                GoOn = false;
            }

            if (GoOn)
            {
                MakeScreenshot();
                Try_Apply_ComboSelection();
               
            }
               
            else
                timerResize.Start();

        }

        private void pictureBox_rendu_Click(object sender, EventArgs e)
        {
            Try_Apply_ComboSelection();
        }

  

 

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form1_KeyPress " + e.KeyChar.ToString());

            switch (e.KeyChar)
            {
                case (char)Keys.Return:
                    e.Handled = true;
                    MakeScreenshot();
                    return;
                case (char)Keys.J :
                    e.Handled = true;
                    offsetx = offsetx + 1;
                    if (comboBox1.SelectedItem.ToString().Length > 5)
                    {
                        checkBoxMgr( CheckboxEnum.Checked);
                        ApplyFilter(comboBox1.SelectedIndex);
                    }
                    return;
                case (char)Keys.K:
                    e.Handled = true;
                    offsetx = offsetx - 1;
                    if (comboBox1.SelectedItem.ToString().Length > 5)
                    {
                        checkBoxMgr( CheckboxEnum.Checked);
                        ApplyFilter(comboBox1.SelectedIndex);
                    }
                    return;
                case (char)Keys.T:
                    e.Handled = true;
                    offsety = offsety - 1;
                    if (comboBox1.SelectedItem.ToString().Length > 5)
                    {
                        checkBoxMgr( CheckboxEnum.Checked);
                        ApplyFilter(comboBox1.SelectedIndex);
                    }
                    return;
                case (char)Keys.G:
                    e.Handled = true;
                    offsety = offsety + 1;
                    if (comboBox1.SelectedItem.ToString().Length > 5)
                    {
                        checkBoxMgr( CheckboxEnum.Checked);
                        ApplyFilter(comboBox1.SelectedIndex);
                    }
                    return;




            }
        }

        private void pictureBox_positioning_Click(object sender, EventArgs e) // mode alignement
        {
            comboBox1.SelectedIndex = 0;
            checkBoxMgr( CheckboxEnum.Hidden);
            comboBox1.Enabled=false;
        }

        private void pictureBox_maximise_Click(object sender, EventArgs e) // on agrandit la fenetre
        {
            this.WindowState = FormWindowState.Maximized;
            pictureBox_maximise.Hide();
            pictureBox_reduce.Show();
            Try_Apply_ComboSelection();
        }

        private void pictureBox2_Click(object sender, EventArgs e) //alignement
        {

            if (ready)
            {
                if (pictureBox_Align_R.Visible) // affiché, je dois sortir du mode alignement
                {
                    Settings.Default["Align_X"] = offsetx;
                    Settings.Default["Align_Y"] = offsety;
                    Settings.Default.Save();
                    ChangeMode(DisplayMode.ScreenShotOK);
                }
                else // activer l'alignement
                {
                    ChangeMode(DisplayMode.Align);

                    MakeScreenshot();
                    ApplyFilter(-1);
                    
                }


            }
          

        }

        private void pictureBox_Align_R_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Screenshot.Clone(new Rectangle(this.Left + --offsetx, this.Top + offsety, this.Width, this.Height), PixelFormat.Format24bppRgb);
        }

        private void pictureBox_Align_U_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Screenshot.Clone(new Rectangle(this.Left + offsetx, this.Top + ++offsety, this.Width, this.Height), PixelFormat.Format24bppRgb);
        }

        private void pictureBox_Align_L_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Screenshot.Clone(new Rectangle(this.Left + ++offsetx, this.Top + offsety, this.Width, this.Height), PixelFormat.Format24bppRgb);
        }

        private void pictureBox_Align_D_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Screenshot.Clone(new Rectangle(this.Left + offsetx, this.Top + --offsety, this.Width, this.Height), PixelFormat.Format24bppRgb);
        }
    }
}
