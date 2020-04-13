using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorBlindSim
{
    class ColorBlindMgr
    {
        public enum BlindNessType : short
        {
            None = -1,
            Protanopia = 0,
            Protanomaly = 1,
            Deuteranopia = 2,
            Deuteranomaly = 3,
            Tritanopia = 4,
            Tritanomaly = 5,
            Achromatopsia = 6,
            Achromatomaly = 7
        }


        static float[][] BlindNessMatrix;
        static bool init = false;



        public static Bitmap SetColorBlindImage(Bitmap image, BlindNessType colorblindness)
        {
            if (colorblindness != BlindNessType.None && image != null)
            {

                BlindNessMatrix = new float[][] {  //0 default(Protanopia)
		            new float[] { 0.56667f, 0.55833f   , 0,  0, 0},
                    new float[] { .43333f , .44167f    , .24167f,  0, 0},
                    new float[] { 0       , 0          , .75833f ,  0, 0},

                    new float[] {0,  0,  0,  1, 0},
                    new float[] {0,  0,  0,  0, 0}};

                switch (colorblindness)

                {
                    case BlindNessType.Protanopia :              

                    BlindNessMatrix = new float[][] {  //0 Protanopia
		            new float[] { 0.56667f,  0.55833f, 0f     ,  0, 0},
                    new float[] { .43333f , .44167f  , .24167f,  0, 0},
                    new float[] { 0      ,          0, .75833f,  0, 0},

                    new float[] {0,  0,  0,  1, 0},
                    new float[] {0,  0,  0,  0, 0}
                    };
                    init = true;
                    break;
                    case BlindNessType.Protanomaly:
                    BlindNessMatrix = new float[][]  { //1 Protanomaly                        
                    new float[] { 0.81667f, 0.33333f,  0f  ,  0, 0},
                    new float[] { .183333f, .66667f , .125f,  0, 0},
                    new float[] { 0f      , 0       , .875f,  0, 0},

                    new float[] {0,  0,  0,  1, 0},
                    new float[] {0,  0,  0,  0, 0}
                   };
                        init = true;
                        break;
                    case BlindNessType.Deuteranopia:  
                    BlindNessMatrix = new float[][]  { //2 Deuteranopia
                    new float[] { 0.625f, 0.7f  , 0f,  0, 0},
                    new float[] { .375f , .3f  , .3f,  0, 0},
                    new float[] { 0f    , 0    , .7f,  0, 0},

                    new float[] {0,  0,  0,  1, 0},
                    new float[] {0,  0,  0,  0, 0}
                    };
                        init = true;
                        break;
                    case BlindNessType.Deuteranomaly:
                    BlindNessMatrix = new float[][]  { // 3 Deuteranomaly
                    new float[] { 0.8f, 0.25833f,     0f ,  0, 0},
                    new float[] { 0.2f, .74167f , .14167f,  0, 0},
                    new float[] { 0f  , 0       , .85833f,  0, 0},

                    new float[] {0,  0,  0,  1, 0},
                    new float[] {0,  0,  0,  0, 0}
                    };
                        init = true;
                        break;
                    case BlindNessType.Tritanopia:   
                    BlindNessMatrix = new float[][]  {// 4 Tritanopia
                    new float[] { 0.95f, 0f      ,   0f, 0, 0 },
                    new float[] { .05f , .43333f , .475f, 0, 0 },
                    new float[] { 0f   , 0.56667f, .525f, 0, 0 },

                    new float[] { 0, 0, 0, 1, 0 },
                    new float[] { 0, 0, 0, 0, 0 }
                    };
                        init = true;
                        break;
                    case BlindNessType.Tritanomaly:
                    BlindNessMatrix = new float[][]  {// 5 Tritanomaly
                    new float[] { 0.96667f, 0      ,  0f    ,  0, 0},
                    new float[] { .03333f , .73333f, .18333f,  0, 0},
                    new float[] { 0f     , 0.26667f, .81667f,  0, 0},

                    new float[] {0,  0,  0,  1, 0},
                    new float[] {0,  0,  0,  0, 0}

                    };
                        init = true;
                        break;
                    case BlindNessType.Achromatopsia:
                    BlindNessMatrix = new float[][]  {// 6 Achromatopsia
                      new float[] { 0.299f, 0.299f, 0.299f,  0, 0},
                      new float[] { .587f ,  .587f, .587f ,  0, 0},
                      new float[] { .114f , .114f , .114f ,  0, 0},

                      new float[] {0,  0,  0,  1, 0},
                      new float[] {0,  0,  0,  0, 0}
                    };                     
                        init = true;
                        break;
                    case BlindNessType.Achromatomaly:
                    BlindNessMatrix = new float[][]  { // 7 Achromatomaly
                    new float[] { 0.618f, 0.163f, 0.163f,  0, 0},
                    new float[] { .32f  , .775f , .32f  ,  0, 0},
                    new float[] { 0.062f, 0.062f, .516f ,  0, 0},

                    new float[] {0,  0,  0,  1, 0},
                    new float[] {0,  0,  0,  0, 0}
                    };
                        init = true;
                        break;
            }


            try
                {
                    //create a Bitmap the size of the image provided  
                    //Bitmap bmp = new Bitmap(image.Width, image.Height);
                    Bitmap bmp = (Bitmap) image.Clone();
          


                    if (colorblindness == BlindNessType.Achromatopsia)
                    {

                        var toto= 1;


                    }

                    Console.WriteLine("BlindNessMatrix[" + colorblindness.ToString() + "]");

                    // ColorMatrix matrix = new ColorMatrix(BlindNessMatrix[(short)colorblindness]);

                    //create image attributes  
                    ColorMatrix t_Matrix = new ColorMatrix(BlindNessMatrix);
                    ImageAttributes attributes = new ImageAttributes();
                    attributes.SetColorMatrix(t_Matrix);

                    using (Graphics gfx = Graphics.FromImage(bmp))
                    {
                            gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                    }
                    return bmp;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            else return null;
        }
    }
}
