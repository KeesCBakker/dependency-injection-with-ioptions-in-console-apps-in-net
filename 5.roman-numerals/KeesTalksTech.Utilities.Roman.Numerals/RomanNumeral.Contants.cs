namespace KeesTalksTech.Utilities.Roman.Numerals;

public partial class RomanNumeral
{
    // 0, nothing, nada. The zero wasn't invented yet ;-)
    public const string NULLA = "NULLA";

    //values - a readonly dictionary where the numerals are the keys to values
    public static readonly IReadOnlyDictionary<string, int> VALUES = new Dictionary<string, int>
    {
        {"I",       1 },
        {"IV",      4 },
        {"V",       5 },
        {"IX",      9 },
        {"X",       10 },
        {"XIIX",    18 },
        {"IIXX",    18 },
        {"XL",      40 },
        {"L",       50 },
        {"XC",      90 },
        {"C",       100 },
        {"CD",      400 },
        {"D",       500 },
        {"CM",      900 },
        {"M",       1000 },

        //alternatives from Middle Ages and Renaissance
        {"O",       11 },
        {"F",       40 },
        {"P",       400 },
        {"G",       400 },
        {"Q",       500 }
    }
    .AsReadOnly();

    //all the options that are used for parsing, in their order of value
    public static readonly string[] NUMERAL_OPTIONS =
    {
        "M", "CM", "D", "Q", "CD", "P", "G", "C", "XC", "L", "F", "XL", "IIXX", "XIIX", "O", "X", "IX", "V", "IV", "I"
    };

    //subtractive notation uses these numerals
    public static readonly string[] SUBTRACTIVE_NOTATION =
    {
        "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"
    };

    //the addative notation uses these numerals
    public static readonly string[] ADDITIVE_NOTATION =
    {
        "M", "D", "C", "L", "X", "V", "I"
    };
}