**Pathoschild.LanguageData** is a C# view of the [Unicode Common Locale Data Repository](https://sites.google.com/site/cldr/)
(CLDR). The CLDR provides extensive information about the world's languages. This is a utility
library meant to be used as a building block for larger libraries — it's not meant to be
used directly in applications.

This is a very early version; it currently provides a complete view of the CLDR pluralisation rules
for use in pluralisation code, but nothing else.

## Supported data
### Plural rules
This data provides a view of the CLDR [Language Plural Rules](http://unicode.org/cldr/charts/supplemental/language_plural_rules.html)
(version 23). The pluralisation rules for a language are represented by an `IPluralRuleset`
object, which includes the the language code, lambdas matching each plural form (in the form of an
`Expression<Func<decimal, bool>>`), and a method to select the plural form for a quantity.

This can be used to implement arbitrary message pluralisation for any of the 182 defined languages.
For example, to pluralise the word 'message' in English:

```c#
   // simplified example
   IPluralRuleset ruleset = PluralRulesetFactory.Get("en");
   int pluralForm = ruleset.SelectForm(500);
   string message = String.Format("You have 500 {0}.", new[] { "message", "messages" }[pluralForm]);
```

This can be used as a building block in other libraries. For example, this is used as the basis
for a fully-functional DotLiquid plugin that implements pluralisation (see below).

## Plugins for other libraries
### Pluralisation for DotLiquid
The pluralisation logic is available as a plugin for [DotLiquid](http://dotliquidmarkup.org/) through
the [`Pathoschild.DotLiquid.Plural`](https://nuget.org/packages/Pathoschild.DotLiquid.Plural)
NuGet package. DotLiquid is a safe templating library that lets you format strings with token
replacement, basic logic, and text transforms. For example, this lets us format messages like this:
```c#
   Template.RegisterFilter(typeof(PluralFilter));
   string message = "You have {{ message_count }} {{ message_count | plural:'message','messages' }}.";
   message = Template.Parse(message).Render(Hash.FromAnonymousObject(new { MessageCount = 14 })); // "You have 14 messages."
```