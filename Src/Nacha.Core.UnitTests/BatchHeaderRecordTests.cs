namespace Nacha.Core.UnitTests
{
    class BatchHeaderRecordTests
    {
	    //[Fact]
	    //public void BatchHeaderRecord_ToStringWithoutValidate_ShouldThrowException()
	    //{
	    //	BatchHeaderRecord record = Isolate.Fake.Dependencies<BatchHeaderRecord>();

	    //	Action act = () => record.ToString();

	    //	act.ShouldThrow<Exception>(NachaFile.TOSTRING_ERROR_MSG);
	    //}

	    //[Fact]
	    //public void BatchHeaderRecord_ValidateValidRecord_IsValidatedShouldBeTrue()
	    //{
	    //	// arrange
	    //	BatchHeaderRecord record = Isolate.Fake.Dependencies<BatchHeaderRecord>();

	    //	// act
	    //	Action act = record.Validate;
	    //	act.Invoke();

	    //	// assert
	    //	record.IsValidated.Should().BeTrue();
	    //}

	    //[Fact]
	    //public void BatchHeaderRecord_ValidateRecordWhoseServiceClassCodeIsUndefined_ShouldThrowApplicationException()
	    //{
	    //	// arrange
	    //	BatchHeaderRecord record = Isolate.Fake.Dependencies<BatchHeaderRecord>();

	    //	// act
	    //	Action act = record.Validate;
	    //	act.Invoke();

	    //	// assert
	    //	act.ShouldThrow<ApplicationException>().And.Message.Should().Be("All record fields must be present");
	    //}

	    //[Fact]
	    //public void BatchHeaderRecord_ValidateValidRecord_LengthOfObjectStringShouldBe94()
	    //{
	    //	// arrange
	    //	BatchHeaderRecord record = Isolate.Fake.Dependencies<BatchHeaderRecord>();

	    //	// act
	    //	Action act = record.Validate;
	    //	act.Invoke();
	    //	string result = record.ToString();

	    //	// assert
	    //	result.Length.Should().Be(NachaFile.MAX_CHARACTERS_PER_LINE, string.Format("total number of characters in the record should be {0}", NachaFile.MAX_CHARACTERS_PER_LINE));
	    //}
    }
}
