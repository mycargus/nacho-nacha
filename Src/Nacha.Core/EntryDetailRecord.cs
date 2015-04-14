using System;

namespace Nacha.Core
{
	public class EntryDetailRecord : INachaFileService
	{

		public enum TransactionCode
		{
			CheckingAccountCredit = 22,
			CheckingAccountDebit = 27,
			SavingsAccountCredit = 32,
			SavingsAccountDebit = 37
		}


		private NachaFile.RecordTypeCode _recordTypeCode;
		protected TransactionCode transactionCode;
		protected string receivingDfiRoutingNumber;
		protected int checkDigit;
		protected string receivingDfiAccountNumber;
		protected double amount;
		protected string discretionaryData;
		protected int addendaRecordIndicator;
		protected int traceNumber;


		public EntryDetailRecord()
		{
			_recordTypeCode = NachaFile.RecordTypeCode.EntryDetailRecord;
			
		}

		protected void SetCheckDigit()
		{
			throw new NotImplementedException();
		}

		public new virtual string ToString()
		{
			throw new NotImplementedException();
		}

		public virtual void Validate()
		{
			throw new NotImplementedException();
		}
	}
}
