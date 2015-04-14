using System;

namespace Nacha.Core
{
    class BatchControlRecord : INachaFileService
    {



	    public bool IsValidated { get; set; }


	    public BatchControlRecord()
	    {
		throw new NotImplementedException();

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
	    }
    }
}
