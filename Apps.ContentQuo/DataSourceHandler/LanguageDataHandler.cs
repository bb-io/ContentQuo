﻿using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.ContentQuo.DataSourceHandler
{
    public class LanguageDataHandler : EnumDataHandler
    {
        protected override Dictionary<string, string> EnumValues => new()
        {
            { "af-ZA", "Afrikaans (af-ZA)" },
            { "sq-AL", "Albanian (sq-AL)" },
            { "am-ET", "Amharic (Ethiopia) (am-ET)" },
            { "ar-BH", "Arabic (Bahrain) (ar-BH)" },
            { "ar-EG", "Arabic (Egypt) (ar-EG)" },
            { "ar-IQ", "Arabic (Iraq) (ar-IQ)" },
            { "ar-KW", "Arabic (Kuwait) (ar-KW)" },
            { "ar-LB", "Arabic (Lebanon) (ar-LB)" },
            { "ar-001", "Arabic (Modern Standard) (ar-001)" },
            { "ar-MA", "Arabic (Morocco) (ar-MA)" },
            { "ar-OM", "Arabic (Oman) (ar-OM)" },
            { "ar-QA", "Arabic (Qatar) (ar-QA)" },
            { "ar-SA", "Arabic (Saudi Arabia) (ar-SA)" },
            { "ar-AE", "Arabic (U.A.E.) (ar-AE)" },
            { "ar-YE", "Arabic (Yemen) (ar-YE)" },
            { "hy-AM", "Armenian (Eastern) (hy-AM)" },
            { "as-IN", "Assamese (as-IN)" },
            { "az-AZ", "Azerbaijani (az-AZ)" },
            { "bn-BD", "Bangla (Bangladesh) (bn-BD)" },
            { "eu-ES", "Basque (eu-ES)" },
            { "be-BY", "Belarusian (be-BY)" },
            { "bn-IN", "Bengali (bn-IN)" },
            { "bs-Latn-BA", "Bosnian (Latin, Bosnia and Herzegovina) (bs-Latn-BA)" },
            { "bg-BG", "Bulgarian (bg-BG)" },
            { "my-MM", "Burmese (Burma) (my-MM)" },
            { "ca-ES", "Catalan (Spain) (ca-ES)" },
            { "ceb-PH", "Cebuano (Latin, Philippines) (ceb-PH)" },
            { "chr-US", "Cherokee (chr-US)" },
            { "zh-CN", "Chinese Simplified (China) (zh-CN)" },
            { "zh-Hans-HK", "Chinese Simplified (Hong Kong) (zh-Hans-HK)" },
            { "zh-SG", "Chinese Simplified (Singapore) (zh-SG)" },
            { "zh-Hans", "Chinese Simplified (zh-Hans)" },
            { "zh-HK", "Chinese Traditional (Hong Kong) (zh-HK)" },
            { "zh-TW", "Chinese Traditional (Taiwan) (zh-TW)" },
            { "cht-TW", "Classical Traditional Chinese (Taiwan) (cht-TW)" },
            { "hr-HR", "Croatian (hr-HR)" },
            { "cs-CZ", "Czech (cs-CZ)" },
            { "da-DK", "Danish (da-DK)" },
            { "fa-AF", "Dari (Afghanistan) (fa-AF)" },
            { "nl-NL", "Dutch (Netherlands) (nl-NL)" },
            { "en-AU", "English (Australia) (en-AU)" },
            { "en-CA", "English (Canada) (en-CA)" },
            { "en-IN", "English (India) (en-IN)" },
            { "en-IE", "English (Ireland) (en-IE)" },
            { "en-NZ", "English (New Zealand) (en-NZ)" },
            { "en-IX", "English (North India) (en-IX)" },
            { "en-SG", "English (Singapore) (en-SG)" },
            { "en-ZA", "English (South Africa) (en-ZA)" },
            { "en-IY", "English (South India) (en-IY)" },
            { "en-TT", "English (Trinidad & Tobago) (en-TT)" },
            { "en-US", "English (US) (en-US)" },
            { "en-GB", "English (United Kingdom) (en-GB)" },
            { "eo-US", "Esperanto (eo-US)" },
            { "et-EE", "Estonian (et-EE)" },
            { "fa-IR", "Farsi (Iran) (fa-IR)" },
            { "fil-PH", "Filipino (Philippines) (fil-PH)" },
            { "fi-FI", "Finnish (fi-FI)" },
            { "nl-BE", "Flemish (Belgium) (nl-BE)" },
            { "fr-BE", "French (Belgium) (fr-BE)" },
            { "fr-CA", "French (Canada) (fr-CA)" },
            { "fr-FR", "French (France) (fr-FR)" },
            { "fr-LU", "French (Luxembourg) (fr-LU)" },
            { "fr-MR", "French (Mauritius) (fr-MR)" },
            { "fr-SN", "French (Senegal) (fr-SN)" },
            { "fr-CH", "French (Switzerland) (fr-CH)" },
            { "fr-US", "French (USA) (fr-US)" },
            { "ff-SN", "Fulah (Latin, Senegal) (ff-SN)" },
            { "ga-IE", "Gaelic (Ireland) (ga-IE)" },
            { "gl-ES", "Galician (Spain) (gl-ES)" },
            { "ka-GE", "Georgian (ka-GE)" },
            { "de-AT", "German (Austria) (de-AT)" },
            { "de-DE", "German (Germany) (de-DE)" },
            { "de-LI", "German (Liechtenstein) (de-LI)" },
            { "de-CH", "German (Switzerland) (de-CH)" },
            { "el-CY", "Greek (Cyprus) (el-CY)" },
            { "el-GR", "Greek (el-GR)" },
            { "gu-IN", "Gujarati (India) (gu-IN)" },
            { "ht-HT", "Haitian Creole (Haiti) (ht-HT)" },
            { "my-CNH", "Hakha Chin (my-CNH)" },
            { "ha-Latn-NG", "Hausa (Latin, Nigeria) (ha-Latn-NG)" },
            { "fa-HAZ", "Hazaragi (fa-HAZ)" },
            { "he-IL", "Hebrew (he-IL)" },
            { "hi-IN", "Hindi (hi-IN)" },
            { "en-IN", "Hinglish (India) (en-IN)" },
            { "hm-KH", "Hmong (Cambodia) (hm-KH)" },
            { "hm-CN", "Hmong (China) (hm-CN)" },
            { "hm-LA", "Hmong (Laos) (hm-LA)" },
            { "hm-TH", "Hmong (Thailand) (hm-TH)" },
            { "hm-VN", "Hmong (Vietnam) (hm-VN)" },
            { "hu-HU", "Hungarian (hu-HU)" },
            { "is-IS", "Icelandic (is-IS)" },
            { "ig-NG", "Igbo (Nigeria) (ig-NG)" },
            { "id-ID", "Indonesian (id-ID)" },
            { "iu-CA", "Inuktitut (Latin, Canada) (iu-CA)" },
            { "xh-ZA", "IsiXhosa (South Africa) (xh-ZA)" },
            { "zu-ZA", "IsiZulu (South Africa) (zu-ZA)" },
            { "it-IT", "Italian (Italy) (it-IT)" },
            { "it-CH", "Italian (Switzerland) (it-CH)" },
            { "ja-JP", "Japanese (ja-JP)" },
            { "jv-ID", "Javanese (Indonesia) (jv-ID)" },
            { "quc-GC", "K'iche' (Guatemala) (quc-GC)" },
            { "kl-DK", "Kalaallisut (Greenland) (kl-DK)" },
            { "kn-IN", "Kannada (India) (kn-IN)" },
            { "my-KAR", "Karen (my-KAR)" },
            { "kk-KZ", "Kazakh (kk-KZ)" },
            { "km-KH", "Khmer (Cambodia) (km-KH)" },
            { "sw-TZ", "KiSwahili (Tanzania) (sw-TZ)" },
            { "ki-RW", "Kinyarwanda (Rwanda) (ki-RW)" },
            { "kg-CG", "Kongo (Congo) (kg-CG)" },
            { "kok-IN", "Konkani (India) (kok-IN)" },
            { "ko-KR", "Korean (ko-KR)" },
            { "ku-Arab-IQ", "Kurdish (Arabic, Iraq) (ku-Arab-IQ)" },
            { "ku-IQ", "Kurdish (Kurmanji) (ku-IQ)" },
            { "ky-KG", "Kyrgyz (ky-KG)" },
            { "lo-LA", "Lao (Laos) (lo-LA)" },
            { "la-VA", "Latin (Vatikan) (la-VA)" },
            { "lv-LV", "Latvian (lv-LV)" },
            { "lt-LT", "Lithuanian (lt-LT)" },
            { "lb-LU", "Luxembourgish (lb-LU)" },
            { "mk-MK", "Macedonian (mk-MK)" },
            { "mg-MG", "Malagasy (Madagascar) (mg-MG)" },
            { "ml-IN", "Malayalam (India) (ml-IN)" },
            { "ms-MY", "Malaysian (ms-MY)" },
            { "mt-MT", "Maltese (mt-MT)" },
            { "mi-NZ", "Maori (New Zealand) (mi-NZ)" },
            { "mr-IN", "Marathi (India) (mr-IN)" },
            { "myn-MX", "Mayan (Mexico) (myn-MX)" },
            { "mn-MN", "Mongolian (mn-MN)" },
            { "mot-MN", "Mongolian Traditional (Mongolia) (mot-MN)" },
            { "cnr-Cyrl-ME", "Montenegrin (Cyrillic, Montenegro) (cnr-Cyrl-ME)" },
            { "cnr-Latn-ME", "Montenegrin (Latin, Montenegro) (cnr-Latn-ME)" },
            { "XM-XM", "Multilingual (XM-XM)" },
            { "nah-MX", "Nahuatl (Mexico) (nah-MX)" },
            { "nav-US", "Navajo (US) (nav-US)" },
            { "ne-NP", "Nepali (Nepal) (ne-NP)" },
            { "nd-ZW", "North Ndebele (Zimbabwe) (nd-ZW)" },
            { "nb-NO", "Norwegian (Bokmål) (nb-NO)" },
            { "nn-NO", "Norwegian (Nynorsk) (nn-NO)" },
            { "or-IN", "Odia (India) (or-IN)" },
            { "om-ET", "Oromo (Ethiopia) (om-ET)" },
            { "pap-NL", "Papiamento (Netherlands) (pap-NL)" },
            { "ps-AF", "Pashto (Afghanistan) (ps-AF)" },
            { "pin-CN", "Pinyin (PRC) (pin-CN)" },
            { "pl-PL", "Polish (pl-PL)" },
            { "pt-BR", "Portuguese (Brazil) (pt-BR)" },
            { "pt-MZ", "Portuguese (Mozambique) (pt-MZ)" },
            { "pt-PT", "Portuguese (Portugal) (pt-PT)" },
            { "pa-IN", "Punjabi (India) (pa-IN)" },
            { "pa-PK", "Punjabi (Pakistan) (pa-PK)" },
            { "quz-PE", "Quechua (Peru) (quz-PE)" },
            { "ro-MD", "Romanian (Moldova) (ro-MD)" },
            { "ro-RO", "Romanian (Romania) (ro-RO)" },
            { "ru-RU", "Russian (Russia) (ru-RU)" },
            { "sm-WS", "Samoan (sm-WS)" },
            { "sa-IN", "Sanskrit (India) (sa-IN)" },
            { "gd-GB", "Scottish Gaelic (UK) (gd-GB)" },
            { "sr-Cyrl-BA", "Serbian (Cyrillic, Bosnia and Herzegovina) (sr-Cyrl-BA)" },
            { "sr-Cyrl-RS", "Serbian (Cyrillic, Serbia) (sr-Cyrl-RS)" },
            { "sr-YU", "Serbian (Latin, Montenegro, Yugoslavia) (sr-YU)" },
            { "sr-Latn-RS", "Serbian (Latin, Serbia) (sr-Latn-RS)" },
            { "sr-RS", "Serbian (Serbia) (sr-RS)" },
            { "nso-ZA", "Sesotho sa Leboa (South Africa) (nso-ZA)" },
            { "tsn-ZA", "Setswana (South Africa) (tsn-ZA)" },
            { "sn-Latn-ZW", "Shona (Zimbabwe) (sn-Latn-ZW)" },
            { "sd-Arab-PK", "Sindhi (Arabic, Pakistan) (sd-Arab-PK)" },
            { "si-LK", "Sinhala (si-LK)" },
            { "sk-SK", "Slovak (sk-SK)" },
            { "sl-SI", "Slovenian (sl-SI)" },
            { "so-SO", "Somali (Somalia) (so-SO)" },
            { "es-AR", "Spanish (Argentina) (es-AR)" },
            { "es-BO", "Spanish (Bolivia) (es-BO)" },
            { "es-CL", "Spanish (Chile) (es-CL)" },
            { "es-CO", "Spanish (Colombia) (es-CO)" },
            { "es-CR", "Spanish (Costa Rica) (es-CR)" },
            { "es-CU", "Spanish (Cuba) (es-CU)" },
            { "es-DO", "Spanish (Dominicana) (es-DO)" },
            { "es-EC", "Spanish (Ecuador) (es-EC)" },
            { "es-SV", "Spanish (El Salvador) (es-SV)" },
            { "es-GT", "Spanish (Guatemala) (es-GT)" },
            { "es-HN", "Spanish (Honduras) (es-HN)" },
            { "es-001", "Spanish (International) (es-001)" },
            { "es-419", "Spanish (LatAm) (es-419)" },
            { "es-MX", "Spanish (Mexico) (es-MX)" },
            { "es-NI", "Spanish (Nicaragua) (es-NI)" },
            { "es-PA", "Spanish (Panama) (es-PA)" },
            { "es-PY", "Spanish (Paraguay) (es-PY)" },
            { "es-PE", "Spanish (Peru) (es-PE)" },
            { "es-PR", "Spanish (Puerto Rico) (es-PR)" },
            { "es-ES", "Spanish (Spain) (es-ES)" },
            { "es-US", "Spanish (US) (es-US)" },
            { "es-UY", "Spanish (Uruguay) (es-UY)" },
            { "es-VE", "Spanish (Venezuela) (es-VE)" },
            { "sw-KE", "Swahili (Kenya) (sw-KE)" },
            { "sv-FI", "Swedish (Finland) (sv-FI)" },
            { "sv-SE", "Swedish (sv-SE)" },
            { "shi-MA", "Tachelhit (Latin, Morocco) (shi-MA)" },
            { "tl-PH", "Tagalog (tl-PH)" },
            { "tl-PH", "Taglish (Philippines) (tl-PH)" },
            { "tg-Cyrl-TJ", "Tajik (Cyrillic, Tajikistan) (tg-Cyrl-TJ)" },
            { "tzm-MA", "Tamazight (Morocco) (tzm-MA)" },
            { "ta-IN", "Tamil (India) (ta-IN)" },
            { "tt-RU", "Tatar (tt-RU)" },
            { "te-IN", "Telugu (India) (te-IN)" },
            { "tet-ID", "Tetum (Indonesia) (tet-ID)" },
            { "th-TH", "Thai (th-TH)" },
            { "bo-CN", "Tibetan (China) (bo-CN)" },
            { "ti-ET", "Tigrinya (Ethiopia) (ti-ET)" },
            { "tr-TR", "Turkish (tr-TR)" },
            { "tk-TM", "Turkmen (tk-TM)" },
            { "zh-Hant", "UNUSED (zh-Hant)" },
            { "uk-UA", "Ukrainian (uk-UA)" },
            { "ur-IN", "Urdu (India) (ur-IN)" },
            { "ur-PK", "Urdu (ur-PK)" },
            { "ug-CN", "Uyghur (PRC) (ug-CN)" },
            { "uz-UZ", "Uzbek (uz-UZ)" },
            { "ca-ES-Valencia", "Valencian (Spain) (ca-ES-Valencia)" },
            { "vi-VN", "Vietnamese (vi-VN)" },
            { "cy-GB", "Welsh (UK) (cy-GB)" },
            { "wo-SN", "Wolof (Senegal) (wo-SN)" },
            { "yo-NG", "Yoruba (Nigeria) (yo-NG)" },
        };
    }
}
