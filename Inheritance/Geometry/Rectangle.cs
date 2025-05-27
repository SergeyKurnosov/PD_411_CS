using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometry
{
	internal class Rectangle : Shape
	{
		double with;
		double height;

		public double With
		{
			get => with;
			set => with = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
		}

		public double Height
		{
			get => height;
			set => height = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
		}

		public Rectangle(double with, double height , int start_x , int start_y , int line_with ,  Color color)
			:base(start_x , start_y , line_with , color)
		{
			With = with;
			Height = height;
		}

		public override double GetArea()
		{
			return With * Height;
		}

		public override double GetPerimeter()
		{
			return (Height + With) * 2;
		}

		public override void Draw(PaintEventArgs e)
		{
			Pen pen = new Pen(Color , Line_with );
			e.Graphics.DrawRectangle(pen, Start_x, Start_y, (float)With, (float)Height);
		}

		public override void Info(PaintEventArgs e)
		{
			Console.WriteLine();
			Console.WriteLine(GetType());
			Console.WriteLine($"Ширина :{With} Высота:{Height}");
			base.Info(e);
		}


	}
}
