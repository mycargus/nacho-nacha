using System;

namespace Nacha.Core
{
    public static class NachaUtil
    {
	    private static void PadFieldToRequiredLength(ref string a_Field, int a_RequiredLength)
	    {
		    if (a_Field == null) throw new ArgumentNullException();
		    if (a_RequiredLength <= 0) throw new ArgumentException();

		    a_Field = a_RequiredLength >= a_Field.Length ? a_Field.PadRight(a_RequiredLength, ' ') : a_Field.Substring(0, a_RequiredLength);
	    }

	    public static string GetPaddedField(string a_Field, int a_RequiredLength)
	    {
		    PadFieldToRequiredLength(ref a_Field, a_RequiredLength);
		    return a_Field;
	    }
    }
}
