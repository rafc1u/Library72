using Library72.Application.Helpers;
using Xunit;

namespace Library72.Application.UnitTests.Helpers;

public class StringHelpersTests
{
	[Theory]
	[InlineData("Hello World", "olleH dlroW")]
	[InlineData("OpenAI is amazing", "IAnepO si gnizama")]
	[InlineData("12345", "54321")]
	[InlineData("", "")]
	[InlineData("a", "a")]
	[InlineData("   ", "   ")]
	[InlineData("Hello, world!", "olleH, dlrow!")]
	public void InvertWords_ShouldInvertWordsInSentence(string sentence, string expectedInvertedSentence)
	{
		// Arrange

		// Act
		string invertedSentence = sentence.InvertWords();

		// Assert
		Assert.Equal(expectedInvertedSentence, invertedSentence);
	}
}