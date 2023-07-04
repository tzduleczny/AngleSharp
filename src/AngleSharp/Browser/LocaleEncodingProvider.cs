namespace AngleSharp.Browser
{
    using AngleSharp.Text;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents the default loader service. This class can be inherited.
    /// </summary>
    public class LocaleEncodingProvider : IEncodingProvider
    {
        private static readonly Dictionary<String, Lazy<Encoding>> suggestions = new(StringComparer.OrdinalIgnoreCase)
        {
            { "ar", new (() => TextEncoding.Utf8 )},
            { "cy", new (() => TextEncoding.Utf8 )},
            { "fa", new (() => TextEncoding.Utf8 )},
            { "hr", new (() => TextEncoding.Utf8 )},
            { "kk", new (() => TextEncoding.Utf8 )},
            { "mk", new (() => TextEncoding.Utf8 )},
            { "or", new (() => TextEncoding.Utf8 )},
            { "ro", new (() => TextEncoding.Utf8 )},
            { "sr", new (() => TextEncoding.Utf8 )},
            { "vi", new (() => TextEncoding.Utf8 )},
            { "be", new (() => TextEncoding.Latin5 )},
            { "bg", new (() => TextEncoding.Windows1251 )},
            { "ru", new (() => TextEncoding.Windows1251 )},
            { "uk", new (() => TextEncoding.Windows1251 )},
            { "cs", new (() => TextEncoding.Latin2 )},
            { "hu", new (() => TextEncoding.Latin2 )},
            { "pl", new (() => TextEncoding.Latin2 )},
            { "sl", new (() => TextEncoding.Latin2 )},
            { "tr", new (() => TextEncoding.Windows1254 )},
            { "ku", new (() => TextEncoding.Windows1254 )},
            { "he", new (() => TextEncoding.Windows1255 )},
            { "lv", new (() => TextEncoding.Latin13 )},
            { "ja", new (() => TextEncoding.Utf8 )}, //  Windows-31J ???? Replaced by something better anyway
            { "ko", new (() => TextEncoding.Korean )},
            { "lt", new (() => TextEncoding.Windows1257 )},
            { "sk", new (() => TextEncoding.Windows1250 )},
            { "th", new (() => TextEncoding.Windows874 )}
        };

        /// <summary>
        /// Suggests the initial Encoding for the given locale.
        /// </summary>
        /// <param name="locale">
        /// The locale defined by the BCP 47 language tag.
        /// </param>
        /// <returns>The suggested encoding.</returns>
        public virtual Encoding Suggest(String locale)
        {
            if (!String.IsNullOrEmpty(locale) && locale.Length > 1)
            {
                var name = locale.Substring(0, 2);

                if (suggestions.TryGetValue(name, out var encoding))
                {
                    return encoding.Value;
                }
                else if (locale.Isi("zh-cn"))
                {
                    return TextEncoding.Gb18030;
                }
                else if (locale.Isi("zh-tw"))
                {
                    return TextEncoding.Big5;
                }
            }

            return TextEncoding.Windows1252;
        }
    }
}
