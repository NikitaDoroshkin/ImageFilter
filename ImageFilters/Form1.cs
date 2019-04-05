using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ImageFilters
{
    public partial class Form1 : Form
    {
        byte[,] SourceImage { get; set; }
               
        Func<int, byte> FixRange = x => (byte)(x < 0 ? 0 : (x > 255 ? 255 : x));

        static public float alpha = 0.08f;


        public Form1()
        {
            InitializeComponent();
            openSourceDialog.Title = "Open Image";
            openSourceDialog.InitialDirectory = Directory.GetCurrentDirectory();
        }

        private void transformButton_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            methodMenuStrip.Show(ptLowerLeft);
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            if (openSourceDialog.ShowDialog() == DialogResult.OK)
            {
                var image = new Bitmap(openSourceDialog.FileName);
                SourceImage = ImageConverter.ImageToByteArray(image);
                sourcePictureBox.Image = image;

                resultPictureBox.Image = null;
            }
        }

        private void ApplyTransform(Func<byte, byte> pointTransformFunc)
        {
            byte[,] result = (byte[,])SourceImage.Clone();
            Func<byte, byte> transformFunc = x => FixRange(pointTransformFunc(x));
            int width = result.GetLength(0), height = result.GetLength(1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    result[x, y] = transformFunc(result[x, y]);
                }
            }

            ShowTransformed(result);
        }

        private void ShowTransformed(byte[,] result)
        {
            resultPictureBox.Image = ImageConverter.ByteArrayToImage(result);
        }

        private void addConstantMenuItem_Click(object sender, EventArgs e)
        {
            int c = Int32.Parse(paramsTextBox.Text);

            ApplyTransform((x) => FixRange(x+c));
        }

        private void multiplyByConstantMenuItem_Click(object sender, EventArgs e)
        {
            double c = double.Parse(paramsTextBox.Text);

            ApplyTransform((x) => FixRange((int)(c * x)));
        }

        private void toNegativeMenuItem_Click(object sender, EventArgs e)
        {
            ApplyTransform((x) => FixRange(255 - x));
        }

        private void powerTransformMenuItem_Click(object sender, EventArgs e)
        {
            double pow = double.Parse(paramsTextBox.Text);
            byte fMax = SourceImage.Cast<byte>().Max();

            ApplyTransform((x) => FixRange((int)(255 * Math.Pow((double)x / fMax, pow))) );
        }

        private void logarithmicTransformMenuItem_Click(object sender, EventArgs e)
        {
            double logMax = Math.Log(1 + SourceImage.Cast<byte>().Max());

            ApplyTransform((x) => FixRange((int)(255 * Math.Log(1 + x)/logMax)));
        }

        private void linearContrastMenuItem_Click(object sender, EventArgs e)
        {
            byte fMax = SourceImage.Cast<byte>().Max();
            byte fMin = SourceImage.Cast<byte>().Min();

            ApplyTransform((x) => FixRange(( 255 * (x - fMin) / (fMax-fMin) )));
        }

        private void globalHistogramMenuItem_Click(object sender, EventArgs e)
        {
            GlobalTransform(GetThresholdWithHistogram);
        }

        private void globalGradientMenuItem_Click(object sender, EventArgs e)
        {
            GlobalTransform(GetThresholdWithGradient);
        }




        private void GlobalTransform(Func<byte[,], byte> thresholdFunc)
        {
            byte[,] result = (byte[,])SourceImage.Clone();
            int width = result.GetLength(0), height = result.GetLength(1);

            byte t = thresholdFunc(result);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    result[x, y] = (byte)(result[x, y] <= t ? 0 : 255);
                }
            }

            ShowTransformed(result);
        }

        public byte GetThresholdWithHistogram(byte[,] grayScaleMatrix)
        {
            float t = 127;
            List<byte> G1 = new List<byte>();
            List<byte> G2 = new List<byte>();
            while (true)
            {
                for (int x = 0; x < grayScaleMatrix.GetLength(0); x++)
                {
                    for (int y = 0; y < grayScaleMatrix.GetLength(1); y++)
                    {
                        if (grayScaleMatrix[x, y] > t)
                        {
                            G1.Add(grayScaleMatrix[x, y]);
                        }
                        else
                        {
                            G2.Add(grayScaleMatrix[x, y]);
                        }
                    }
                }

                float m1 = GetCollectionMediumBrightness(G1);
                float m2 = GetCollectionMediumBrightness(G2);
                float newT = (m1 + m2) / 2;
                if (Math.Abs(newT - t) < 2) // TODO from params
                {
                    return (byte)newT;
                }
                t = newT;
            }
        }

        public float GetCollectionMediumBrightness(List<byte> list)
        {
            if (list.Count == 0)
            {
                return 0;
            }
            long sum = 0;
            foreach (byte brighness in list)
            {
                sum += brighness;
            }

            return (float)sum / (float)list.Count;
        }

        public byte GetThresholdWithGradient(byte[,] grayScaleMatrix)
        {
            float numerator = 0;
            float denominator = 0;
            for (int x = 0; x < grayScaleMatrix.GetLength(0) - 1; x++)
            {
                for (int y = 0; y < grayScaleMatrix.GetLength(1) - 1; y++)
                {
                    numerator += GetGradient(grayScaleMatrix, x, y) * grayScaleMatrix[x, y];
                    denominator += GetGradient(grayScaleMatrix, x, y);
                }
            }
            return (byte)(numerator / denominator);
        }

        public byte GetGradientX(byte[,] grayScaleMatrix, int x, int y)
        {
            return (byte)Math.Abs(grayScaleMatrix[x + 1, y] - grayScaleMatrix[x, y]);
        }

        public byte GetGradientY(byte[,] grayScaleMatrix, int x, int y)
        {
            return (byte)Math.Abs(grayScaleMatrix[x, y + 1] - grayScaleMatrix[x, y]);
        }

        public byte GetGradient(byte[,] grayScaleMatrix, int x, int y)
        {
            return (byte)Math.Max(GetGradientX(grayScaleMatrix, x, y), GetGradientY(grayScaleMatrix, x, y));
        }

        private void adoptiveMenuItem_Click(object sender, EventArgs e)
        {
            AdoptiveTransform();
        }

        public void AdoptiveTransform()
        {
            int k = 1; // TODO params
            int blockSize = 2 * k + 1;
            alpha = float.Parse(paramsTextBox.Text); 

            byte[,] result = (byte[,])SourceImage.Clone();
            int width = result.GetLength(0), height = result.GetLength(1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int currentK;
                    byte t = countT(result, x, y, k, out currentK);

                    result[x, y] = (byte)(adoptiveCheckCriteria(result, x, y, k, t) ? 0 : 255);
                }
            }

            ShowTransformed(result);
        }

        public byte countT(byte[,] grayScaleArray, int m, int n, int k, out int newK)
        {
            int currentK = k;
            int blockSize = 2 * k + 1;
            while (true)
            {
                byte fMax = GetFMax(grayScaleArray, m, n, currentK);
                byte fMin = GetFMin(grayScaleArray, m, n, currentK);
                float p = GetP(grayScaleArray, m, n, currentK);
                float deltaFMax = Math.Abs(p - fMax);
                float deltaFMin = Math.Abs(p - fMin);
                if (deltaFMax > deltaFMin)
                {
                    newK = currentK;
                    return (byte)(alpha * (2.0f / 3.0f * fMin + 1.0f / 3.0f * p));
                }
                else if (deltaFMax < deltaFMin)
                {
                    newK = currentK;
                    return (byte)(alpha * (1.0f / 3.0f * fMin + 2.0f / 3.0f * p));
                }
                else
                {
                    if (fMax != fMin)
                    {
                        currentK++;
                        blockSize = 2 * currentK + 1;
                    }
                    else
                    {
                        newK = currentK;
                        return (byte)(alpha * p);
                    }
                }
            }
        }

        public bool adoptiveCheckCriteria(byte[,] arr, int m, int n, int k, byte t)
        {
            for (int x = -1; x <= 1; x++)
            {
                if (m + x < 0 || m + x >= arr.GetLength(0))
                {
                    continue;
                }
                for (int y = -1; y <= 1; y++)
                {
                    if (n + y < 0 || n + y >= arr.GetLength(1) || (x == 0 && y == 0))
                    {
                        continue;
                    }
                    if (Math.Abs(arr[m, n] - GetP(arr, m + x, n + y, k)) <= t)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static public float GetP(byte[,] arr, int m, int n, int k)
        {
            float sum = 0;
            int amount = 0;
            for (int x = -k; x <= k; x++)
            {
                if (m + x < 0 || m + x >= arr.GetLength(0))
                {
                    continue;
                }
                for (int y = -k; y <= k; y++)
                {
                    if (n + y < 0 || n + y >= arr.GetLength(1))
                    {
                        continue;
                    }
                    sum += arr[m + x, n + y];
                    amount++;
                }
            }
            return sum / amount;
        }

        static public byte GetFMax(byte[,] arr, int m, int n, int k)
        {
            byte max = 0;
            for (int x = -k; x <= k; x++)
            {
                if (m + x < 0 || m + x >= arr.GetLength(0))
                {
                    continue;
                }
                for (int y = -k; y <= k; y++)
                {
                    if (n + y < 0 || n + y >= arr.GetLength(1))
                    {
                        continue;
                    }
                    if (arr[m + x, n + y] > max)
                    {
                        max = arr[m + x, n + y];
                    }
                }
            }
            return max;
        }

        static public byte GetFMin(byte[,] arr, int m, int n, int k)
        {
            byte min = 255;
            for (int x = -k; x <= k; x++)
            {
                if (m + x < 0 || m + x >= arr.GetLength(0))
                {
                    continue;
                }
                for (int y = -k; y <= k; y++)
                {
                    if (n + y < 0 || n + y >= arr.GetLength(1))
                    {
                        continue;
                    }
                    if (arr[m + x, n + y] < min)
                    {
                        min = arr[m + x, n + y];
                    }
                }
            }
            return min;
        }
    }
}
