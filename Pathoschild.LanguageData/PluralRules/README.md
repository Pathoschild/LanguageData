This data is extracted from the [CLDR Language Plural Rules](http://unicode.org/cldr/charts/supplemental/language_plural_rules.html)
table using the quick jQuery script below and a bit of coding. See the [Plural Rules](http://cldr.unicode.org/index/cldr-spec/plural-rules)
article.

This could be generated more easily from the
[XML supplemental](http://unicode.org/repos/cldr/trunk/common/supplemental/plurals.xml), but the
XML data doesn't seem to match and seems outright wrong in some cases. For example, the web page
defines the Latvian zero form as `n is 0`, whereas the XML defines it as
`n mod 10 is 0 or n mod 10 in 11..19 or v is 2 and f mod 10 in 11..19`. The
[CLDR specification](http://unicode.org/reports/tr35/tr35-numbers.html#Language_Plural_Rules) doesn't
explain this discrepancy, nor does it explain what `v` and `f` are in the XML data. For now this library
scrapes the web page.


```js
   // extract languages from table
   var languages = [];
   {
      // scrape table
      var lookup = {};
      $('tr:has(td.source)').each(function(i, row) {
         // read row
         var cells = $(row).find('td');
         var language = {
            name: $(cells[0]).text(),
            code: $(cells[1]).text(),
            rules: $(cells[4]).text()
        };

         // add to lookup
         lookup[language.rules] = lookup[language.rules] || [];
         lookup[language.rules].push(language);
      });

     // build sorted list
      for(var i in lookup)
         languages.push(lookup[i]);
      languages.sort(function(a, b) {
        a.sort(function(x, y) { return x.code > y.code ? 1 : -1; });
        b.sort(function(x, y) { return x.code > y.code ? 1 : -1; });
        return a < b ? 1 : -1;
      });
   }

   // generate output
   for(var i = 0; i < languages.length; i++) {
      var ruleText = languages[i][0].rules;
      var formCount = (ruleText.match(/;/g) || []).length + 1;
  
      console.log('\n');
      console.log('// ' + formCount + ' forms');
      for(var n = 0; n < languages[i].length; n++) {
         console.log('case "' + languages[i][n].code + '": // ' + languages[i][n].name);
      }
      console.log('	// ' + ruleText);
      console.log('	return new PluralRuleset(language, ' + formCount + ', n =>');
      console.log('		');
      console.log('	);');
   }
```