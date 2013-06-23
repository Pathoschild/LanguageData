using System;
using System.Globalization;
using System.Threading;
using DotLiquid;
using NUnit.Framework;
using Pathoschild.DotLiquid.Plural;

namespace Pathoschild.LanguageData.Tests.Extensions
{
	/// <summary>Ensures that the <see cref="PluralFilter"/> DotLiquid filter behaves correctly.</summary>
	[TestFixture]
	public class DotLiquidPluralTests
	{
		/*********
		** Unit tests
		*********/
		[Test(Description = "Assert that the formatter plugin returns the correct output for an offset date token.")]
		[TestCase("en", "{{ messagecount }} {{ messagecount | plural:'message','messages' }}", 0, Result = "0 messages")]
		[TestCase("en", "{{ messagecount }} {{ messagecount | plural:'message','messages' }}", 1, Result = "1 message")]
		[TestCase("en", "{{ messagecount }} {{ messagecount | plural:'message','messages' }}", 2, Result = "2 messages")]
		[TestCase("iu", "{{ messagecount }} Inuktitut {{ messagecount | plural:'message','dual-messages', 'many-messages' }}", 2, Result = "2 Inuktitut dual-messages")]
		public string Template_RendersPlural(string locale, string message, decimal quantity)
		{
			Thread.CurrentThread.CurrentCulture = new CultureInfo(locale);
			string result = this.GetTemplate(message).Render(Hash.FromAnonymousObject(new { MessageCount = quantity }));
			Console.WriteLine(result);
			return result;
		}


		/*********
		** Protected methods
		*********/
		/// <summary>Construct a formatter instance with the natural time filter registered.</summary>
		/// <param name="message">The message to format.</param>
		public Template GetTemplate(string message)
		{
			Template.RegisterFilter(typeof(PluralFilter));
			return Template.Parse(message);
		}
	}
}
