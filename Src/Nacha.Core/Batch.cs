using System;
using System.Collections.Generic;

namespace Nacha.Core
{
    public class Batch : INachaFileService
    {
	    public enum StandardEntryClass
	    {
		    Undefined = 0,
		    Ppd = 1,
		    Web = 2,
		    Ccd = 3
	    }

	    public enum ServiceClassCode
	    {
		    Undefined = 0,
		    AchMixedDebitsAndCredits = 200,
		    AchCreditsOnly = 220,
		    AchDebitsOnly = 225
	    }



	    private BatchHeaderRecord _batchHeaderRecord;
	    private List<EntryDetailRecord> _entryDetailRecords; 
	    private BatchControlRecord _batchControlRecord;
	    public bool IsValidated { get; set; }
	    public static int batchCount = 0;


	    public Batch(List<EntryDetailRecord> a_EntryDetailRecords)
	    {
		    throw new NotImplementedException();

		    _batchHeaderRecord = null;
		    _entryDetailRecords = a_EntryDetailRecords;
		    _batchControlRecord = null;

		    IsValidated = false;
		    batchCount += 1;
	    }

	    public new virtual string ToString()
	    {
		    throw new NotImplementedException();

		    if (!IsValidated) throw new Exception(NachaFile.TOSTRING_ERROR_MSG);

		    return "";
	    }

	    public virtual void Validate()
	    {
		    throw new NotImplementedException();
	    }
    }
}
