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
			var bing1 = new Bing(new Uri("http://www.bing.com"), "california.jpg");
			var bing2 = new Bing(new Uri("http://www.bing.com"), "california.jpg");

			Assert.IsFalse(bing1.Equals(bing2));
			Assert.IsFalse(bing1 == bing2);
		}

		[Test]
		public void SameObject()
		{
			var bing1 = new EquitableBing(new Uri("http://www.bing.com"), "california.jpg");
			var bing2 = new EquitableBing(new Uri("http://www.bing.com"), "california.jpg");

			Assert.IsTrue(bing1.Equals(bing2));
			Assert.IsTrue(bing1 == bing2);
		}
	}

	public class Bing
	{
		public string Image { set; get; }
		public Uri BaseUri { set; get; }

		public Bing(Uri baseUri , string image)
		{
			BaseUri = baseUri;
			Image = image;
		}
	}

	public class EquitableBing
	{
		public string Image { set; get; }
		public Uri BaseUri { set; get; }

		public EquitableBing(Uri baseUri, string image)
		{
			BaseUri = baseUri;
			Image = image;
		}

		protected bool Equals(EquitableBing other)
		{
			return string.Equals(Image, other.Image) && Equals(BaseUri, other.BaseUri);
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
			unchecked
			{
				return ((Image != null ? Image.GetHashCode() : 0) * 397) ^ (BaseUri != null ? BaseUri.GetHashCode() : 0);
			}
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