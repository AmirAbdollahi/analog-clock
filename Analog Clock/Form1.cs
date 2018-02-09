using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analog_Clock
{
    public partial class Form1 : Form
    {
        Graphics g;

        bool isSecondBarDrawn = false;
        bool isMinuteBarDrawn = false;
        bool isHourBarDrawn = false;

        double r = 100;
        double xCenter;
        double yCenter;

        double degree = 0;

        double x2Second = 0;
        double y2Second = 0;
        double xSecond = 0;
        double ySecond = 0;

        double x2Minute = 0;
        double y2Minute = 0;
        double xMinute = 0;
        double yMinute = 0;

        double x2Hour = 0;
        double y2Hour = 0;
        double xHour = 0;
        double yHour = 0;

        int hour;
        int minute;
        int second;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            g = this.CreateGraphics();

            g.DrawEllipse(Pens.Black, 30, 30, (float)r * 2, (float)r * 2);

            xCenter = 30 + r;
            yCenter = 30 + r;

            g.FillEllipse(Brushes.Red, (float)xCenter - 2, (float)yCenter - 2, 4, 4);

            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;
            second = DateTime.Now.Second;

            DrawSecondBar(second);
            DrawMinuteBar(minute);
            DrawHourBar(hour);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;
            second = DateTime.Now.Second;

            DrawSecondBar(second);
            DrawMinuteBar(minute);
            DrawHourBar(hour);
        }


        private void DrawSecondBar(int sec)
        {
            double newR = r * 9 / 10;

            if (isSecondBarDrawn == true)
            {
                g.DrawLine(new Pen(this.BackColor, 2), (float)xCenter, (float)yCenter,
                (float)x2Second, (float)y2Second);
            }
            

            if (sec <= 15)
            {
                degree = 6 * (15 - sec);

                ySecond = Math.Sin(degree * Math.PI / 180) * newR;
                xSecond = Math.Sqrt((newR * newR) - (ySecond * ySecond));

                x2Second = xCenter + xSecond;
                y2Second = yCenter - ySecond;
            }
            else if (sec <= 30)
            {
                degree = 6 * (sec - 15);

                ySecond = Math.Sin(degree * Math.PI / 180) * newR;
                xSecond = Math.Sqrt((newR * newR) - (ySecond * ySecond));

                x2Second = xCenter + xSecond;
                y2Second = yCenter + ySecond;
            }
            else if (sec <= 45)
            {
                degree = 6 * (sec - 15);

                ySecond = Math.Sin(degree * Math.PI / 180) * newR;
                xSecond = Math.Sqrt((newR * newR) - (ySecond * ySecond));

                x2Second = xCenter - xSecond;
                y2Second = yCenter + ySecond;
            }
            else if (sec < 60)
            {
                degree = 6 * (sec - 45);

                ySecond = Math.Sin(degree * Math.PI / 180) * newR;
                xSecond = Math.Sqrt((newR * newR) - (ySecond * ySecond));

                x2Second = xCenter - xSecond;
                y2Second = yCenter - ySecond;
            }

            g.DrawLine(new Pen(Brushes.Red, 2), (float)xCenter, (float)yCenter,
                (float)x2Second, (float)y2Second);

            isSecondBarDrawn = true;
        }

        private void DrawMinuteBar(int min)
        {
            double newR = r * 9 / 10;

            if (isMinuteBarDrawn == true)
            {
                g.DrawLine(new Pen(this.BackColor, 3), (float)xCenter, (float)yCenter,
                (float)x2Minute, (float)y2Minute);
            }
            

            if (min <= 15)
            {
                degree = 6 * (15 - min);

                yMinute = Math.Sin(degree * Math.PI / 180) * newR;
                xMinute = Math.Sqrt((newR * newR) - (yMinute * yMinute));

                x2Minute = xCenter + xMinute;
                y2Minute = yCenter - yMinute;
            }
            else if (min <= 30)
            {
                degree = 6 * (min - 15);

                yMinute = Math.Sin(degree * Math.PI / 180) * newR;
                xMinute = Math.Sqrt((newR * newR) - (yMinute * yMinute));

                x2Minute = xCenter + xMinute;
                y2Minute = yCenter + yMinute;
            }
            else if (min <= 45)
            {
                degree = 6 * (min - 15);

                yMinute = Math.Sin(degree * Math.PI / 180) * newR;
                xMinute = Math.Sqrt((newR * newR) - (yMinute * yMinute));

                x2Minute = xCenter - xMinute;
                y2Minute = yCenter + yMinute;
            }
            else if (min < 60)
            {
                degree = 6 * (min - 45);

                yMinute = Math.Sin(degree * Math.PI / 180) * newR;
                xMinute = Math.Sqrt((newR * newR) - (yMinute * yMinute));

                x2Minute = xCenter - xMinute;
                y2Minute = yCenter - yMinute;
            }

            g.DrawLine(new Pen(Brushes.Black, 3), (float)xCenter, (float)yCenter,
                (float)x2Minute, (float)y2Minute);

            isMinuteBarDrawn = true;
        }

        private void DrawHourBar(int h)
        {
            // convert 24 hours to 12 hours:
            int newH;
            if (h <= 12)
            {
                newH = h;
            }
            else
            {
                newH = h - 12;
            }

            double newR = r * 6 / 10;

            if (isHourBarDrawn == true)
            {
                g.DrawLine(new Pen(this.BackColor, 5), (float)xCenter, (float)yCenter,
                (float)x2Hour, (float)y2Hour);
            }

            if (newH <= 3)
            {
                //degree = 6 * (15 - newH);
                if (newH == 1)
                {
                    degree = 6 * 10;
                }
                else if (newH == 2)
                {
                    degree = 6 * 5;
                }
                else if (newH == 3)
                {
                    degree = 6 * 0;
                }

                yHour = Math.Sin(degree * Math.PI / 180) * newR;
                xHour = Math.Sqrt((newR * newR) - (yHour * yHour));

                x2Hour = xCenter + xHour;
                y2Hour = yCenter - yHour;
            }
            else if (newH <= 6)
            {
                //degree = 6 * (newH - 15);
                if (newH == 4)
                {
                    degree = 6 * 5;
                }
                else if (newH == 5)
                {
                    degree = 6 * 10;
                }
                else if (newH == 6)
                {
                    degree = 6 * 15;
                }

                yHour = Math.Sin(degree * Math.PI / 180) * newR;
                xHour = Math.Sqrt((newR * newR) - (yHour * yHour));

                x2Hour = xCenter + xHour;
                y2Hour = yCenter + yHour;
            }
            else if (newH <= 9)
            {
                //degree = 6 * (newH - 15);
                if (newH == 7)
                {
                    degree = 6 * 10;
                }
                else if (newH == 8)
                {
                    degree = 6 * 5;
                }
                else if (newH == 9)
                {
                    degree = 0;
                }

                yHour = Math.Sin(degree * Math.PI / 180) * newR;
                xHour = Math.Sqrt((newR * newR) - (yHour * yHour));

                x2Hour = xCenter - xHour;
                y2Hour = yCenter + yHour;
            }
            else if (newH <= 12)
            {
                //degree = 6 * (newH - 45);

                if (newH == 10)
                {
                    degree = 6 * 5;
                }
                else if (newH == 11)
                {
                    degree = 6 * 10;
                }
                else if (newH == 12)
                {
                    degree = 6 * 15;
                }

                yHour = Math.Sin(degree * Math.PI / 180) * newR;
                xHour = Math.Sqrt((newR * newR) - (yHour * yHour));

                x2Hour = xCenter - xHour;
                y2Hour = yCenter - yHour;
            }

            g.DrawLine(new Pen(Brushes.Black, 5), (float)xCenter, (float)yCenter,
                (float)x2Hour, (float)y2Hour);
            isHourBarDrawn = true;
        }
    }
}
