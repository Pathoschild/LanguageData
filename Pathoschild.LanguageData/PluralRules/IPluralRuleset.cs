using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Pathoschild.LanguageData.PluralRules.Internal;

namespace Pathoschild.LanguageData.PluralRules
{
	/// <summary>A representation of the plural rules for a language from the the CLDR (http://unicode.org/cldr/charts/supplemental/language_plural_rules.html).</summary>
	public interface IPluralRuleset
	{
		/*********
		** Accessors
		*********/
		/// <summary>The language code in two-letter ISO-639 format.</summary>
		string Language { get; }

		/// <summary>The plural forms supported by the language.</summary>
		IEnumerable<Expression<Func<decimal, bool>>> PluralForms { get; }

		/// <returns>A lambda which takes a quantity and returns the index of the plural form.</returns>
		Lazy<SelectFormDelegate> Selector { get; }


		/*********
		** Methods
		*********/
		/// <summary>A lambda which selects the plural form for a quantity.</summary>
		/// <param name="quantity">The quantity for which to generate a plural form.</param>
		int SelectForm(decimal quantity);
	}
}