using System;

namespace Nacha.Core
{
	public class PpdEntryDetailRecord : EntryDetailRecord
	{
		private string _individualIdNumber;
		private string _individualName;

		public PpdEntryDetailRecord(TransactionCode a_TransactionCode, string a_ReceivingDfiRoutingNumber, string a_ReceivingDfiAccountNumber, 
					    double a_Amount, int a_AddendaRecordIndicator, int a_TraceNumber, string a_IndividualIdNumber, string a_IndividualName)
		{
			transactionCode = a_TransactionCode;
			receivingDfiRoutingNumber = a_ReceivingDfiRoutingNumber;
			receivingDfiAccountNumber = a_ReceivingDfiAccountNumber;
			amount = a_Amount;
			addendaRecordIndicator = a_AddendaRecordIndicator;
			traceNumber = a_TraceNumber;
			_individualIdNumber = a_IndividualIdNumber;
			_individualName = a_IndividualName;
		}


		public override string ToString()
		{
			throw new NotImplementedException();
			return base.ToString();
		}

		public override void Validate()
		{
			throw new NotImplementedException();
			
			SetCheckDigit(); // after validating routing #
		}
	}
}
