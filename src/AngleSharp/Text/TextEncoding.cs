namespace AngleSharp.Text
{
    using AngleSharp.Dom;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// Various HTML encoding helpers.
    /// </summary>
    public static class TextEncoding
    {
        #region Encodings

        /// <summary>
        /// Gets the UTF-8 encoding.
        /// </summary>
        public static Encoding Utf8 => _utf8.Value;

        /// <summary>
        /// Gets the UTF-16 (Big Endian) encoding.
        /// </summary>
        public static Encoding Utf16Be => _utf16Be.Value;

        /// <summary>
        /// Gets the UTF-16 (Little Endian) encoding.
        /// </summary>
        public static Encoding Utf16Le => _utf16Le.Value;

        /// <summary>
        /// Gets the UTF-32 (Little Endian) encoding.
        /// </summary>
        public static Encoding Utf32Le => _utf32Le.Value;

        /// <summary>
        /// Gets the UTF-32 (Little Endian) encoding.
        /// </summary>
        public static Encoding Utf32Be => _utf32Be.Value;

        /// <summary>
        /// Gets the chinese government standard encoding.
        /// </summary>
        public static Encoding Gb18030 => _gb18030.Value;

        /// <summary>
        /// Gets the Big5 encoding.
        /// </summary>
        public static Encoding Big5 => _big5.Value;

        /// <summary>
        /// Gets the Windows-874 encoding.
        /// </summary>
        public static Encoding Windows874 => _windows874.Value;

        /// <summary>
        /// Gets the Windows-1250 encoding.
        /// </summary>
        public static Encoding Windows1250 => _windows1250.Value;

        /// <summary>
        /// Gets the Windows-1251 encoding.
        /// </summary>
        public static Encoding Windows1251 => _windows1251.Value;

        /// <summary>
        /// Gets the Windows-1252 encoding.
        /// </summary>
        public static Encoding Windows1252 => _windows1252.Value;

        /// <summary>
        /// Gets the Windows-1253 encoding.
        /// </summary>
        public static Encoding Windows1253 => _windows1253.Value;

        /// <summary>
        /// Gets the Windows-1254 encoding.
        /// </summary>
        public static Encoding Windows1254 => _windows1254.Value;

        /// <summary>
        /// Gets the Windows-1255 encoding.
        /// </summary>
        public static Encoding Windows1255 => _windows1255.Value;

        /// <summary>
        /// Gets the Windows-1256 encoding.
        /// </summary>
        public static Encoding Windows1256 => _windows1256.Value;

        /// <summary>
        /// Gets the Windows-1257 encoding.
        /// </summary>
        public static Encoding Windows1257 => _windows1257.Value;

        /// <summary>
        /// Gets the Windows-1258 encoding.
        /// </summary>
        public static Encoding Windows1258 => _windows1258.Value;

        /// <summary>
        /// Gets the iso-8859-2 encoding.
        /// </summary>
        public static Encoding Latin2 => _latin2.Value;

        /// <summary>
        /// Gets the iso-8859-53 encoding.
        /// </summary>
        public static Encoding Latin3 => _latin3.Value;

        /// <summary>
        /// Gets the iso-8859-4 encoding.
        /// </summary>
        public static Encoding Latin4 => _latin4.Value;

        /// <summary>
        /// Gets the iso-8859-5 encoding.
        /// </summary>
        public static Encoding Latin5 => _latin5.Value;

        /// <summary>
        /// Gets the iso-8859-13 encoding.
        /// </summary>
        public static Encoding Latin13 => _latin13.Value;

        /// <summary>
        /// Gets the US-ASCII encoding.
        /// </summary>
        public static Encoding UsAscii => _usAscii.Value;

        /// <summary>
        /// Gets the ks_c_5601-1987 encoding.
        /// </summary>
        public static Encoding Korean => _korean.Value;

        #endregion

        #region Fields

        private static readonly Lazy<Encoding> _utf8 = new(() => new UTF8Encoding(false));
        private static readonly Lazy<Encoding> _utf16Be = new(() => new UnicodeEncoding(true, false));
        private static readonly Lazy<Encoding> _utf16Le = new(() => new UnicodeEncoding(false, false));
        private static readonly Lazy<Encoding> _utf32Le = new(() => GetEncoding("UTF-32LE"));
        private static readonly Lazy<Encoding> _utf32Be = new(() => GetEncoding("UTF-32BE"));
        private static readonly Lazy<Encoding> _gb18030 = new(() => GetEncoding("GB18030"));
        private static readonly Lazy<Encoding> _big5 = new(() => GetEncoding("big5"));
        private static readonly Lazy<Encoding> _windows874 = new(() => GetEncoding("windows-874"));
        private static readonly Lazy<Encoding> _windows1250 = new(() => GetEncoding("windows-1250"));
        private static readonly Lazy<Encoding> _windows1251 = new(() => GetEncoding("windows-1251"));
        private static readonly Lazy<Encoding> _windows1252 = new(() => GetEncoding("windows-1252"));
        private static readonly Lazy<Encoding> _windows1253 = new(() => GetEncoding("windows-1253"));
        private static readonly Lazy<Encoding> _windows1254 = new(() => GetEncoding("windows-1254"));
        private static readonly Lazy<Encoding> _windows1255 = new(() => GetEncoding("windows-1255"));
        private static readonly Lazy<Encoding> _windows1256 = new(() => GetEncoding("windows-1256"));
        private static readonly Lazy<Encoding> _windows1257 = new(() => GetEncoding("windows-1257"));
        private static readonly Lazy<Encoding> _windows1258 = new(() => GetEncoding("windows-1258"));
        private static readonly Lazy<Encoding> _latin2 = new(() => GetEncoding("iso-8859-2"));
        private static readonly Lazy<Encoding> _latin3 = new(() => GetEncoding("iso-8859-3"));
        private static readonly Lazy<Encoding> _latin4 = new(() => GetEncoding("iso-8859-4"));
        private static readonly Lazy<Encoding> _latin5 = new(() => GetEncoding("iso-8859-5"));
        private static readonly Lazy<Encoding> _latin6 = new(() => GetEncoding("iso-8859-6"));
        private static readonly Lazy<Encoding> _latin7 = new(() => GetEncoding("iso-8859-7"));
        private static readonly Lazy<Encoding> _latin8 = new(() => GetEncoding("iso-8859-8"));
        private static readonly Lazy<Encoding> _latin13 = new(() => GetEncoding("iso-8859-13"));
        private static readonly Lazy<Encoding> _latin15 = new(() => GetEncoding("iso-8859-15"));
        private static readonly Lazy<Encoding> _latini = new(() => GetEncoding("iso-8859-8-i"));
        private static readonly Lazy<Encoding> _usAscii = new(() => GetEncoding("us-ascii"));
        private static readonly Lazy<Encoding> _korean = new(() => GetEncoding("ks_c_5601-1987"));
        private static readonly Lazy<Encoding> _macintosh = new(() => GetEncoding("macintosh"));
        private static readonly Lazy<Encoding> _maccyrillic = new(() => GetEncoding("x-mac-cyrillic"));
        private static readonly Lazy<Encoding> _i866 = new(() => GetEncoding("cp866"));
        private static readonly Lazy<Encoding> _kr = new(() => GetEncoding("koi8-r"));
        private static readonly Lazy<Encoding> _koi8u = new(() => GetEncoding("koi8-u"));
        private static readonly Lazy<Encoding> _chineseOfficial = new(() => GetEncoding("GB18030", GetEncoding("x-cp20936")));
        private static readonly Lazy<Encoding> _chineseSimplified = new(() => GetEncoding("x-cp50227"));
        private static readonly Lazy<Encoding> _hzgb2312 = new(() => GetEncoding("hz-gb-2312"));
        private static readonly Lazy<Encoding> _isojp = new(() => GetEncoding("iso-2022-jp"));
        private static readonly Lazy<Encoding> _isokr = new(() => GetEncoding("iso-2022-kr"));
        private static readonly Lazy<Encoding> _isocn = new(() => GetEncoding("iso-2022-cn"));
        private static readonly Lazy<Encoding> _shiftjis = new(() => GetEncoding("shift_jis"));
        private static readonly Lazy<Encoding> _eucjp = new(() => GetEncoding("euc-jp"));
        private static readonly Lazy<Encoding> _euckr = new(() => GetEncoding("euc-kr"));

        private static readonly Dictionary<String, Lazy<Encoding>> encodings = GetAllEncodings();

        #endregion

        #region Extensions

        /// <summary>
        /// Checks if the provided encoding is any UTF-16 encoding.
        /// </summary>
        /// <param name="encoding">The encoding to check.</param>
        /// <returns>The result of the check (UTF-16BE, UTF-16LE).</returns>
        public static Boolean IsUnicode(this Encoding encoding) => encoding == Utf16Be || encoding == Utf16Le;

        #endregion

        #region Methods

        /// <summary>
        /// Tries to extract the encoding from the given http-equiv content
        /// string.
        /// </summary>
        /// <param name="content">The value of the attribute.</param>
        /// <returns>
        /// The extracted encoding or null if the encoding is invalid.
        /// </returns>
        public static Encoding? Parse(String content)
        {
            var encoding = String.Empty;
            var position = 0;

            for (var i = position; i < content.Length - 7; i++)
            {
                if (content.Substring(i).StartsWith(AttributeNames.Charset, StringComparison.OrdinalIgnoreCase))
                {
                    position = i + 7;
                    break;
                }
            }

            if (position > 0 && position < content.Length)
            {
                for (var i = position; i < content.Length - 1; i++)
                {
                    if (content[i].IsSpaceCharacter())
                    {
                        position++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (content[position] != Symbols.Equality)
                {
                    return Parse(content.Substring(position));
                }

                position++;

                for (var i = position; i < content.Length; i++)
                {
                    if (content[i].IsSpaceCharacter())
                    {
                        position++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (position < content.Length)
                {
                    if (content[position] == Symbols.DoubleQuote)
                    {
                        content = content.Substring(position + 1);
                        var index = content.IndexOf(Symbols.DoubleQuote);

                        if (index != -1)
                        {
                            encoding = content.Substring(0, index);
                        }
                    }
                    else if (content[position] == Symbols.SingleQuote)
                    {
                        content = content.Substring(position + 1);
                        var index = content.IndexOf(Symbols.SingleQuote);

                        if (index != -1)
                        {
                            encoding = content.Substring(0, index);
                        }
                    }
                    else
                    {
                        content = content.Substring(position);
                        var index = 0;

                        for (var i = 0; i < content.Length; i++)
                        {
                            if (content[i].IsSpaceCharacter() || content[i] == Symbols.Semicolon)
                            {
                                break;
                            }
                            else
                            {
                                index++;
                            }
                        }

                        encoding = content.Substring(0, index);
                    }
                }
            }

            if (!IsSupported(encoding))
            {
                return null;
            }

            return Resolve(encoding);
        }

        /// <summary>
        /// Detects if a valid encoding has been found in the given charset
        /// string.
        /// </summary>
        /// <param name="charset">The parsed charset string.</param>
        /// <returns>
        /// True if a valid encdoing has been found, otherwise false.
        /// </returns>
        public static Boolean IsSupported(String charset) => encodings.ContainsKey(charset);

        /// <summary>
        /// Resolves an Encoding instance given by the charset string.
        /// If the desired encoding is not found (or supported), then
        /// UTF-8 will be returned.
        /// </summary>
        /// <param name="charset">The charset string.</param>
        /// <returns>An instance of the Encoding class or null.</returns>
        public static Encoding Resolve(String? charset)
        {
            if (charset != null && encodings.TryGetValue(charset, out var encoding))
            {
                return encoding.Value;
            }

            return Utf8;
        }

        #endregion

        #region Helper

        private static Encoding GetEncoding(String name, Encoding? fallback = default)
        {
            try
            {
                return Encoding.GetEncoding(name);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("The platform does not allow using the '{0}' encoding: {1}", name, ex);
                // We use a catch em all since WP8 does throw a different exception than W*.
                return fallback ?? Utf8;
            }
        }

        private static Dictionary<String, Lazy<Encoding>> GetAllEncodings()
        {
            return new Dictionary<String, Lazy<Encoding>>(StringComparer.OrdinalIgnoreCase)
            {
                { "unicode-1-1-utf-8", _utf8 },
                { "utf-8", _utf8 },
                { "utf8", _utf8 },
                { "utf-16be", _utf16Be },
                { "utf-16", _utf16Le },
                { "utf-16le", _utf16Le },
                { "dos-874", _windows874 },
                { "iso-8859-11", _windows874 },
                { "iso8859-11", _windows874 },
                { "iso885911", _windows874 },
                { "tis-620", _windows874 },
                { "windows-874", _windows874 },
                { "cp1250", _windows1250 },
                { "windows-1250", _windows1250 },
                { "x-cp1250", _windows1250 },
                { "cp1251", _windows1251 },
                { "windows-1251", _windows1251 },
                { "x-cp1251", _windows1251 },
                { "x-user-defined", _windows1252 },
                { "ansi_x3.4-1968", _windows1252 },
                { "ascii", _windows1252 },
                { "cp1252", _windows1252 },
                { "cp819", _windows1252 },
                { "csisolatin1", _windows1252 },
                { "ibm819", _windows1252 },
                { "iso-8859-1", _windows1252 },
                { "iso-ir-100", _windows1252 },
                { "iso8859-1", _windows1252 },
                { "iso88591", _windows1252 },
                { "iso_8859-1", _windows1252 },
                { "iso_8859-1:1987", _windows1252 },
                { "l1", _windows1252 },
                { "latin1", _windows1252 },
                { "us-ascii", _windows1252 },
                { "windows-1252", _windows1252 },
                { "x-cp1252", _windows1252 },
                { "cp1253", _windows1253 },
                { "windows-1253", _windows1253 },
                { "x-cp1253", _windows1253 },
                { "cp1254", _windows1254 },
                { "csisolatin5", _windows1254 },
                { "iso-8859-9", _windows1254 },
                { "iso-ir-148", _windows1254 },
                { "iso8859-9", _windows1254 },
                { "iso88599", _windows1254 },
                { "iso_8859-9", _windows1254 },
                { "iso_8859-9:1989", _windows1254 },
                { "l5", _windows1254 },
                { "latin5", _windows1254 },
                { "windows-1254", _windows1254 },
                { "x-cp1254", _windows1254 },
                { "cp1255", _windows1255 },
                { "windows-1255", _windows1255 },
                { "x-cp1255", _windows1255 },
                { "cp1256", _windows1256 },
                { "windows-1256", _windows1256 },
                { "x-cp1256", _windows1256 },
                { "cp1257", _windows1257 },
                { "windows-1257", _windows1257 },
                { "x-cp1257", _windows1257 },
                { "cp1258", _windows1258 },
                { "windows-1258", _windows1258 },
                { "x-cp1258", _windows1258 },
                { "csmacintosh", _macintosh },
                { "mac", _macintosh },
                { "macintosh", _macintosh },
                { "x-mac-roman", _macintosh },
                { "x-mac-cyrillic", _maccyrillic },
                { "x-mac-ukrainian", _maccyrillic },
                { "866", _i866 },
                { "cp866", _i866 },
                { "csibm866", _i866 },
                { "ibm866", _i866 },
                { "csisolatin2", _latin2 },
                { "iso-8859-2", _latin2 },
                { "iso-ir-101", _latin2 },
                { "iso8859-2", _latin2 },
                { "iso88592", _latin2 },
                { "iso_8859-2", _latin2 },
                { "iso_8859-2:1987", _latin2 },
                { "l2", _latin2 },
                { "latin2", _latin2 },
                { "csisolatin3", _latin3 },
                { "iso-8859-3", _latin3 },
                { "iso-ir-109", _latin3 },
                { "iso8859-3", _latin3 },
                { "iso88593", _latin3 },
                { "iso_8859-3", _latin3 },
                { "iso_8859-3:1988", _latin3 },
                { "l3", _latin3 },
                { "latin3", _latin3 },
                { "csisolatin4", _latin4 },
                { "iso-8859-4", _latin4 },
                { "iso-ir-110", _latin4 },
                { "iso8859-4", _latin4 },
                { "iso88594", _latin4 },
                { "iso_8859-4", _latin4 },
                { "iso_8859-4:1988", _latin4 },
                { "l4", _latin4 },
                { "latin4", _latin4 },
                { "csisolatincyrillic", _latin5 },
                { "cyrillic", _latin5 },
                { "iso-8859-5", _latin5 },
                { "iso-ir-144", _latin5 },
                { "iso8859-5", _latin5 },
                { "iso88595", _latin5 },
                { "iso_8859-5", _latin5 },
                { "iso_8859-5:1988", _latin5 },
                { "arabic", _latin6 },
                { "asmo-708", _latin6 },
                { "csiso88596e", _latin6 },
                { "csiso88596i", _latin6 },
                { "csisolatinarabic", _latin6 },
                { "ecma-114", _latin6 },
                { "iso-8859-6", _latin6 },
                { "iso-8859-6-e", _latin6 },
                { "iso-8859-6-i", _latin6 },
                { "iso-ir-127", _latin6 },
                { "iso8859-6", _latin6 },
                { "iso88596", _latin6 },
                { "iso_8859-6", _latin6 },
                { "iso_8859-6:1987", _latin6 },
                { "csisolatingreek", _latin7 },
                { "ecma-118", _latin7 },
                { "elot_928", _latin7 },
                { "greek", _latin7 },
                { "greek8", _latin7 },
                { "iso-8859-7", _latin7 },
                { "iso-ir-126", _latin7 },
                { "iso8859-7", _latin7 },
                { "iso88597", _latin7 },
                { "iso_8859-7", _latin7 },
                { "iso_8859-7:1987", _latin7 },
                { "sun_eu_greek", _latin7 },
                { "csiso88598e", _latin8 },
                { "csisolatinhebrew", _latin8 },
                { "hebrew", _latin8 },
                { "iso-8859-8", _latin8 },
                { "iso-8859-8-e", _latin8 },
                { "iso-ir-138", _latin8 },
                { "iso8859-8", _latin8 },
                { "iso88598", _latin8 },
                { "iso_8859-8", _latin8 },
                { "iso_8859-8:1988", _latin8 },
                { "visual", _latin8 },
                { "csiso88598i", _latini },
                { "iso-8859-8-i", _latini },
                { "logical", _latini },
                { "iso-8859-13", _latin13 },
                { "iso8859-13", _latin13 },
                { "iso885913", _latin13 },
                { "csisolatin9", _latin15 },
                { "iso-8859-15", _latin15 },
                { "iso8859-15", _latin15 },
                { "iso885915", _latin15 },
                { "iso_8859-15", _latin15 },
                { "l9", _latin15 },
                { "cskoi8r", _kr },
                { "koi", _kr },
                { "koi8", _kr },
                { "koi8-r", _kr },
                { "koi8_r", _kr },
                { "koi8-u", _koi8u },
                { "chinese", _chineseOfficial },
                { "csgb2312", _chineseOfficial },
                { "csiso58gb231280", _chineseOfficial },
                { "gb2312", _chineseOfficial },
                { "gb_2312", _chineseOfficial },
                { "gb_2312-80", _chineseOfficial },
                { "gbk", _chineseOfficial },
                { "iso-ir-58", _chineseOfficial },
                { "x-gbk", _chineseOfficial },
                { "hz-gb-2312", _hzgb2312 },
                { "gb18030", _gb18030 },
                { "x-cp50227", _chineseSimplified },
                { "iso-22-cn", _chineseSimplified },
                { "big5", _big5 },
                { "big5-hkscs", _big5 },
                { "cn-big5", _big5 },
                { "csbig5", _big5 },
                { "x-x-big5", _big5 },
                { "csiso2022jp", _isojp },
                { "iso-2022-jp", _isojp },
                { "csiso2022kr", _isokr },
                { "iso-2022-kr", _isokr },
                { "iso-2022-cn", _isocn },
                { "iso-2022-cn-ext", _isocn },
                { "shift_jis", _shiftjis },
                { "euc-jp", _eucjp },
                { "euc-kr", _euckr }
            };
        }

        #endregion
    }
}
