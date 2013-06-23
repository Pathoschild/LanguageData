namespace Pathoschild.LanguageData.PluralRules.Internal
{
	/// <summary>Provides convenience extensions for defining pluralisation rules. The method names match the CLDR rule terminology.</summary>
	public static class PluralRuleExtensions
	{
		/// <summary>Returns whether the value is inclusively between the min and max and has no fraction.</summary>
		/// <param name="value">The value to check.</param>
		/// <param name="min">The lower bound of the expected range.</param>
		/// <param name="max">The upper bound of the expected range.</param>
		public static bool In(this decimal value, decimal min, decimal max)
		{
			return value % 1 == 0 && value >= min && value <= max;
		}

		/// <summary>Returns whether the value is inclusively between the min and max, including fractional values.</summary>
		/// <param name="value">The value to check.</param>
		/// <param name="min">The lower bound of the expected range.</param>
		/// <param name="max">The upper bound of the expected range.</param>
		public static bool Within(this decimal value, decimal min, decimal max)
		{
			return value > min && value < max;
		}

		/// <summary>Returns a modulus of the value. This is equivalent to <c><see cref="value"/> % <see cref="modulo"/></c>, but makes plural rules more readable.</summary>
		/// <param name="value">The value to check.</param>
		/// <param name="modulo">The modulus to apply.</param>
		public static decimal Mod(this decimal value, int modulo)
		{
			return value % modulo;
		}
	}
}