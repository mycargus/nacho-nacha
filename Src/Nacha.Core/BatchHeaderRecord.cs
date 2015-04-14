using System;

namespace Nacha.Core
{
    public class BatchHeaderRecord : INachaFileService
    {

	    public enum RequiredFieldLength
	    {
		    RecordTypeCode = 1,
		    ServiceClassCode = 3,
		    CompanyName = 16,
		    CompanyDiscretionaryData = 20,
		    CompanyIdentification = 10,
		    StandardEntryClassCode = 3,
		    CompanyEntryDescription = 10,
		    CompanyDescriptiveDate = 6,
		    EffectiveEntryDate = 6,
		    SettlementDate = 3,
		    OriginatorStatusCode = 1,
		    OriginatingDfiIdentification = 8,
		    BatchNumber = 7
	    }

	    private NachaFile.RecordTypeCode _recordTypeCode;
	    private readonly Batch.ServiceClassCode _serviceClassCode;
	    private readonly BrokerOrigin _companyOrigin;
	    private string _discretionaryData;
	    private readonly Batch.StandardEntryClass _standardEntryClass;
	    private readonly string _companyEntryDescription;
	    private readonly DateTime _companyDescriptiveDate;
	    private readonly DateTime _effectiveEntryDate;
	    private readonly string _settlementDate;  // reserve for ACH operator
	    private readonly string _originatorStatusCode;
	    private readonly string _originatingFinancialInstitutionId;
	    private int _batchNumber;
	    public bool IsValidated { get; set; }

	    private const string _OriginatorStatusCode = "1";

	    public BatchHeaderRecord(BrokerOrigin a_CompanyOrigin)
	    {
		    if (a_CompanyOrigin == null) throw new ArgumentNullException();
		    _recordTypeCode = NachaFile.RecordTypeCode.BatchHeaderRecord;
		    _serviceClassCode = Batch.ServiceClassCode.Undefined;
		    _companyOrigin = a_CompanyOrigin;
		    _discretionaryData = String.Empty;
		    _standardEntryClass = Batch.StandardEntryClass.Undefined;
		    _companyEntryDescription = String.Empty;
		    _companyDescriptiveDate = DateTime.MinValue;
		    _effectiveEntryDate = DateTime.MinValue;
		    _settlementDate = String.Empty;  
		    _originatorStatusCode = _OriginatorStatusCode;
		    _originatingFinancialInstitutionId = String.Empty;
		    _batchNumber = ++Batch.batchCount;
		    IsValidated = false;
	    }

	    public override string ToString()
	    {
		    throw new NotImplementedException();

		    if (!IsValidated) throw new Exception(NachaFile.TOSTRING_ERROR_MSG);

		    return "";
	    }

	    public void Validate()
	    {
		    throw new NotImplementedException();

		    if (!AllFieldsArePresent()) throw new ApplicationException("All record fields must be present");

	    }

	    private bool AllFieldsArePresent()
	    {
		    throw new NotImplementedException();

		    return _serviceClassCode != Batch.ServiceClassCode.Undefined &&
		           _companyOrigin != null &&
		           _companyOrigin.OriginName.Trim().Length > 0 &&
		           _companyOrigin.CompanyId.Trim().Length > 0 &&
		           _standardEntryClass != Batch.StandardEntryClass.Undefined &&
		           _companyEntryDescription.Trim().Length > 0 &&
		           _companyDescriptiveDate > DateTime.MinValue &&
		           _effectiveEntryDate > DateTime.MinValue &&
		           _settlementDate.Trim().Length == 0 &&
		           _originatorStatusCode.Trim().Length > 0 &&
		           _originatingFinancialInstitutionId.Trim().Length > 0;
	    }
    }
}
