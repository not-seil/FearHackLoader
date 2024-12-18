using System.Security.Cryptography;

public static class GClass0
{
	public static string smethod_0(string string_0)
	{
		string text = (string)(object)new MD5CryptoServiceProvider();
		string text2 = null;
		while (text.Length < string_0.Length)
		{
			text += text;
		}
		for (int i = 0; i < string_0.Length; i++)
		{
			text2 += (char)(string_0[i] ^ text[i]);
		}
		return text2;
	}
}
