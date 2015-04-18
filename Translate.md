# Introduction #

Since 0.6.8.2 ([r84](https://code.google.com/p/my-nds-rom-manager/source/detail?r=84)), the translation is available.

**This page will be modified as the development goes.**

**This How-to is only for those who can compile the [r97](https://code.google.com/p/my-nds-rom-manager/source/detail?r=97) binary.**

## How to translate ? ##

```
<?xml version="1.0" encoding="utf-8"?>
<Language name="English">
  <translate>
    <data name="TabCollection">
      <value>My Collection</value>
    </data>
    <data name="TabDataBase">
      <value>DataBase</value>
    </data>
    <data name="TabMissing">
      <value>Missing Roms</value>
    </data>
    <data name="Roms">
      <value>Roms</value>
    </data>
    <data name="btnFilterDuplicate_Apply">
      <value>Filter Location Duplicate</value>
    </data>
    <data name="btnFilterDuplicate_None">
      <value>No Duplicate Location</value>
    </data>
    <data name="btnFilterDuplicate_Reset">
      <value>Reset Filter Location Duplicate</value>
    </data>
    <data name="btnFilterDuplicate_NoRom">
      <value>No Rom selected</value>
    </data>
    <data name="btnUnzip_Enabled">
      <value>Copy on Linker</value>
    </data>
    <data name="btnUnzip_Disabled">
      <value>File is missing</value>
    </data>
    <data name="btnUnzip_NoRom">
      <value>No Rom selected</value>
    </data>
    <data name="btnDownloadImgNfoOneRom_Enabled">
      <value>Download Img/Nfo</value>
    </data>
    <data name="btnDownloadImgNfoOneRom_Disabled">
      <value>All image present</value>
    </data>
    <data name="btnDownloadImgNfoOneRom_NoRom">
      <value>No Rom selected</value>
    </data>
    <data name="downloadXmlDataBase">
      <value>Downloading Database ...</value>
    </data>
    <data name="downloadTxtVersionDataBase">
      <value>Downloading Version ...</value>
    </data>
    <data name="DataBaseUpToDate">
      <value>DataBase is up to date.</value>
    </data>
    <data name="DataBaseUpToDatePopupTitle">
      <value>Database version</value>
    </data>
    <data name="DataBaseUpdateComplete">
      <value>Update Complete.</value>
    </data>
    <data name="DataBaseUpdateCompletePopupTitle">
      <value>DataBase Update</value>
    </data>
    <data name="UnzipMissingFile">
      <value>File is missing</value>
    </data>
    <data name="UnzipComplete">
      <value>Unzip Complete.</value>
    </data>
    <data name="UnzipCompletePopupTitle">
      <value>Unzip Rom</value>
    </data>
    <data name="IntegrateColumnWhatHappenTitle">
      <value>What happen</value>
    </data>
    <data name="IntegrateColumnFileNameTitle">
      <value>File name</value>
    </data>
    <data name="IntegrateColumnRomNameTitle">
      <value>Rom name</value>
    </data>
    <data name="IntegrateColumnCRCTitle">
      <value>CRC</value>
    </data>
    <data name="IntegrateColumnRomNumberTitle">
      <value>Rom number</value>
    </data>
    <data name="IntegrateNdsFileFound">
      <value>Found {0} NDS file.</value>
    </data>
    <data name="IntegrateNoNdsFileFound">
      <value>No Nds Rom Files found.</value>
    </data>
    <data name="Error">
      <value>Error</value>
    </data>
    <data name="Quit">
      <value>Quit</value>
    </data>
  </translate>
</Language>
```

Change the values, save it under a new xml file (UTF-8 encoded).

Name this file with this codes : [Culture-Names](http://www.csharp-examples.net/culture-names/)

```
CULTURE   SPEC.CULTURE  ENGLISH NAME
--------------------------------------------------------------
                        Invariant Language (Invariant Country)
af          af-ZA       Afrikaans
af-ZA       af-ZA       Afrikaans (South Africa)
ar          ar-SA       Arabic
ar-AE       ar-AE       Arabic (U.A.E.)
ar-BH       ar-BH       Arabic (Bahrain)
ar-DZ       ar-DZ       Arabic (Algeria)
ar-EG       ar-EG       Arabic (Egypt)
ar-IQ       ar-IQ       Arabic (Iraq)
ar-JO       ar-JO       Arabic (Jordan)
ar-KW       ar-KW       Arabic (Kuwait)
ar-LB       ar-LB       Arabic (Lebanon)
ar-LY       ar-LY       Arabic (Libya)
ar-MA       ar-MA       Arabic (Morocco)
ar-OM       ar-OM       Arabic (Oman)
ar-QA       ar-QA       Arabic (Qatar)
ar-SA       ar-SA       Arabic (Saudi Arabia)
ar-SY       ar-SY       Arabic (Syria)
ar-TN       ar-TN       Arabic (Tunisia)
ar-YE       ar-YE       Arabic (Yemen)
az          az-Latn-AZ  Azeri
az-Cyrl-AZ  az-Cyrl-AZ  Azeri (Cyrillic, Azerbaijan)
az-Latn-AZ  az-Latn-AZ  Azeri (Latin, Azerbaijan)
be          be-BY       Belarusian
be-BY       be-BY       Belarusian (Belarus)
bg          bg-BG       Bulgarian
bg-BG       bg-BG       Bulgarian (Bulgaria)
bs-Latn-BA  bs-Latn-BA  Bosnian (Bosnia and Herzegovina)
ca          ca-ES       Catalan
ca-ES       ca-ES       Catalan (Catalan)
cs          cs-CZ       Czech
cs-CZ       cs-CZ       Czech (Czech Republic)
cy-GB       cy-GB       Welsh (United Kingdom)
da          da-DK       Danish
da-DK       da-DK       Danish (Denmark)
de          de-DE       German
de-AT       de-AT       German (Austria)
de-DE       de-DE       German (Germany)
de-CH       de-CH       German (Switzerland)
de-LI       de-LI       German (Liechtenstein)
de-LU       de-LU       German (Luxembourg)
dv          dv-MV       Divehi
dv-MV       dv-MV       Divehi (Maldives)
el          el-GR       Greek
el-GR       el-GR       Greek (Greece)
en          en-US       English
en-029      en-029      English (Caribbean)
en-AU       en-AU       English (Australia)
en-BZ       en-BZ       English (Belize)
en-CA       en-CA       English (Canada)
en-GB       en-GB       English (United Kingdom)
en-IE       en-IE       English (Ireland)
en-JM       en-JM       English (Jamaica)
en-NZ       en-NZ       English (New Zealand)
en-PH       en-PH       English (Republic of the Philippines)
en-TT       en-TT       English (Trinidad and Tobago)
en-US       en-US       English (United States)
en-ZA       en-ZA       English (South Africa)
en-ZW       en-ZW       English (Zimbabwe)
es          es-ES       Spanish
es-AR       es-AR       Spanish (Argentina)
es-BO       es-BO       Spanish (Bolivia)
es-CL       es-CL       Spanish (Chile)
es-CO       es-CO       Spanish (Colombia)
es-CR       es-CR       Spanish (Costa Rica)
es-DO       es-DO       Spanish (Dominican Republic)
es-EC       es-EC       Spanish (Ecuador)
es-ES       es-ES       Spanish (Spain)
es-GT       es-GT       Spanish (Guatemala)
es-HN       es-HN       Spanish (Honduras)
es-MX       es-MX       Spanish (Mexico)
es-NI       es-NI       Spanish (Nicaragua)
es-PA       es-PA       Spanish (Panama)
es-PE       es-PE       Spanish (Peru)
es-PR       es-PR       Spanish (Puerto Rico)
es-PY       es-PY       Spanish (Paraguay)
es-SV       es-SV       Spanish (El Salvador)
es-UY       es-UY       Spanish (Uruguay)
es-VE       es-VE       Spanish (Venezuela)
et          et-EE       Estonian
et-EE       et-EE       Estonian (Estonia)
eu          eu-ES       Basque
eu-ES       eu-ES       Basque (Basque)
fa          fa-IR       Persian
fa-IR       fa-IR       Persian (Iran)
fi          fi-FI       Finnish
fi-FI       fi-FI       Finnish (Finland)
fo          fo-FO       Faroese
fo-FO       fo-FO       Faroese (Faroe Islands)
fr          fr-FR       French
fr-BE       fr-BE       French (Belgium)
fr-CA       fr-CA       French (Canada)
fr-FR       fr-FR       French (France)
fr-CH       fr-CH       French (Switzerland)
fr-LU       fr-LU       French (Luxembourg)
fr-MC       fr-MC       French (Principality of Monaco)
gl          gl-ES       Galician
gl-ES       gl-ES       Galician (Galician)
gu          gu-IN       Gujarati
gu-IN       gu-IN       Gujarati (India)
he          he-IL       Hebrew
he-IL       he-IL       Hebrew (Israel)
hi          hi-IN       Hindi
hi-IN       hi-IN       Hindi (India)
hr          hr-HR       Croatian
hr-BA       hr-BA       Croatian (Bosnia and Herzegovina)
hr-HR       hr-HR       Croatian (Croatia)
hu          hu-HU       Hungarian
hu-HU       hu-HU       Hungarian (Hungary)
hy          hy-AM       Armenian
hy-AM       hy-AM       Armenian (Armenia)
id          id-ID       Indonesian
id-ID       id-ID       Indonesian (Indonesia)
is          is-IS       Icelandic
is-IS       is-IS       Icelandic (Iceland)
it          it-IT       Italian
it-CH       it-CH       Italian (Switzerland)
it-IT       it-IT       Italian (Italy)
ja          ja-JP       Japanese
ja-JP       ja-JP       Japanese (Japan)
ka          ka-GE       Georgian
ka-GE       ka-GE       Georgian (Georgia)
kk          kk-KZ       Kazakh
kk-KZ       kk-KZ       Kazakh (Kazakhstan)
kn          kn-IN       Kannada
kn-IN       kn-IN       Kannada (India)
ko          ko-KR       Korean
kok         kok-IN      Konkani
kok-IN      kok-IN      Konkani (India)
ko-KR       ko-KR       Korean (Korea)
ky          ky-KG       Kyrgyz
ky-KG       ky-KG       Kyrgyz (Kyrgyzstan)
lt          lt-LT       Lithuanian
lt-LT       lt-LT       Lithuanian (Lithuania)
lv          lv-LV       Latvian
lv-LV       lv-LV       Latvian (Latvia)
mi-NZ       mi-NZ       Maori (New Zealand)
mk          mk-MK       Macedonian
mk-MK       mk-MK       Macedonian (Former Yugoslav Republic of Macedonia)
mn          mn-MN       Mongolian
mn-MN       mn-MN       Mongolian (Cyrillic, Mongolia)
mr          mr-IN       Marathi
mr-IN       mr-IN       Marathi (India)
ms          ms-MY       Malay
ms-BN       ms-BN       Malay (Brunei Darussalam)
ms-MY       ms-MY       Malay (Malaysia)
mt-MT       mt-MT       Maltese (Malta)
nb-NO       nb-NO       Norwegian, Bokmal (Norway)
nl          nl-NL       Dutch
nl-BE       nl-BE       Dutch (Belgium)
nl-NL       nl-NL       Dutch (Netherlands)
nn-NO       nn-NO       Norwegian, Nynorsk (Norway)
no          nb-NO       Norwegian
ns-ZA       ns-ZA       Northern Sotho (South Africa)
pa          pa-IN       Punjabi
pa-IN       pa-IN       Punjabi (India)
pl          pl-PL       Polish
pl-PL       pl-PL       Polish (Poland)
pt          pt-BR       Portuguese
pt-BR       pt-BR       Portuguese (Brazil)
pt-PT       pt-PT       Portuguese (Portugal)
quz-BO      quz-BO      Quechua (Bolivia)
quz-EC      quz-EC      Quechua (Ecuador)
quz-PE      quz-PE      Quechua (Peru)
ro          ro-RO       Romanian
ro-RO       ro-RO       Romanian (Romania)
ru          ru-RU       Russian
ru-RU       ru-RU       Russian (Russia)
sa          sa-IN       Sanskrit
sa-IN       sa-IN       Sanskrit (India)
se-FI       se-FI       Sami (Northern) (Finland)
se-NO       se-NO       Sami (Northern) (Norway)
se-SE       se-SE       Sami (Northern) (Sweden)
sk          sk-SK       Slovak
sk-SK       sk-SK       Slovak (Slovakia)
sl          sl-SI       Slovenian
sl-SI       sl-SI       Slovenian (Slovenia)
sma-NO      sma-NO      Sami (Southern) (Norway)
sma-SE      sma-SE      Sami (Southern) (Sweden)
smj-NO      smj-NO      Sami (Lule) (Norway)
smj-SE      smj-SE      Sami (Lule) (Sweden)
smn-FI      smn-FI      Sami (Inari) (Finland)
sms-FI      sms-FI      Sami (Skolt) (Finland)
sq          sq-AL       Albanian
sq-AL       sq-AL       Albanian (Albania)
sr          sr-Latn-CS  Serbian
sr-Cyrl-BA  sr-Cyrl-BA  Serbian (Cyrillic) (Bosnia and Herzegovina)
sr-Cyrl-CS  sr-Cyrl-CS  Serbian (Cyrillic, Serbia)
sr-Latn-BA  sr-Latn-BA  Serbian (Latin) (Bosnia and Herzegovina)
sr-Latn-CS  sr-Latn-CS  Serbian (Latin, Serbia)
sv          sv-SE       Swedish
sv-FI       sv-FI       Swedish (Finland)
sv-SE       sv-SE       Swedish (Sweden)
sw          sw-KE       Kiswahili
sw-KE       sw-KE       Kiswahili (Kenya)
syr         syr-SY      Syriac
syr-SY      syr-SY      Syriac (Syria)
ta          ta-IN       Tamil
ta-IN       ta-IN       Tamil (India)
te          te-IN       Telugu
te-IN       te-IN       Telugu (India)
th          th-TH       Thai
th-TH       th-TH       Thai (Thailand)
tn-ZA       tn-ZA       Tswana (South Africa)
tr          tr-TR       Turkish
tr-TR       tr-TR       Turkish (Turkey)
tt          tt-RU       Tatar
tt-RU       tt-RU       Tatar (Russia)
uk          uk-UA       Ukrainian
uk-UA       uk-UA       Ukrainian (Ukraine)
ur          ur-PK       Urdu
ur-PK       ur-PK       Urdu (Islamic Republic of Pakistan)
uz          uz-Latn-UZ  Uzbek
uz-Cyrl-UZ  uz-Cyrl-UZ  Uzbek (Cyrillic, Uzbekistan)
uz-Latn-UZ  uz-Latn-UZ  Uzbek (Latin, Uzbekistan)
vi          vi-VN       Vietnamese
vi-VN       vi-VN       Vietnamese (Vietnam)
xh-ZA       xh-ZA       Xhosa (South Africa)
zh-CN       zh-CN       Chinese (People's Republic of China)
zh-HK       zh-HK       Chinese (Hong Kong S.A.R.)
zh-CHS      (none)      Chinese (Simplified)
zh-CHT      (none)      Chinese (Traditional)
zh-MO       zh-MO       Chinese (Macao S.A.R.)
zh-SG       zh-SG       Chinese (Singapore)
zh-TW       zh-TW       Chinese (Taiwan)
zu-ZA       zu-ZA       Zulu (South Africa)

```

For exemple : el.xml for Greek.

Modify your NDSCrc\_III.xml like this:

```
<?xml version="1.0" encoding="utf-8"?>
<configuration xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Path StartupPath="true">
    <img>\data\img\</img>
    <nfo>\data\nfo\</nfo>
    <rom>\data\roms\</rom>
    <trash>\trash\</trash>
    <temp>\data\temp\</temp>
    <newrom>\NewRom\</newrom>
    <unknowrom>\UnknowRom\</unknowrom>
    <AlreadyHave>\AlreadyHave\</AlreadyHave>
    <Flags>\data\flags\</Flags>
    <HaveDB>\data\xml\Collection.xml</HaveDB>
    <DB>\data\Xml\ADVANsCEne_NDScrc.xml</DB>
    <Language>\data\lang\</Language>
  </Path>
  <Culture>el</Culture>
</configuration>
```