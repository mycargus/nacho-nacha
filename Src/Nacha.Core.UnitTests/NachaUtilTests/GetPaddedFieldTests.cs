using System;
using FluentAssertions;
using TypeMock.ArrangeActAssert;
using Xunit;

namespace Nacha.Core.UnitTests.NachaUtilTests
{
    [Isolated]
    public class GetPaddedFieldTests
    {
	private const string _FieldToPad = "test";
    
	    [Fact]
	    public void GetPaddedField_FieldIsNull_ShouldThrowArgumentNullException()
	    {
		    string field = null;

		    Action act = () => NachaUtil.GetPaddedField(field, 1);

		    act.ShouldThrow<ArgumentNullException>("field argument cannot be null");
	    }

	    [Fact]
	    public void GetPaddedField_FieldIsEmpty_ResultLengthShouldEqualTheRequiredLength()
	    {
		    var field = String.Empty;
		    const int RequiredLength = 1;

		    var paddedField = NachaUtil.GetPaddedField(field, RequiredLength);

		    paddedField.Length.Should().Be(RequiredLength, "empty fields should be padded with empty space");
	    }

	    [Fact]
	    public void GetPaddedField_FieldIsNotEmptyAndRequiredLengthIsLessThanFieldLength_ResultLengthShouldEqualTheRequiredLength()
	    {
		    const string Field = _FieldToPad;
		    const int RequiredLength = 1;

		    var paddedField = NachaUtil.GetPaddedField(Field, RequiredLength);

		    paddedField.Length.Should().Be(RequiredLength, "fields should be truncated if requested");
	    }

	    [Fact]
	    public void GetPaddedField_FieldIsNotEmptyAndRequiredLengthIsGreaterThanFieldLength_ResultLengthShouldEqualTheRequiredLength()
	    {
		    const string Field = _FieldToPad;
			const int RequiredLength = 5;

			var paddedField = NachaUtil.GetPaddedField(Field, RequiredLength);

			paddedField.Length.Should().Be(RequiredLength, "fields should be padded with empty space when appropriate");
	    }

	    [Fact]
	    public void GetPaddedField_FieldIsNotEmptyAndRequiredLengthEqualsFieldLength_ResultLengthShouldEqualTheRequiredLength()
	    {
		    const string Field = _FieldToPad;
			const int RequiredLength = 4;

			var paddedField = NachaUtil.GetPaddedField(Field, RequiredLength);

			paddedField.Length.Should().Be(RequiredLength, "no padding should be added when original field length equals the required length");
	    }
	    
	    [Fact]
	    public void GetPaddedField_RequiredLengthIsNegative_ShouldThrowArgumentException()
	    {
		    const string Field = _FieldToPad;
		    const int RequiredLength = -1;

		    Action act = () => NachaUtil.GetPaddedField(Field, RequiredLength);

		    act.ShouldThrow<ArgumentException>("required length argument cannot be negative");
	    }

	    [Fact]
	    public void GetPaddedField_RequiredLengthIsZero_ShouldThrowArgumentException()
	    {
		    const string Field = _FieldToPad;
			const int RequiredLength = 0;

			Action act = () => NachaUtil.GetPaddedField(Field, RequiredLength);

			act.ShouldThrow<ArgumentException>("required length argument cannot be zero");
	    }
    }
}
