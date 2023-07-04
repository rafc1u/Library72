using System.Text;
using System.Text.RegularExpressions;

namespace Library72.Application.Helpers;

public static class StringHelpers
{
	public static string InvertWords(this string sentence)
	{
		var isWordCharacterRegexPatter = "[\\p{L}\\p{N}]";
		var revertedSentence = new StringBuilder();
		var bufferedWord = new StringBuilder();

		foreach (var character in sentence)
		{
			if (Regex.IsMatch(character.ToString(), isWordCharacterRegexPatter))
			{
				bufferedWord.Append(character);
			}
			else
			{
				string reversedBufferedWord = RevertCharacters(bufferedWord);
				revertedSentence.Append(reversedBufferedWord);
				revertedSentence.Append(character);

				bufferedWord = bufferedWord.Clear();
			}
		}

		revertedSentence.Append(RevertCharacters(bufferedWord));

		return revertedSentence.ToString();
	}

	private static string RevertCharacters(StringBuilder bufferedWord)
	{
		return new string(bufferedWord.ToString().Reverse().ToArray());
	}
}
