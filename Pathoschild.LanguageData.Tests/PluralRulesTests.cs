using System.Linq;
using NUnit.Framework;
using Pathoschild.LanguageData.PluralRules;

namespace Pathoschild.LanguageData.Tests
{
	/// <summary>Ensures that the <see cref="PluralRuleRepository"/> behaves correctly.</summary>
	[TestFixture]
	public class PluralRulesTests
	{
		[Test(Description = "Assert that the pluralisation rules returned for a language matches the expected data.")]
		[TestCase("en", 2)]
		[TestCase("fr", 2)]
		[TestCase("br", 5)]
		public void PluralRuleRepository_GetPluralRuleset(string locale, int pluralForms)
		{
			IPluralRuleset ruleset = PluralRuleRepository.GetPluralRuleset(locale);

			Assert.AreEqual(locale, ruleset.Language, "The language does not match.");
			Assert.AreEqual(pluralForms, ruleset.PluralForms.Count() + 1, "The number of plural forms does not match.");
		}

		[Test(Description = "Assert that the ruleset for a given languages returns the correct plural form for arbitrary quantities.")]
		[TestCase("en", 0, Result = 1)]
		[TestCase("en", 1, Result = 0)]
		[TestCase("en", 2, Result = 1)]
		[TestCase("fr", 0, Result = 1)]
		[TestCase("fr", 0.5, Result = 0)]
		[TestCase("fr", 1, Result = 0)]
		public int PluralRuleset_SelectForm(string locale, decimal quantity)
		{
			IPluralRuleset ruleset = PluralRuleRepository.GetPluralRuleset(locale);
			return ruleset.SelectForm(quantity);
		}
	}
}
