namespace Pathoschild.LanguageData.PluralRules.Internal
{
	/// <summary>A lambda which selects the plural form for a quantity.</summary>
	/// <param name="quantity">The quantity for which to generate a plural form.</param>
	public delegate int SelectFormDelegate(decimal quantity);
}