using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Geometry
{
	internal class Circle:Shape
	{
		double radius;
		public double Radius
		{ 
			get =>radius; 
			set=>radius = value <MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value; 
		}
		public Circle(double radius, int start_x , int start_y , int line_with , Color color)
			:base(start_x , start_y , line_with , color)
		{
			Radius = radius;
		}

		public override double GetArea()
		{
			return Math.PI * Math.Pow(Radius , 2);
		}

		public override double GetPerimeter()
		{
			return 2 * Math.PI * Radius;
		}

		public override void Draw(PaintEventArgs e)
		{
			Pen pen = new Pen(Color , Line_with);
			e.Graphics.DrawEllipse(pen, Start_x, Start_y, (float)Radius * 2, (float)Radius * 2);
		}

		public override void Info(PaintEventArgs e)
		{
			Console.WriteLine();
			Console.WriteLine(GetType());
			Console.WriteLine($"Радиус {Radius}");
			base.Info(e);
		}

	}
}
