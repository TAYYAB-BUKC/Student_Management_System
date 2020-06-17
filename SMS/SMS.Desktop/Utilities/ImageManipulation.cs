using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS.Desktop.Utilities
{
	public class ImageManipulation
	{
		public static byte[] ConvertImageIntoBytes(PictureBox pictureBox)
		{
			MemoryStream memoryStream = new MemoryStream();
			pictureBox.Image.Save(memoryStream, pictureBox.Image.RawFormat);
			return memoryStream.GetBuffer();
		}

		public static Image ConvertBytesIntoImage(byte[] bytes)
		{
			MemoryStream memoryStream = new MemoryStream(bytes);
			
			return Image.FromStream(memoryStream);
		}
	}
}
