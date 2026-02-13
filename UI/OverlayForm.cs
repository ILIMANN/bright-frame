using BrightFrame.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BrightFrame.UI
{
    public partial class OverlayForm : Form
    {
        private bool isDrawing = false;
        private Point startPoint;
        private Rectangle selectionArea;

        public OverlayForm()
        {
            InitializeComponent();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                startPoint = e.Location;
            }
            
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isDrawing)
            {
                int x = Math.Min(e.X, startPoint.X);
                int y = Math.Min(e.Y, startPoint.Y);
                int width = Math.Abs(e.X - startPoint.X);
                int height = Math.Abs(e.Y - startPoint.Y);

                selectionArea = new Rectangle(x, y, width, height);

                this.Invalidate();
            }
            
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (isDrawing == false) { return; }

            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
                this.Hide();

                ScreenCapture.RegionalScreenCapture(selectionArea);

                this.DialogResult = DialogResult.OK;

                this.Close();


            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (selectionArea.X>0 && selectionArea.Y>0) 
            {
                using (Pen pen = new Pen(Color.FromArgb(32, 174, 255), 2))
                {
                    using (Brush brush = new SolidBrush(Color.FromArgb(50, 32, 174, 255)))
                    {
                        e.Graphics.FillRectangle(brush, selectionArea);
                    }
                    e.Graphics.DrawRectangle(pen, selectionArea);
                }
            }
        }
    }
}
