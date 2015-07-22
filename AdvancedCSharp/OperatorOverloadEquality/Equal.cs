using System;
using NUnit.Framework;

namespace OperatorsOverload
{
	[TestFixture]
	public class Equal
	{
		[Test]
		public void NotSameObject()
		{
			var bing1 = new Bing("california.jpg");
			var bing2 = new Bing("california.jpg");

			Assert.IsFalse(bing1.Equals(bing2));
		}

		[Test]
		public void SameObject()
		{
			var bing1 = new EquitableBing("california.jpg");
			var bing2 = new EquitableBing("california.jpg");

			Assert.IsTrue(bing1.Equals(bing2));
		}
	}

	public class Bing
	{
		private readonly string _image;

		public Bing(string image)
		{
			_image = image;
		}

		public string Image
		{
			get { return _image; }
		}
	}

	public class EquitableBing : IEquatable<EquitableBing>
	{
		private readonly string _image;

		public EquitableBing(string image)
		{
			_image = image;
		}

		public string Image
		{
			get { return _image; }
		}

		public bool Equals(EquitableBing other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return string.Equals(_image, other._image);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((EquitableBing)obj);
		}

		public override int GetHashCode()
		{
			return (_image != null ? _image.GetHashCode() : 0);
		}

		public static bool operator ==(EquitableBing left, EquitableBing right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(EquitableBing left, EquitableBing right)
		{
			return !Equals(left, right);
		}
	}
}