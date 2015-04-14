using System;
using System.Linq;

namespace Nacha.Core
{
    public class FileHeaderRecord : INachaFileService
    {
	    public enum RequiredFieldLength
	    {
		    RecordTypeCode = 1,
		    PriorityCode = 2,
		    ImmediateDestination = 10,
		    ImmediateOrigin = 10,
		    FileCreationDate = 6,
		    FileCreationTime = 4,
		    FileIdModifier = 1,
		    RecordSize = 3,
		    BlockingFactor = 2,
		    FormatCode = 1,
		    ImmediateDestinationName = 23,
		    ImmediateOriginName = 23,
		    ReferenceCode = 8
	    }

	    private readonly NachaFile.RecordTypeCode _recordTypeCode;
	    private readonly string _priorityCode;
	    private readonly BrokerBankAccount _immediateDestination;
	    private readonly BrokerOrigin _immediateOrigin;
	    private readonly DateTime _fileCreationDateAndTime;
	    private string _fileIdModifier;
	    private readonly string _recordSize;
	    private readonly int _blockingFactor;
	    private readonly string _formatCode;
	    private readonly string _referenceCode;
	    public bool IsValidated { get; set; }

	    public FileHeaderRecord(BrokerBankAccount a_ImmediateDestination, BrokerOrigin a_ImmediateOrigin, string a_FileIdModifier = NachaFile.DEFAULT_FILE_ID_MODIFIER, string a_ReferenceCode = "1")
	    {
		    if (a_ImmediateDestination == null) throw new ArgumentNullException();
		    if (a_ImmediateOrigin == null) throw new ArgumentNullException();
		    _recordTypeCode = NachaFile.RecordTypeCode.FileHeaderRecord;
		    _priorityCode = NachaFile.PRIORITY_CODE;
		    _immediateDestination = a_ImmediateDestination;
		    _immediateOrigin = a_ImmediateOrigin;
		    _fileCreationDateAndTime = DateTime.Now;
		    _fileIdModifier = a_FileIdModifier;
		    _recordSize = NachaFile.RECORD_SIZE;
		    _blockingFactor = NachaFile.BLOCKING_FACTOR;
		    _formatCode = NachaFile.FORMAT_CODE;
		    _referenceCode = a_ReferenceCode;
		    IsValidated = false;
	    }

	    private string FormatFileCreationDate(DateTime a_FileCreationDate)
	    {
		    return a_FileCreationDate.Date.ToString(NachaFile.DATE_FORMAT);
	    }

	    private string FormatFileCreationTime(DateTime a_FileCreationDate)
	    {
		    return a_FileCreationDate.ToString(NachaFile.TIME_FORMAT);
	    }

	    public override string ToString()
	    {
		    if (!IsValidated) throw new Exception(NachaFile.TOSTRING_ERROR_MSG);

		    return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}",
			    NachaUtil.GetPaddedField(_recordTypeCode.ToString("D"), (int) RequiredFieldLength.RecordTypeCode),
			    NachaUtil.GetPaddedField(_priorityCode, (int) RequiredFieldLength.PriorityCode),
			    NachaUtil.GetPaddedField(_immediateDestination.GetRoutingNumber(), (int) RequiredFieldLength.ImmediateDestination),
			    NachaUtil.GetPaddedField(_immediateOrigin.CompanyId, (int) RequiredFieldLength.ImmediateOrigin),
			    NachaUtil.GetPaddedField(FormatFileCreationDate(_fileCreationDateAndTime), (int) RequiredFieldLength.FileCreationDate),
			    NachaUtil.GetPaddedField(FormatFileCreationTime(_fileCreationDateAndTime), (int) RequiredFieldLength.FileCreationTime),
			    NachaUtil.GetPaddedField(_fileIdModifier, (int) RequiredFieldLength.FileIdModifier),
			    NachaUtil.GetPaddedField(_recordSize, (int) RequiredFieldLength.RecordSize),
			    NachaUtil.GetPaddedField(_blockingFactor.ToString(), (int) RequiredFieldLength.BlockingFactor),
			    NachaUtil.GetPaddedField(_formatCode, (int) RequiredFieldLength.FormatCode),
				NachaUtil.GetPaddedField(_immediateDestination.GetBankName(), (int)RequiredFieldLength.ImmediateDestinationName),
			    NachaUtil.GetPaddedField(_immediateOrigin.OriginName, (int) RequiredFieldLength.ImmediateOriginName),
			    NachaUtil.GetPaddedField(_referenceCode, (int) RequiredFieldLength.ReferenceCode)
			    );
	    }

	    public void Validate()
	    {
		    try
		    {
			    ValidateRecord();
			    IsValidated = true;
		    }
		    catch (Exception)
		    {
			    IsValidated = false;
			    throw;
		    }
	    }

	    private void ValidateRecord()
	    {
		    if (!AllFieldsArePresent()) throw new ApplicationException("All record fields must be present");
			if (!_immediateDestination.IsValidRoutingNumber() || !_immediateOrigin.IsValidRoutingNumber()) throw new ApplicationException("Invalid routing number");
		    if (!_fileIdModifier.All(char.IsLetterOrDigit)) throw new ApplicationException("File ID restricted to alpha-numeric characters only");

		    _fileIdModifier = _fileIdModifier.ToUpper();
		    _immediateOrigin.OriginName = _immediateOrigin.OriginName.ToUpper();
	    }

	    private bool AllFieldsArePresent()
	    {
		    return _priorityCode.Trim().Length > 0 &&
		           _immediateDestination != null &&
				   _immediateDestination.GetRoutingNumber().Trim().Length > 0 &&
		           _immediateOrigin != null &&
		           _immediateOrigin.CompanyId.Trim().Length > 0 &&
		           _fileCreationDateAndTime > DateTime.MinValue &&
		           _fileIdModifier.Trim().Length > 0 &&
		           _recordSize.Trim().Length > 0 &&
		           _blockingFactor > 0 &&
		           _formatCode.Trim().Length > 0 &&
		           _immediateDestination.GetBankName().Length > 0 &&
		           _immediateOrigin.OriginName.Trim().Length > 0 &&
		           _referenceCode.Trim().Length > 0;
	    }
    }
}
