
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

class Program
{
	static void Main()
	{
		Console.Write("Enter number of sides: ");
		int sides = int.Parse(Console.ReadLine());

		if (sides < 3)
		{
			Console.WriteLine("A polygon must have at least 3 sides!");
			return;
		}

		int sideLength = 100;

		Application.Run(new DrawingForm(sides, sideLength));
	}
}

class DrawingForm : Form
{
	int sides;
	int sideLength;

	public DrawingForm(int sides, int sideLength)
	{
		this.sides = sides;
		this.sideLength = sideLength;

		Text = "Regular Polygon";
		ClientSize = new Size(800, 600);
		BackColor = Color.White;
		StartPosition = FormStartPosition.CenterScreen;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);

		Graphics g = e.Graphics;
		g.SmoothingMode = SmoothingMode.AntiAlias;

		using (Pen pen = new Pen(Color.Black, 2))
		{
			PointF[] points = new PointF[sides];

			float centerX = ClientSize.Width / 2;
			float centerY = ClientSize.Height / 2;

			double radius = sideLength / (2 * Math.Sin(Math.PI / sides));

			for (int i = 0; i < sides; i++)
			{
				double angle = 2 * Math.PI * i / sides - Math.PI / 2;

				float x = centerX + (float)(radius * Math.Cos(angle));
				float y = centerY + (float)(radius * Math.Sin(angle));

				points[i] = new PointF(x, y);
			}

			g.DrawPolygon(pen, points);
		}
	}
}
