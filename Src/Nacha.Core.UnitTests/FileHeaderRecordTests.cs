using System;
using Core;
using FluentAssertions;
using TypeMock.ArrangeActAssert;
using Xunit;

namespace Nacha.Core.UnitTests
{
    public class FileHeaderRecordTests
    {
	    private const string _ValidRoutingNumber = "051000017";


	    private BrokerBankAccount GenerateBrokerBankAccount()
	    {
		    var fake = Isolate.Fake.Instance<BrokerBankAccount>();
		    fake.BankName = "Fake Bank Name";
		    fake.RoutingNumber = _ValidRoutingNumber;
		    
		    return fake;
	    }

	    private BrokerOrigin GenerateBrokerOrigin()
	    {
		    var fake = Isolate.Fake.Instance<BrokerOrigin>();
		    fake.OriginName = "Origin Company";
		    fake.CompanyId = _ValidRoutingNumber;

		    return fake;
	    }

	    private FileHeaderRecord GenerateFileHeaderRecord()
	    {
		    var fakeBrokerBankAccount = GenerateBrokerBankAccount();
		    var fakeBrokerOrigin = GenerateBrokerOrigin();

		    return new FileHeaderRecord(fakeBrokerBankAccount, fakeBrokerOrigin);
	    }


	    [Fact]
	    public void FileHeaderRecord_ToStringWithoutValidate_ShouldThrowException()
	    {
		    var fileHeaderRecord = GenerateFileHeaderRecord();

		    Action act = () => fileHeaderRecord.ToString();

		    act.ShouldThrow<Exception>("object must be validated before obtaining object string");
	    }

	    [Fact]
	    public void FileHeaderRecord_ValidateValidRecord_RecordIsValidated()
	    {
		    // arrange
		    var record = GenerateFileHeaderRecord();

		    // act
		    Action act = record.Validate;
		    act.Invoke();

		    // assert
		    record.IsValidated.Should().BeTrue();
	    }

	    [Fact]
	    public void FileHeaderRecord_ValidateValidRecord_LengthOfObjectStringShouldBe94()
	    {
		    // arrange
		    var record = GenerateFileHeaderRecord();

		    // act
		    Action act = record.Validate;
		    act.Invoke();
		    var result = record.ToString();

		    // assert
		    result.Length.Should().Be(NachaFile.MAX_CHARACTERS_PER_LINE, string.Format("total number of characters in the record should be {0}", NachaFile.MAX_CHARACTERS_PER_LINE));
	    }

	    [Fact]
	    public void FileHeaderRecord_ValidateRecordMissingFileIdModifier_ShouldThrowApplicationException()
	    {
		    // arrange
		    var fakeBrokerBankAccount = GenerateBrokerBankAccount();
		    var fakeBrokerOrigin = GenerateBrokerOrigin();
		    var record = new FileHeaderRecord(fakeBrokerBankAccount, fakeBrokerOrigin, "");


		    // act
		    Action act = record.Validate;

		    // assert
		    act.ShouldThrow<ApplicationException>().And.Message.Should().Be("All record fields must be present");
	    }

	    [Fact]
	    public void FileHeaderRecord_ValidateRecordWithInvalidBrokerBankAccountRoutingNumber_ShouldThrowApplicationException()
	    {
		    // arrange
		    const string InvalidRoutingNum = "123456789";
		    var fakeBrokerBankAccount = GenerateBrokerBankAccount();
		    fakeBrokerBankAccount.RoutingNumber = InvalidRoutingNum;
		    var fakeBrokerOrigin = GenerateBrokerOrigin();
		    var record = new FileHeaderRecord(fakeBrokerBankAccount, fakeBrokerOrigin);

		    // act
		    Action act = record.Validate;

		    // assert
		    act.ShouldThrow<ApplicationException>().And.Message.Should().Be("Invalid routing number");
	    }

	    [Fact]
	    public void FileHeaderRecord_ValidateRecordWithInvalidBrokerOriginCompanyId_ShouldThrowApplicationException()
	    {
		    // arrange
		    const string InvalidRoutingNum = "123456789";
		    var fakeBrokerBankAccount = GenerateBrokerBankAccount();
		    var fakeBrokerOrigin = GenerateBrokerOrigin();
		    fakeBrokerOrigin.CompanyId = InvalidRoutingNum;
		    var record = new FileHeaderRecord(fakeBrokerBankAccount, fakeBrokerOrigin);

		    // act
		    Action act = record.Validate;

		    // assert
		    act.ShouldThrow<ApplicationException>().And.Message.Should().Be("Invalid routing number");
	    }

	    [Fact]
	    public void FileHeaderRecord_ValidateRecordWithNonAlphanumericFileIdModifier_ShouldThrowApplicationException_AndIsValidatedShouldBeFalse()
	    {
		    // arrange
		    var fakeBrokerBankAccount = GenerateBrokerBankAccount();
		    var fakeBrokerOrigin = GenerateBrokerOrigin();
		    var record = new FileHeaderRecord(fakeBrokerBankAccount, fakeBrokerOrigin, "$");

		    // act
		    Action act = record.Validate;

		    // assert
		    act.ShouldThrow<ApplicationException>().And.Message.Should().Be("File ID restricted to alpha-numeric characters only");
		    record.IsValidated.Should().BeFalse();
	    }

	    [Fact]
	    public void FileHeaderRecord_ToStringRecordAfterValidation_AllLettersAreCapitalized()
	    {
		    // arrange
		    var record = GenerateFileHeaderRecord();

		    // act
		    Action act = record.Validate;
		    act.Invoke();
		    var recordAfterValidation = record.ToString();
		    var recordAfterValidationWithUpperCase = recordAfterValidation.ToUpper();

		    // assert
		    recordAfterValidation.Should()
			    .Be(recordAfterValidationWithUpperCase, "all letters in the record should be upper case");
	    }
    }
}
