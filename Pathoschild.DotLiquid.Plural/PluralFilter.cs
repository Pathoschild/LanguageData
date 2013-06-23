using System;
using System.Globalization;
using DotLiquid;
using Pathoschild.LanguageData.PluralRules;

namespace Pathoschild.DotLiquid.Plural
{
	/// <summary>Extends the DotLiquid <see cref="Template"/> with a filter that selects plural forms for a word using the pluralisation rules for the current thread language.</summary>
	/// <example>
	/// This can be used with any numeric token:
	/// <code>You have {{ message_count }} {{ message_count | plural:'message','messages' }} messages.</code>
	/// </example>
	public static class PluralFilter
	{
		/*********
		** Protected methods
		*********/
		/****
		** Int
		****/
		/// <summary>Get the plural form of a word for an arbitrary quantity.</summary>
		/// <param name="quantity">The quantity for which to pluralise a word.</param>
		/// <param name="formA">The first plural form of a word.</param>
		/// <param name="formB">The second plural form of a word.</param>
		/// <param name="formC">The third plural form of a word (or <c>null</c> if there is none).</param>
		/// <param name="formD">The fourth plural form of a word (or <c>null</c> if there is none).</param>
		/// <param name="formE">The fifth plural form of a word (or <c>null</c> if there is none).</param>
		/// <param name="formF">The sixth plural form of a word (or <c>null</c> if there is none).</param>
		public static string Plural(object quantity, string formA, string formB, string formC = null, string formD = null, string formE = null, string formF = null)
		{
			return PluralFilter.GetPlural(Convert.ToDecimal(quantity), formA, formB, formC, formD, formE, formF);
		}

		/*********
		** Protected methods
		*********/
		/// <summary>Get the plural form of a word for an arbitrary quantity.</summary>
		/// <param name="quantity">The quantity for which to pluralise a word.</param>
		/// <param name="forms">The available plural forms of a word.</param>
		private static string GetPlural(decimal quantity, params string[] forms)
		{
			string locale = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
			IPluralRuleset ruleset = PluralRuleRepository.GetPluralRuleset(locale);
			int form = ruleset.SelectForm(quantity);
			if (forms.Length > form)
				return forms[form];
			return forms[forms.Length - 1];
		}
	}
}
