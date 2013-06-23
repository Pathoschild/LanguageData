using Pathoschild.LanguageData.PluralRules.Internal;

namespace Pathoschild.LanguageData.PluralRules
{
	/// <summary>A plugin which provides language pluralisation rules based on the Unicode Common Language Data Repository.</summary>
	public class PluralRuleRepository
	{
		/// <summary>Get the plural rules for a language.</summary>
		/// <param name="language">The language code in two-letter ISO-639 format.</param>
		/// <returns>Returns a plural ruleset, or <c>null</c> if the language is not recognized.</returns>
		public static IPluralRuleset GetPluralRuleset(string language)
		{
			switch (language)
			{
				case "af": // Afrikaans
				case "asa": // Asu
				case "ast": // Asturian
				case "bem": // Bemba
				case "bez": // Bena
				case "bg": // Bulgarian
				case "bn": // Bengali
				case "brx": // Bodo
				case "ca": // Catalan
				case "cgg": // Chiga
				case "chr": // Cherokee
				case "ckb": // Sorani Kurdish
				case "da": // Danish
				case "de": // German
				case "dv": // Divehi
				case "ee": // Ewe
				case "el": // Greek
				case "en": // English
				case "eo": // Esperanto
				case "es": // Spanish
				case "et": // Estonian
				case "eu": // Basque
				case "fi": // Finnish
				case "fo": // Faroese
				case "fur": // Friulian
				case "fy": // Western Frisian
				case "gl": // Galician
				case "gsw": // Swiss German
				case "gu": // Gujarati
				case "ha": // Hausa
				case "haw": // Hawaiian
				case "hy": // Armenian
				case "is": // Icelandic
				case "it": // Italian
				case "jgo": // Ngomba
				case "jmc": // Machame
				case "kaj": // Jju
				case "kcg": // Tyap
				case "kk": // Kazakh
				case "kkj": // Kako
				case "kl": // Kalaallisut
				case "ks": // Kashmiri
				case "ksb": // Shambala
				case "ku": // Kurdish
				case "ky": // Kirghiz
				case "lb": // Luxembourgish
				case "lg": // Ganda
				case "mas": // Masai
				case "mgo": // Meta'
				case "ml": // Malayalam
				case "mn": // Mongolian
				case "mr": // Marathi
				case "nah": // Nahuatl
				case "nb": // Norwegian Bokmål
				case "nd": // North Ndebele
				case "ne": // Nepali
				case "nl": // Dutch
				case "nn": // Norwegian Nynorsk
				case "nnh": // Ngiemboon
				case "no": // Norwegian
				case "nr": // South Ndebele
				case "ny": // Nyanja
				case "nyn": // Nyankole
				case "om": // Oromo
				case "or": // Oriya
				case "os": // Ossetic
				case "pa": // Punjabi
				case "pap": // Papiamento
				case "ps": // Pashto
				case "pt": // Portuguese
				case "rm": // Romansh
				case "rof": // Rombo
				case "rwk": // Rwa
				case "saq": // Samburu
				case "seh": // Sena
				case "sn": // Shona
				case "so": // Somali
				case "sq": // Albanian
				case "ss": // Swati
				case "ssy": // Saho
				case "st": // Southern Sotho
				case "sv": // Swedish
				case "sw": // Swahili
				case "syr": // Syriac
				case "ta": // Tamil
				case "te": // Telugu
				case "teo": // Teso
				case "tig": // Tigre
				case "tk": // Turkmen
				case "tn": // Tswana
				case "ts": // Tsonga
				case "ur": // Urdu
				case "ve": // Venda
				case "vo": // Volapük
				case "vun": // Vunjo
				case "wae": // Walser
				case "xh": // Xhosa
				case "xog": // Soga
				case "zu": // Zulu
					// one → n is 1
					return new PluralRuleset(language,
						n => n == 1
					);

				case "az": // Azerbaijani
				case "bm": // Bambara
				case "bo": // Tibetan
				case "dz": // Dzongkha
				case "fa": // Persian
				case "hu": // Hungarian
				case "id": // Indonesian
				case "ig": // Igbo
				case "ii": // Sichuan Yi
				case "ja": // Japanese
				case "jv": // Javanese
				case "ka": // Georgian
				case "kde": // Makonde
				case "kea": // Kabuverdianu
				case "km": // Khmer
				case "kn": // Kannada
				case "ko": // Korean
				case "lo": // Lao
				case "ms": // Malay
				case "my": // Burmese
				case "root": // Root
				case "sah": // Sakha
				case "ses": // Koyraboro Senni
				case "sg": // Sango
				case "th": // Thai
				case "to": // Tongan
				case "tr": // Turkish
				case "vi": // Vietnamese
				case "wo": // Wolof
				case "yo": // Yoruba
				case "zh": // Chinese
					// only singular form
					return new PluralRuleset(language);

				case "ak": // Akan
				case "am": // Amharic
				case "bh": // Bihari
				case "fil": // Filipino
				case "guw": // Gun
				case "hi": // Hindi
				case "ln": // Lingala
				case "mg": // Malagasy
				case "nso": // Northern Sotho
				case "ti": // Tigrinya
				case "tl": // Tagalog
				case "wa": // Walloon
					// one → n in 0..1
					return new PluralRuleset(language,
						n => n.In(0, 1)
					);

				case "iu": // Inuktitut
				case "kw": // Cornish
				case "naq": // Nama
				case "se": // Northern Sami
				case "sma": // Southern Sami
				case "smi": // Sami Language
				case "smj": // Lule Sami
				case "smn": // Inari Sami
				case "sms": // Skolt Sami
					// one → n is 1
					// two → n is 2
					return new PluralRuleset(language,
						n => n == 1,
						n => n == 2
					);

				case "be": // Belarusian
				case "bs": // Bosnian
				case "hr": // Croatian
				case "ru": // Russian
				case "sh": // Serbo-Croatian
				case "sr": // Serbian
				case "uk": // Ukrainian
					// one → n mod 10 is 1 and n mod 100 is not 11
					// few → n mod 10 in 2..4 and n mod 100 not in 12..14
					// many → n mod 10 is 0 or n mod 10 in 5..9 or n mod 100 in 11..14
					return new PluralRuleset(language,
						n => n.Mod(10) == 1 && n.Mod(100) != 11,
						n => n.Mod(10).In(2, 4) && !n.Mod(100).In(12, 14),
						n => n.Mod(10) == 0 || n.Mod(10).In(5, 9) || n.Mod(100).In(11, 14)
					);

				case "ff": // Fulah
				case "fr": // French
				case "kab": // Kabyle
					// one → n within 0..2 and n is not 2
					return new PluralRuleset(language,
						n => n.Within(0, 2) && n != 2
					);

				case "cs": // Czech
				case "sk": // Slovak
					// one → n is 1
					// few → n in 2..4
					return new PluralRuleset(language,
						n => n == 1,
						n => n.In(2, 4)
					);

				case "mo": // Moldavian
				case "ro": // Romanian
					// one → n is 1
					// few → n is 0 OR n is not 1 AND n mod 100 in 1..19
					return new PluralRuleset(language,
						n => n == 1,
						n => n == 0 || (n != 1 && n.Mod(100).In(1, 19))
					);

				case "he": // Hebrew
					// one → n is 1
					// two → n is 2
					// many → n is not 0 AND n mod 10 is 0
					return new PluralRuleset(language,
						n => n == 1,
						n => n == 2,
						n => n != 0 && n.Mod(10) == 0
					);

				case "ar": // Arabic
					// zero → n is 0
					// one → n is 1
					// two → n is 2
					// few → n mod 100 in 3..10
					// many → n mod 100 in 11..99
					return new PluralRuleset(language,
						n => n == 0,
						n => n == 1,
						n => n == 2,
						n => n.Mod(100).In(3, 10),
						n => n.Mod(100).In(11, 99)
					);

				case "lag": // Langi
					// zero → n is 0
					// one → n within 0..2 and n is not 0 and n is not 2
					return new PluralRuleset(language,
						n => n == 0,
						n => n.Within(0, 2) && n != 0 && n != 2
					);

				// 3 forms
				case "lt": // Lithuanian
					// one → n mod 10 is 1 and n mod 100 not in 11..19
					// few → n mod 10 in 2..9 and n mod 100 not in 11..19
					return new PluralRuleset(language,
						n => n.Mod(10) == 1 && !n.Mod(100).In(11, 19),
						n => n.Mod(10).In(2, 9) && !n.Mod(100).In(11, 19)
					);

				// 2 forms
				case "mk": // Macedonian
					// one → n mod 10 is 1 and n is not 11
					return new PluralRuleset(language,
						n => n.Mod(10) == 1 && n != 11
					);

				// 4 forms
				case "mt": // Maltese
					// one → n is 1
					// few → n is 0 or n mod 100 in 2..10
					// many → n mod 100 in 11..19
					return new PluralRuleset(language,
						n => n == 1,
						n => n == 0 || n.Mod(100).In(2, 10),
						n => n.Mod(100).In(11, 19)
					);

				// 2 forms
				case "gv": // Manx
					// one → n mod 10 in 1..2 or n mod 20 is 0
					return new PluralRuleset(language,
						n => n.Mod(10).In(1, 2) || n.Mod(20) == 0
					);

				// 4 forms
				case "pl": // Polish
					// one → n is 1
					// few → n mod 10 in 2..4 and n mod 100 not in 12..14
					// many → n is not 1 and n mod 10 in 0..1 or n mod 10 in 5..9 or n mod 100 in 12..14
					return new PluralRuleset(language,
						n => n == 1,
						n => n.Mod(10).In(2, 4) && !n.Mod(100).In(12, 14),
						n => (n != 1 && n.Mod(10).In(0, 1)) || n.Mod(10).In(5, 9) || n.Mod(100).In(12, 14)
					);

				// 3 forms
				case "ksh": // Colognian
					// zero → n is 0
					// one → n is 1
					return new PluralRuleset(language,
						n => n == 0,
						n => n == 1
					);

				// 4 forms
				case "gd": // Scottish Gaelic
					// one → n in 1,11
					// two → n in 2,12
					// few → n in 3..10,13..19
					return new PluralRuleset(language,
						n => n.In(1, 11),
						n => n.In(2, 12),
						n => n.In(3, 10) || n.In(13, 19)
					);

				// 2 forms
				case "tzm": // Central Atlas Tamazight
					// one → n in 0..1 or n in 11..99
					return new PluralRuleset(language,
						n => n.In(0, 1) || n.In(11, 99)
					);

				// 4 forms
				case "sl": // Slovenian
					// one → n mod 100 is 1
					// two → n mod 100 is 2
					// few → n mod 100 in 3..4
					return new PluralRuleset(language,
						n => n.Mod(100) == 1,
						n => n.Mod(100) == 2,
						n => n.Mod(100).In(3, 4)
					);

				// 5 forms
				case "br": // Breton
					// one → n mod 10 is 1 and n mod 100 not in 11,71,91
					// two → n mod 10 is 2 and n mod 100 not in 12,72,92
					// few → n mod 10 in 3..4,9 and n mod 100 not in 10..19,70..79,90..99
					// many → n is not 0 and n mod 1000000 is 0
					return new PluralRuleset(language,
						n => n.Mod(10) == 1 && !(n.Mod(100) == 11 || n.Mod(100) == 71 || n.Mod(100) == 91),
						n => n.Mod(10) == 2 && !(n.Mod(100) == 12 || n.Mod(100) == 72 || n.Mod(100) == 92),
						n => (n.Mod(10).In(3, 4) || n.Mod(10) == 9) && !n.Mod(100).In(10, 19) && !n.Mod(100).In(70, 79) && !n.Mod(100).In(90, 99),
						n => n != 0 && n.Mod(1000000) == 0
					);

				// 3 forms
				case "shi": // Tachelhit
					// one → n within 0..1
					// few → n in 2..10
					return new PluralRuleset(language,
						n => n.Within(0, 1),
						n => n.In(2, 10)
					);

				// 3 forms
				case "lv": // Latvian
					// zero → n is 0
					// one → n mod 10 is 1 and n mod 100 is not 11
					return new PluralRuleset(language,
						n => n == 0,
						n => n.Mod(10) == 1 && n.Mod(100) != 11
					);

				// 6 forms
				case "cy": // Welsh
					// zero → n is 0
					// one → n is 1
					// two → n is 2
					// few → n is 3
					// many → n is 6
					return new PluralRuleset(language,
						n => n == 0,
						n => n == 1,
						n => n == 2,
						n => n == 3,
						n => n == 6
					);

				// 5 forms
				case "ga": // Irish
					// one → n is 1
					// two → n is 2
					// few → n in 3..6
					// many → n in 7..10
					return new PluralRuleset(language,
						n => n == 1,
						n => n == 2,
						n => n.In(3, 6),
						n => n.In(7, 10)
					);

				// Unknown language
				default:
					return null;
			}
		}
	}
}