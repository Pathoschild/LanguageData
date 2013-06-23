using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Pathoschild.LanguageData.PluralRules.Internal
{
	/// <summary>A representation of the plural rules for a language from the the CLDR: http://unicode.org/cldr/charts/supplemental/language_plural_rules.html .</summary>
	public class PluralRuleset : IPluralRuleset
	{
		/*********
		** Accessors
		*********/
		/// <summary>The language code in two-letter ISO-639 format.</summary>
		public string Language { get; protected set; }

		/// <summary>The plural forms supported by the language.</summary>
		public IEnumerable<Expression<Func<decimal, bool>>> PluralForms { get; protected set; }

		/// <returns>A lambda which takes a quantity and returns the index of the plural form.</returns>
		public Lazy<SelectFormDelegate> Selector { get; protected set; }


		/*********
		** Public methods
		*********/
		/// <summary>Construct an instance.</summary>
		/// <param name="language">The language code in two-letter ISO-639 format.</param>
		/// <param name="pluralForms">The number of plural forms supported by the language.</param>
		public PluralRuleset(string language, params Expression<Func<decimal, bool>>[] pluralForms)
		{
			this.Language = language;
			this.PluralForms = pluralForms;
			this.Selector = new Lazy<SelectFormDelegate>(() => this.BuildSelector(pluralForms));
		}

		/// <summary>A lambda which selects the plural form for a quantity.</summary>
		/// <param name="quantity">The quantity for which to generate a plural form.</param>
		public int SelectForm(decimal quantity)
		{
			return this.Selector.Value.Invoke(quantity);
		}


		/*********
		** Protected methods
		*********/
		/// <summary>Construct a lambda which takes a quantity and returns the index of the plural form.</summary>
		/// <param name="pluralForms">The number of plural forms supported by the language.</param>
		protected SelectFormDelegate BuildSelector(params Expression<Func<decimal, bool>>[] pluralForms)
		{
			// handle no plurals
			if (pluralForms.Length == 0)
				return n => 0;

			// generate selector expression
			int form = pluralForms.Length;
			ParameterExpression param = Expression.Parameter(typeof (decimal), "n");
			Expression expression = Expression.Constant(form--);
			foreach (var condition in pluralForms.Reverse())
				expression = Expression.Condition(Expression.Invoke(condition, param), Expression.Constant(form--), expression);
			Expression<SelectFormDelegate> lambda = Expression.Lambda<SelectFormDelegate>(expression, param);

			return lambda.Compile();
		}
	}
}